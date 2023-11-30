namespace WindowsFormsApplication6
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSector = new System.Windows.Forms.Label();
            this.lbBlock = new System.Windows.Forms.Label();
            this.lbKeyab = new System.Windows.Forms.Label();
            this.lbLoadkey = new System.Windows.Forms.Label();
            this.combSector = new System.Windows.Forms.ComboBox();
            this.combBlock = new System.Windows.Forms.ComboBox();
            this.combKeyab = new System.Windows.Forms.ComboBox();
            this.txtLoadkey = new System.Windows.Forms.TextBox();
            this.txtIdenity = new System.Windows.Forms.TextBox();
            this.btnReaddata = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearCard_Issue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateCard_Issue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemberCredit_Issue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemberApplyDate_Issue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMemberName_Issue = new System.Windows.Forms.TextBox();
            this.txtMemberNo_Issue = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReadCard_Inquery = new System.Windows.Forms.Button();
            this.txtMemberCredit_Inquery = new System.Windows.Forms.TextBox();
            this.txtMemberApplyDate_Inquery = new System.Windows.Forms.TextBox();
            this.txtMemberName_Inquery = new System.Windows.Forms.TextBox();
            this.txtMemberNo_Inquery = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.txtMemberCredit_Recharge = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnConsume = new System.Windows.Forms.Button();
            this.txtMemberCredit_Consume = new System.Windows.Forms.TextBox();
            this.btnWritedata = new System.Windows.Forms.Button();
            this.txtWriteData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(462, 560);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 34);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbSector
            // 
            this.lbSector.AutoSize = true;
            this.lbSector.Font = new System.Drawing.Font("新細明體", 12F);
            this.lbSector.Location = new System.Drawing.Point(13, 34);
            this.lbSector.Name = "lbSector";
            this.lbSector.Size = new System.Drawing.Size(68, 24);
            this.lbSector.TabIndex = 12;
            this.lbSector.Text = "Sector";
            // 
            // lbBlock
            // 
            this.lbBlock.AutoSize = true;
            this.lbBlock.Font = new System.Drawing.Font("新細明體", 12F);
            this.lbBlock.Location = new System.Drawing.Point(130, 34);
            this.lbBlock.Name = "lbBlock";
            this.lbBlock.Size = new System.Drawing.Size(63, 24);
            this.lbBlock.TabIndex = 13;
            this.lbBlock.Text = "Block";
            // 
            // lbKeyab
            // 
            this.lbKeyab.AutoSize = true;
            this.lbKeyab.Font = new System.Drawing.Font("新細明體", 12F);
            this.lbKeyab.Location = new System.Drawing.Point(243, 34);
            this.lbKeyab.Name = "lbKeyab";
            this.lbKeyab.Size = new System.Drawing.Size(78, 24);
            this.lbKeyab.TabIndex = 14;
            this.lbKeyab.Text = "KeyAB";
            // 
            // lbLoadkey
            // 
            this.lbLoadkey.AutoSize = true;
            this.lbLoadkey.Font = new System.Drawing.Font("新細明體", 12F);
            this.lbLoadkey.Location = new System.Drawing.Point(355, 34);
            this.lbLoadkey.Name = "lbLoadkey";
            this.lbLoadkey.Size = new System.Drawing.Size(93, 24);
            this.lbLoadkey.TabIndex = 15;
            this.lbLoadkey.Text = "LoadKey";
            // 
            // combSector
            // 
            this.combSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSector.Font = new System.Drawing.Font("新細明體", 12F);
            this.combSector.FormattingEnabled = true;
            this.combSector.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.combSector.Location = new System.Drawing.Point(16, 67);
            this.combSector.Name = "combSector";
            this.combSector.Size = new System.Drawing.Size(87, 32);
            this.combSector.TabIndex = 16;
            this.combSector.SelectedIndexChanged += new System.EventHandler(this.valueChangeCheck);
            // 
            // combBlock
            // 
            this.combBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBlock.Font = new System.Drawing.Font("新細明體", 12F);
            this.combBlock.FormattingEnabled = true;
            this.combBlock.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03"});
            this.combBlock.Location = new System.Drawing.Point(133, 67);
            this.combBlock.Name = "combBlock";
            this.combBlock.Size = new System.Drawing.Size(87, 32);
            this.combBlock.TabIndex = 17;
            this.combBlock.SelectedIndexChanged += new System.EventHandler(this.valueChangeCheck);
            // 
            // combKeyab
            // 
            this.combKeyab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combKeyab.Font = new System.Drawing.Font("新細明體", 12F);
            this.combKeyab.FormattingEnabled = true;
            this.combKeyab.Items.AddRange(new object[] {
            "A",
            "B"});
            this.combKeyab.Location = new System.Drawing.Point(246, 67);
            this.combKeyab.Name = "combKeyab";
            this.combKeyab.Size = new System.Drawing.Size(87, 32);
            this.combKeyab.TabIndex = 18;
            this.combKeyab.SelectedIndexChanged += new System.EventHandler(this.valueChangeCheck);
            // 
            // txtLoadkey
            // 
            this.txtLoadkey.Font = new System.Drawing.Font("新細明體", 12F);
            this.txtLoadkey.Location = new System.Drawing.Point(358, 64);
            this.txtLoadkey.Name = "txtLoadkey";
            this.txtLoadkey.Size = new System.Drawing.Size(205, 36);
            this.txtLoadkey.TabIndex = 19;
            this.txtLoadkey.Text = "FFFFFFFFFFFF";
            this.txtLoadkey.TextChanged += new System.EventHandler(this.valueChangeCheck);
            // 
            // txtIdenity
            // 
            this.txtIdenity.Font = new System.Drawing.Font("新細明體", 12F);
            this.txtIdenity.Location = new System.Drawing.Point(16, 117);
            this.txtIdenity.Name = "txtIdenity";
            this.txtIdenity.Size = new System.Drawing.Size(403, 36);
            this.txtIdenity.TabIndex = 20;
            // 
            // btnReaddata
            // 
            this.btnReaddata.Enabled = false;
            this.btnReaddata.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnReaddata.Location = new System.Drawing.Point(439, 119);
            this.btnReaddata.Margin = new System.Windows.Forms.Padding(4);
            this.btnReaddata.Name = "btnReaddata";
            this.btnReaddata.Size = new System.Drawing.Size(124, 34);
            this.btnReaddata.TabIndex = 21;
            this.btnReaddata.Text = "Read Data";
            this.btnReaddata.UseVisualStyleBackColor = true;
            this.btnReaddata.Click += new System.EventHandler(this.btnReaddata_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 248);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 305);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "發卡";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearCard_Issue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCreateCard_Issue);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMemberCredit_Issue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMemberApplyDate_Issue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMemberName_Issue);
            this.panel1.Controls.Add(this.txtMemberNo_Issue);
            this.panel1.Location = new System.Drawing.Point(20, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 328);
            this.panel1.TabIndex = 10;
            // 
            // btnClearCard_Issue
            // 
            this.btnClearCard_Issue.Location = new System.Drawing.Point(340, 83);
            this.btnClearCard_Issue.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCard_Issue.Name = "btnClearCard_Issue";
            this.btnClearCard_Issue.Size = new System.Drawing.Size(130, 45);
            this.btnClearCard_Issue.TabIndex = 9;
            this.btnClearCard_Issue.Text = "清空卡片";
            this.btnClearCard_Issue.UseVisualStyleBackColor = true;
            this.btnClearCard_Issue.Click += new System.EventHandler(this.btnClearCard_Issue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "會員編號:";
            // 
            // btnCreateCard_Issue
            // 
            this.btnCreateCard_Issue.Location = new System.Drawing.Point(340, 29);
            this.btnCreateCard_Issue.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateCard_Issue.Name = "btnCreateCard_Issue";
            this.btnCreateCard_Issue.Size = new System.Drawing.Size(130, 45);
            this.btnCreateCard_Issue.TabIndex = 8;
            this.btnCreateCard_Issue.Text = "卡片製作";
            this.btnCreateCard_Issue.UseVisualStyleBackColor = true;
            this.btnCreateCard_Issue.Click += new System.EventHandler(this.btnCreateCard_Issue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名:";
            // 
            // txtMemberCredit_Issue
            // 
            this.txtMemberCredit_Issue.Location = new System.Drawing.Point(141, 183);
            this.txtMemberCredit_Issue.Name = "txtMemberCredit_Issue";
            this.txtMemberCredit_Issue.Size = new System.Drawing.Size(134, 36);
            this.txtMemberCredit_Issue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "申請日期:";
            // 
            // txtMemberApplyDate_Issue
            // 
            this.txtMemberApplyDate_Issue.Location = new System.Drawing.Point(141, 133);
            this.txtMemberApplyDate_Issue.Name = "txtMemberApplyDate_Issue";
            this.txtMemberApplyDate_Issue.Size = new System.Drawing.Size(134, 36);
            this.txtMemberApplyDate_Issue.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "點數:";
            // 
            // txtMemberName_Issue
            // 
            this.txtMemberName_Issue.Location = new System.Drawing.Point(141, 81);
            this.txtMemberName_Issue.Name = "txtMemberName_Issue";
            this.txtMemberName_Issue.Size = new System.Drawing.Size(134, 36);
            this.txtMemberName_Issue.TabIndex = 5;
            // 
            // txtMemberNo_Issue
            // 
            this.txtMemberNo_Issue.Location = new System.Drawing.Point(141, 31);
            this.txtMemberNo_Issue.Name = "txtMemberNo_Issue";
            this.txtMemberNo_Issue.Size = new System.Drawing.Size(136, 36);
            this.txtMemberNo_Issue.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查詢";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnReadCard_Inquery);
            this.panel2.Controls.Add(this.txtMemberCredit_Inquery);
            this.panel2.Controls.Add(this.txtMemberApplyDate_Inquery);
            this.panel2.Controls.Add(this.txtMemberName_Inquery);
            this.panel2.Controls.Add(this.txtMemberNo_Inquery);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(20, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 328);
            this.panel2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "會員編號:";
            // 
            // btnReadCard_Inquery
            // 
            this.btnReadCard_Inquery.Location = new System.Drawing.Point(340, 29);
            this.btnReadCard_Inquery.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadCard_Inquery.Name = "btnReadCard_Inquery";
            this.btnReadCard_Inquery.Size = new System.Drawing.Size(130, 45);
            this.btnReadCard_Inquery.TabIndex = 8;
            this.btnReadCard_Inquery.Text = "查詢卡片";
            this.btnReadCard_Inquery.UseVisualStyleBackColor = true;
            this.btnReadCard_Inquery.Click += new System.EventHandler(this.btnReadCard_Inquery_Click);
            // 
            // txtMemberCredit_Inquery
            // 
            this.txtMemberCredit_Inquery.Location = new System.Drawing.Point(141, 183);
            this.txtMemberCredit_Inquery.Name = "txtMemberCredit_Inquery";
            this.txtMemberCredit_Inquery.ReadOnly = true;
            this.txtMemberCredit_Inquery.Size = new System.Drawing.Size(134, 36);
            this.txtMemberCredit_Inquery.TabIndex = 7;
            // 
            // txtMemberApplyDate_Inquery
            // 
            this.txtMemberApplyDate_Inquery.Location = new System.Drawing.Point(141, 133);
            this.txtMemberApplyDate_Inquery.Name = "txtMemberApplyDate_Inquery";
            this.txtMemberApplyDate_Inquery.ReadOnly = true;
            this.txtMemberApplyDate_Inquery.Size = new System.Drawing.Size(134, 36);
            this.txtMemberApplyDate_Inquery.TabIndex = 6;
            // 
            // txtMemberName_Inquery
            // 
            this.txtMemberName_Inquery.Location = new System.Drawing.Point(141, 81);
            this.txtMemberName_Inquery.Name = "txtMemberName_Inquery";
            this.txtMemberName_Inquery.ReadOnly = true;
            this.txtMemberName_Inquery.Size = new System.Drawing.Size(134, 36);
            this.txtMemberName_Inquery.TabIndex = 5;
            // 
            // txtMemberNo_Inquery
            // 
            this.txtMemberNo_Inquery.Location = new System.Drawing.Point(141, 31);
            this.txtMemberNo_Inquery.Name = "txtMemberNo_Inquery";
            this.txtMemberNo_Inquery.ReadOnly = true;
            this.txtMemberNo_Inquery.Size = new System.Drawing.Size(136, 36);
            this.txtMemberNo_Inquery.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "姓名:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "申請日期:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "點數:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(574, 267);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "儲值";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.btnRecharge);
            this.panel3.Controls.Add(this.txtMemberCredit_Recharge);
            this.panel3.Location = new System.Drawing.Point(20, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(674, 328);
            this.panel3.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "點數:";
            // 
            // btnRecharge
            // 
            this.btnRecharge.Location = new System.Drawing.Point(340, 29);
            this.btnRecharge.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(130, 45);
            this.btnRecharge.TabIndex = 8;
            this.btnRecharge.Text = "加值點數";
            this.btnRecharge.UseVisualStyleBackColor = true;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // txtMemberCredit_Recharge
            // 
            this.txtMemberCredit_Recharge.Location = new System.Drawing.Point(141, 31);
            this.txtMemberCredit_Recharge.Name = "txtMemberCredit_Recharge";
            this.txtMemberCredit_Recharge.Size = new System.Drawing.Size(136, 36);
            this.txtMemberCredit_Recharge.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(574, 267);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "消費";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.btnConsume);
            this.panel4.Controls.Add(this.txtMemberCredit_Consume);
            this.panel4.Location = new System.Drawing.Point(20, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(674, 328);
            this.panel4.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "點數:";
            // 
            // btnConsume
            // 
            this.btnConsume.Location = new System.Drawing.Point(340, 29);
            this.btnConsume.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsume.Name = "btnConsume";
            this.btnConsume.Size = new System.Drawing.Size(130, 45);
            this.btnConsume.TabIndex = 8;
            this.btnConsume.Text = "消費點數";
            this.btnConsume.UseVisualStyleBackColor = true;
            this.btnConsume.Click += new System.EventHandler(this.btnConsume_Click);
            // 
            // txtMemberCredit_Consume
            // 
            this.txtMemberCredit_Consume.Location = new System.Drawing.Point(141, 31);
            this.txtMemberCredit_Consume.Name = "txtMemberCredit_Consume";
            this.txtMemberCredit_Consume.Size = new System.Drawing.Size(136, 36);
            this.txtMemberCredit_Consume.TabIndex = 4;
            // 
            // btnWritedata
            // 
            this.btnWritedata.Enabled = false;
            this.btnWritedata.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnWritedata.Location = new System.Drawing.Point(439, 162);
            this.btnWritedata.Margin = new System.Windows.Forms.Padding(4);
            this.btnWritedata.Name = "btnWritedata";
            this.btnWritedata.Size = new System.Drawing.Size(124, 34);
            this.btnWritedata.TabIndex = 23;
            this.btnWritedata.Text = "Write Data";
            this.btnWritedata.UseVisualStyleBackColor = true;
            this.btnWritedata.Click += new System.EventHandler(this.btnWritedata_Click);
            // 
            // txtWriteData
            // 
            this.txtWriteData.Font = new System.Drawing.Font("新細明體", 12F);
            this.txtWriteData.Location = new System.Drawing.Point(16, 164);
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.Size = new System.Drawing.Size(403, 36);
            this.txtWriteData.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combKeyab);
            this.groupBox1.Controls.Add(this.txtWriteData);
            this.groupBox1.Controls.Add(this.lbSector);
            this.groupBox1.Controls.Add(this.btnWritedata);
            this.groupBox1.Controls.Add(this.lbBlock);
            this.groupBox1.Controls.Add(this.lbKeyab);
            this.groupBox1.Controls.Add(this.btnReaddata);
            this.groupBox1.Controls.Add(this.lbLoadkey);
            this.groupBox1.Controls.Add(this.txtIdenity);
            this.groupBox1.Controls.Add(this.combSector);
            this.groupBox1.Controls.Add(this.txtLoadkey);
            this.groupBox1.Controls.Add(this.combBlock);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 217);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ISO14443A";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button   btnClose;
        internal System.Windows.Forms.Label    lbSector;
        internal System.Windows.Forms.Label    lbBlock;
        internal System.Windows.Forms.Label    lbKeyab;
        internal System.Windows.Forms.Label    lbLoadkey;
        internal System.Windows.Forms.ComboBox combSector;
        internal System.Windows.Forms.ComboBox combBlock;
        internal System.Windows.Forms.ComboBox combKeyab;
        internal System.Windows.Forms.TextBox  txtLoadkey;
        internal System.Windows.Forms.TextBox  txtIdenity;
        internal System.Windows.Forms.Button   btnReaddata;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearCard_Issue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateCard_Issue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberCredit_Issue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMemberApplyDate_Issue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMemberName_Issue;
        private System.Windows.Forms.TextBox txtMemberNo_Issue;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReadCard_Inquery;
        private System.Windows.Forms.TextBox txtMemberCredit_Inquery;
        private System.Windows.Forms.TextBox txtMemberApplyDate_Inquery;
        private System.Windows.Forms.TextBox txtMemberName_Inquery;
        private System.Windows.Forms.TextBox txtMemberNo_Inquery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.TextBox txtMemberCredit_Recharge;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConsume;
        private System.Windows.Forms.TextBox txtMemberCredit_Consume;
        internal System.Windows.Forms.Button btnWritedata;
        internal System.Windows.Forms.TextBox txtWriteData;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

