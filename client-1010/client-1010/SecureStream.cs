using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
 
namespace asdNet
{
    /// <summary>
	/// This is a class that transforms a simple (non-encrypted) stream into an
	/// encrypted one. <br/>
	/// It does: Create an assymetric private key (on server), sends the public
	/// part to the client and, then, the client creates a new symmetric key that 
	/// is known is sent to the server using the asmmetric key.<br/>
	/// After that, only the symmetric algorithm is used, as it is faster,
	/// but it is guaranteed that only the server and the client knows the key.<br/>
	/// This cryptography guarantees that no one "sniffing" the network would be
	/// able to interpret the messages, but does not guarantees that the requested
	/// host is really the host it should be. To that additional verification,
	/// you would probably need to deal with certificates and the SslStream.
	/// </summary>
	public class SecureStream: Stream
	{
		private static readonly byte[] fEmptyReadBuffer = new byte[0];
	
		private MemoryStream fWriteBuffer;
      
		//the default symmetric or assymetric class/algorithm, and running as client 
        //the default symmetricis the RijndaelManaged class(Rijndael)
 
		public SecureStream(Stream baseStream):
            this(baseStream, new RSACryptoServiceProvider(), "Rijndael", false)
		{
		}

		// specifying if running as client or server, but without changing
		// the default symmetric or assymetric class/algorithm..
		public SecureStream(Stream baseStream, bool runAsServer):
			this(baseStream, new RSACryptoServiceProvider(), "Rijndael", runAsServer)
		{
		}
		
        // Species the symmetricAlgorithm to use and running as client by default.
		public SecureStream(Stream baseStream, string symmetricAlgorithmName):
			this(baseStream, new RSACryptoServiceProvider(), symmetricAlgorithmName, false)
		{
		}
		
		// Species the symmetricAlgorithm to use and if it runs as a client or server.
        public SecureStream(Stream baseStream, string symmetricAlgorithmName, bool runAsServer) :
			this(baseStream, new RSACryptoServiceProvider(), symmetricAlgorithmName, runAsServer)
		{
		}

		// Specifies the assymetric and the symmetric algorithm to use, and if it 
		// must run as client or server.
		public SecureStream(Stream baseStream, RSACryptoServiceProvider rsa, string symmetricAlgorithmName, bool runAsServer)
		{
			if (baseStream == null)
				throw new ArgumentNullException("baseStream");
			
			if (rsa == null)
				throw new ArgumentNullException("rsa");

             if(string.IsNullOrEmpty (symmetricAlgorithmName))
				throw new ArgumentNullException("symmetricAlgorithm");
		
			BaseStream = baseStream;
            //SymmetricAlgorithm = SymmetricAlgorithm.Create(symmetricAlgorithmName); //symmetricAlgorithm;
            //string symmetricTypeName = SymmetricAlgorithm.GetType().ToString();
            //byte[] symmetricTypeBytes = Encoding.UTF8.GetBytes(symmetricTypeName);
			if (runAsServer)
			{
                //1.Send symmetric algorithm name
                SymmetricAlgorithm = SymmetricAlgorithm.Create(symmetricAlgorithmName); //symmetricAlgorithm;
                string symmetricTypeName = SymmetricAlgorithm.GetType().ToString();
                byte[] symmetricTypeBytes = Encoding.UTF8.GetBytes(symmetricTypeName);

				byte[] sizeBytes = BitConverter.GetBytes(symmetricTypeBytes.Length);
				baseStream.Write(sizeBytes, 0, sizeBytes.Length);
				baseStream.Write(symmetricTypeBytes, 0, symmetricTypeBytes.Length);
			
                //send public key
				byte[] bytes = rsa.ExportCspBlob(false); //public key
				sizeBytes = BitConverter.GetBytes(bytes.Length);
				baseStream.Write(sizeBytes, 0, sizeBytes.Length);
				baseStream.Write(bytes, 0, bytes.Length);

                //3.Recive symmetric algorithm key and IV
				SymmetricAlgorithm.Key  = p_ReadWithLength(rsa);;
				SymmetricAlgorithm.IV   = p_ReadWithLength(rsa);
			}
			else
			{
				// ok. We run as the client, so first we first check the
				// algorithm types and then receive the assymetric
				// key from the server.
				
				// symmetricAlgorithm
				var sizeBytes = new byte[4];
				p_ReadDirect(sizeBytes);
				var stringLength = BitConverter.ToInt32(sizeBytes, 0);
				
                //if (stringLength != symmetricTypeBytes.Length)
                //    throw new ArgumentException("Server and client must use the same SymmetricAlgorithm class.");
				
				var stringBytes = new byte[stringLength];
				p_ReadDirect(stringBytes);
			//	var str = Encoding.UTF8.GetString(stringBytes);
                var symmetricTypeName = Encoding.UTF8.GetString(stringBytes);
                SymmetricAlgorithm = SymmetricAlgorithm.Create(symmetricTypeName); 

                //if (str != symmetricTypeName)
                //    throw new ArgumentException("Server and client must use the same SymmetricAlgorithm class.");

				// public key.
				sizeBytes = new byte[4];
				p_ReadDirect(sizeBytes);
				int asymmetricKeyLength = BitConverter.ToInt32(sizeBytes, 0);
				byte[] bytes = new byte[asymmetricKeyLength];
				p_ReadDirect(bytes);
				rsa.ImportCspBlob(bytes);
				
				// Now that we have the asymmetricAlgorithm set, and considering
				// that the symmetricAlgorithm initializes automatically, we must
				// only send the key.
				p_WriteWithLength(rsa, SymmetricAlgorithm.Key);
				p_WriteWithLength(rsa, SymmetricAlgorithm.IV);
			}
			
			// After the object initialization being done, be it a client or a
			// server, we can dispose the assymetricAlgorithm.
			rsa.Clear();
			
			Decryptor = SymmetricAlgorithm.CreateDecryptor();
			Encryptor = SymmetricAlgorithm.CreateEncryptor();
			
			fReadBuffer = fEmptyReadBuffer;
			fWriteBuffer = new MemoryStream(32 * 1024);
 		}

