namespace client_1010
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuStripmain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStrpmain = new System.Windows.Forms.ToolStrip();
            this.tlStpbtnnew = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnconnect = new System.Windows.Forms.ToolStripButton();
            this.tlStrpClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rchtxtQuery = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkprimary = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.typecombo = new System.Windows.Forms.ComboBox();
            this.txtcolumnname = new System.Windows.Forms.TextBox();
            this.txttablename = new System.Windows.Forms.TextBox();
            this.rchtxtCreate = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.new_database = new System.Windows.Forms.TextBox();
            this.tablecombobox = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripmain.SuspendLayout();
            this.tlStrpmain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStripmain
            // 
            this.mnuStripmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuStripmain.Location = new System.Drawing.Point(0, 0);
            this.mnuStripmain.Name = "mnuStripmain";
            this.mnuStripmain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuStripmain.Size = new System.Drawing.Size(982, 28);
            this.mnuStripmain.TabIndex = 1;
            this.mnuStripmain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeDBToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.fileToolStripMenuItem.Text = "&Menu";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.openToolStripMenuItem.Text = "&Open DB";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeDBToolStripMenuItem
            // 
            this.closeDBToolStripMenuItem.Name = "closeDBToolStripMenuItem";
            this.closeDBToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.closeDBToolStripMenuItem.Text = "&Close DB";
            this.closeDBToolStripMenuItem.Click += new System.EventHandler(this.closeDBToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topicsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // topicsToolStripMenuItem
            // 
            this.topicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripHelp});
            this.topicsToolStripMenuItem.Name = "topicsToolStripMenuItem";
            this.topicsToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.topicsToolStripMenuItem.Text = "&Topics";
            // 
            // toolStripHelp
            // 
            this.toolStripHelp.Name = "toolStripHelp";
            this.toolStripHelp.Size = new System.Drawing.Size(122, 24);
            this.toolStripHelp.Text = "Help 1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // tlStrpmain
            // 
            this.tlStrpmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStpbtnnew,
            this.tlstrpbtnconnect,
            this.tlStrpClose});
            this.tlStrpmain.Location = new System.Drawing.Point(0, 28);
            this.tlStrpmain.Name = "tlStrpmain";
            this.tlStrpmain.Size = new System.Drawing.Size(982, 25);
            this.tlStrpmain.TabIndex = 2;
            this.tlStrpmain.Text = "toolStrip1";
            // 
            // tlStpbtnnew
            // 
            this.tlStpbtnnew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStpbtnnew.Image = ((System.Drawing.Image)(resources.GetObject("tlStpbtnnew.Image")));
            this.tlStpbtnnew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStpbtnnew.Name = "tlStpbtnnew";
            this.tlStpbtnnew.Size = new System.Drawing.Size(23, 22);
            this.tlStpbtnnew.Text = "New DB";
            this.tlStpbtnnew.Click += new System.EventHandler(this.tlStpbtnnew_Click);
            // 
            // tlstrpbtnconnect
            // 
            this.tlstrpbtnconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnconnect.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpbtnconnect.Image")));
            this.tlstrpbtnconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnconnect.Name = "tlstrpbtnconnect";
            this.tlstrpbtnconnect.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnconnect.Text = "connect";
            this.tlstrpbtnconnect.Click += new System.EventHandler(this.tlstrpbtnconnect_Click);
            // 
            // tlStrpClose
            // 
            this.tlStrpClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpClose.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpClose.Image")));
            this.tlStrpClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpClose.Name = "tlStrpClose";
            this.tlStrpClose.Size = new System.Drawing.Size(23, 22);
            this.tlStrpClose.Text = "Close connection";
            this.tlStrpClose.Click += new System.EventHandler(this.tlStrpClose_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(982, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBar
            // 
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(50, 20);
            this.StatusBar.Text = "Ready";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 435);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 42);
            this.panel2.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(775, 7);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(883, 7);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 28);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnExecute);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.rchtxtQuery);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(974, 420);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Custom Query";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(629, 281);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(143, 28);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute Query";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query:";
            // 
            // rchtxtQuery
            // 
            this.rchtxtQuery.Location = new System.Drawing.Point(212, 100);
            this.rchtxtQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rchtxtQuery.Name = "rchtxtQuery";
            this.rchtxtQuery.Size = new System.Drawing.Size(559, 153);
            this.rchtxtQuery.TabIndex = 0;
            this.rchtxtQuery.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkprimary);
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnCreate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.typecombo);
            this.tabPage2.Controls.Add(this.txtcolumnname);
            this.tabPage2.Controls.Add(this.txttablename);
            this.tabPage2.Controls.Add(this.rchtxtCreate);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(974, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkprimary
            // 
            this.chkprimary.AutoSize = true;
            this.chkprimary.Checked = true;
            this.chkprimary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkprimary.Location = new System.Drawing.Point(528, 94);
            this.chkprimary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkprimary.Name = "chkprimary";
            this.chkprimary.Size = new System.Drawing.Size(104, 21);
            this.chkprimary.TabIndex = 12;
            this.chkprimary.Text = "Primary Key";
            this.chkprimary.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(773, 404);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 28);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(257, 204);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(110, 28);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create Table ";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(528, 142);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 28);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Column";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // typecombo
            // 
            this.typecombo.FormattingEnabled = true;
            this.typecombo.Items.AddRange(new object[] {
            "AUTO_INCREMENT",
            "INT",
            "INTEGER",
            "TINYINT",
            "SMALLINT",
            "MEDIUMINT",
            "BIGINT",
            "UNSIGNED BIG INT",
            "CHARACTER(20)",
            "VARCHAR(255)",
            "REAL",
            "DOUBLE",
            "DOUBLE PRECISION",
            "FLOAT",
            "NUMERIC",
            "DECIMAL(10,5)",
            "BOOLEAN",
            "DATE",
            "DATETIME"});
            this.typecombo.Location = new System.Drawing.Point(313, 144);
            this.typecombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typecombo.Name = "typecombo";
            this.typecombo.Size = new System.Drawing.Size(184, 24);
            this.typecombo.TabIndex = 6;
            // 
            // txtcolumnname
            // 
            this.txtcolumnname.Location = new System.Drawing.Point(313, 89);
            this.txtcolumnname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcolumnname.Name = "txtcolumnname";
            this.txtcolumnname.Size = new System.Drawing.Size(184, 24);
            this.txtcolumnname.TabIndex = 5;
            // 
            // txttablename
            // 
            this.txttablename.Location = new System.Drawing.Point(313, 34);
            this.txttablename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttablename.Name = "txttablename";
            this.txttablename.Size = new System.Drawing.Size(184, 24);
            this.txttablename.TabIndex = 4;
            // 
            // rchtxtCreate
            // 
            this.rchtxtCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rchtxtCreate.Location = new System.Drawing.Point(133, 302);
            this.rchtxtCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rchtxtCreate.Name = "rchtxtCreate";
            this.rchtxtCreate.ReadOnly = true;
            this.rchtxtCreate.Size = new System.Drawing.Size(620, 130);
            this.rchtxtCreate.TabIndex = 1;
            this.rchtxtCreate.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Column Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Column Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Table Name:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userDataGridView);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(974, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // userDataGridView
            // 
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDataGridView.Location = new System.Drawing.Point(197, 4);
            this.userDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.RowTemplate.Height = 26;
            this.userDataGridView.Size = new System.Drawing.Size(774, 412);
            this.userDataGridView.TabIndex = 8;
            this.userDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDataGridView_CellMouseUp);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.new_database);
            this.panel3.Controls.Add(this.tablecombobox);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.lblAvailable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 412);
            this.panel3.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(110, 191);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "enter new database name";
            this.label6.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 191);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // new_database
            // 
            this.new_database.Location = new System.Drawing.Point(9, 148);
            this.new_database.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.new_database.Name = "new_database";
            this.new_database.Size = new System.Drawing.Size(174, 24);
            this.new_database.TabIndex = 4;
            this.new_database.Visible = false;
            // 
            // tablecombobox
            // 
            this.tablecombobox.FormattingEnabled = true;
            this.tablecombobox.Location = new System.Drawing.Point(6, 31);
            this.tablecombobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tablecombobox.Name = "tablecombobox";
            this.tablecombobox.Size = new System.Drawing.Size(178, 24);
            this.tablecombobox.TabIndex = 3;
            this.tablecombobox.SelectedIndexChanged += new System.EventHandler(this.tablecombobox_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(22, 70);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(128, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Table";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.ForeColor = System.Drawing.Color.Black;
            this.lblAvailable.Location = new System.Drawing.Point(6, 11);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(87, 17);
            this.lblAvailable.TabIndex = 2;
            this.lblAvailable.Text = "Tables in DB:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 449);
            this.tabControl1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 28);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
            this.toolStripMenuItem1.Text = "Delete Row";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tlStrpmain);
            this.Controls.Add(this.mnuStripmain);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.mnuStripmain.ResumeLayout(false);
            this.mnuStripmain.PerformLayout();
            this.tlStrpmain.ResumeLayout(false);
            this.tlStrpmain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStripmain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripHelp;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tlStrpmain;
        private System.Windows.Forms.ToolStripButton tlStpbtnnew;
        private System.Windows.Forms.ToolStripButton tlstrpbtnconnect;
        private System.Windows.Forms.ToolStripButton tlStrpClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchtxtQuery;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkprimary;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox typecombo;
        private System.Windows.Forms.TextBox txtcolumnname;
        private System.Windows.Forms.TextBox txttablename;
        private System.Windows.Forms.RichTextBox rchtxtCreate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox tablecombobox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox new_database;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}