		/// <summary>
		/// Releases the buffers, the basestream and the cryptographic classes.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				var writeBuffer = fWriteBuffer;
				if (writeBuffer != null)
				{
					fWriteBuffer = null;
					writeBuffer.Dispose();
				}
				
				var encryptor = this.Encryptor;
				if (encryptor != null)
				{
					Encryptor = null;
					encryptor.Dispose();
				}
				
				var decryptor = this.Decryptor;
				if (decryptor != null)
				{
					Decryptor = null;
					decryptor.Dispose();
				}
				
				var symmetricAlgorithm = SymmetricAlgorithm;
				if (symmetricAlgorithm != null)
				{
					SymmetricAlgorithm = null;
					symmetricAlgorithm.Clear();
				}
				
				var baseStream = this.BaseStream;
				if (baseStream != null)
				{
					BaseStream = null;
					baseStream.Dispose();
				}
				
				fReadBuffer = null;
			}
	
			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets the original stream that created this asymmetric crypto stream.
		/// </summary>
		public Stream BaseStream { get; private set; }
		
        //public key
       // public string BaseStream { get; private set; }
		/// <summary>
		/// Gets the symmetric algorithm being used.
		/// </summary>
		public SymmetricAlgorithm SymmetricAlgorithm { get; private set; }
		
		/// <summary>
		/// Gets the encryptor being used.
		/// </summary>
		public ICryptoTransform Decryptor { get; private set; }
		
		/// <summary>
		/// Gets the decryptor being used.
		/// </summary>
		public ICryptoTransform Encryptor { get; private set; }
		
		/// <summary>
		/// Always returns true.
		/// </summary>
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Always returns false.
		/// </summary>
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Always returns true.
		/// </summary>
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Throws a NotSupportedException.
		/// </summary>
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Throws a NotSupportedException.
		/// </summary>
		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		private readonly byte[] fSizeBytes = new byte[4];
		private int fReadPosition;
		private byte[] fReadBuffer;
		
		/// <summary>
		/// Reads and decryptographs the given number of bytes from the buffer.
		/// </summary>
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (fReadPosition == fReadBuffer.Length)
			{
				p_ReadDirect(fSizeBytes);
				int readLength = BitConverter.ToInt32(fSizeBytes, 0);
				
				if (fReadBuffer.Length < readLength)
					fReadBuffer = new byte[readLength];
					
				p_FullReadDirect(fReadBuffer, readLength);
				fReadBuffer = Decryptor.TransformFinalBlock(fReadBuffer, 0, readLength);
				
				fReadPosition = 0;
			}
			
			int diff = fReadBuffer.Length - fReadPosition;
			if (count > diff)
				count = diff;
			
			Buffer.BlockCopy(fReadBuffer, fReadPosition, buffer, offset, count);
			fReadPosition += count;
			return count;
		}

		/// <summary>
		/// Throws a NotSupportedException.
		/// </summary>
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Throws a NotSupportedException.
		/// </summary>
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Encrypts and writes the given bytes.
		/// </summary>
		public override void Write(byte[] buffer, int offset, int count)
		{
			fWriteBuffer.Write(buffer, offset, count);
		}

		/// <summary>
		/// Sends all the buffered data.
		/// </summary>
		public override void Flush()
		{
            if (fWriteBuffer != null)
            {
                if (fWriteBuffer.Length > 0)
                {
                    var encryptedBuffer = Encryptor.TransformFinalBlock(fWriteBuffer.GetBuffer(), 0, (int)fWriteBuffer.Length);
                    var size = BitConverter.GetBytes(encryptedBuffer.Length);
                    BaseStream.Write(size, 0, size.Length);
                    BaseStream.Write(encryptedBuffer, 0, encryptedBuffer.Length);
                    BaseStream.Flush();

                    fWriteBuffer.SetLength(0);
                    fWriteBuffer.Capacity = 32 * 1024;
                }
            }
		}
		
		private void p_ReadDirect(byte[] bytes)
		{
			p_FullReadDirect(bytes, bytes.Length);
		}

		private void p_FullReadDirect(byte[] bytes, int length)
		{
			int read = 0;
			while(read < length)
			{
				int readResult = BaseStream.Read(bytes, read, length - read);
				
				if (readResult == 0)
					throw new IOException("The stream was closed by the remote side.");
				
				read += readResult;
			}
		}

		private byte[] p_ReadWithLength(RSACryptoServiceProvider rsa)
		{
			byte[] size = new byte[4];
			p_ReadDirect(size);
		
			int count = BitConverter.ToInt32(size, 0);
			var bytes = new byte[count];
			p_ReadDirect(bytes);
			
			return rsa.Decrypt(bytes, false);
		}
        //encrypt key & vi
		private void p_WriteWithLength(RSACryptoServiceProvider rsa, byte[] bytes)
		{
			bytes = rsa.Encrypt(bytes, false);
			byte[] sizeBytes = BitConverter.GetBytes(bytes.Length);
			BaseStream.Write(sizeBytes, 0, sizeBytes.Length);
			BaseStream.Write(bytes, 0, bytes.Length);
		}
	}
}
