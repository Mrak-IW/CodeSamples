namespace Lab2
{
	partial class Form1
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.BTN_1Reset = new System.Windows.Forms.Button();
			this.LBL_numProc = new System.Windows.Forms.Label();
			this.BTN_1RightProcess = new System.Windows.Forms.Button();
			this.BTN_1LeftProcess = new System.Windows.Forms.Button();
			this.LB_1Right = new System.Windows.Forms.ListBox();
			this.LB_1Left = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.CB_2Right = new System.Windows.Forms.CheckBox();
			this.CB_2Left = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BTN_2Reset = new System.Windows.Forms.Button();
			this.BTN_2Right = new System.Windows.Forms.Button();
			this.BTN_2Left = new System.Windows.Forms.Button();
			this.LB_2Right = new System.Windows.Forms.ListBox();
			this.LB_2Left = new System.Windows.Forms.ListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.LBL_PnumProc = new System.Windows.Forms.Label();
			this.ChB_Pinproc1 = new System.Windows.Forms.CheckBox();
			this.ChB_Pinproc0 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BTN_ResetPeterson = new System.Windows.Forms.Button();
			this.BTN_PRight = new System.Windows.Forms.Button();
			this.BTN_PLeft = new System.Windows.Forms.Button();
			this.LB_PRight = new System.Windows.Forms.ListBox();
			this.LB_PLeft = new System.Windows.Forms.ListBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.BTN_semReset = new System.Windows.Forms.Button();
			this.Lbl_Semaphore = new System.Windows.Forms.Label();
			this.BTN_semRight = new System.Windows.Forms.Button();
			this.BTN_semLeft = new System.Windows.Forms.Button();
			this.LB_SemLeft = new System.Windows.Forms.ListBox();
			this.LB_SemRight = new System.Windows.Forms.ListBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.CB_PCsmf2 = new System.Windows.Forms.CheckBox();
			this.CB_PCSmf = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.BTN_PCReset = new System.Windows.Forms.Button();
			this.BTN_PCRight = new System.Windows.Forms.Button();
			this.BTN_PCLeft = new System.Windows.Forms.Button();
			this.LB_PCLeft = new System.Windows.Forms.ListBox();
			this.LB_PCRight = new System.Windows.Forms.ListBox();
			this.LBL_PCresCount = new System.Windows.Forms.Label();
			this.LBL_PCLeft = new System.Windows.Forms.Label();
			this.LBL_PCRight = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(2, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(444, 361);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Transparent;
			this.tabPage1.Controls.Add(this.BTN_1Reset);
			this.tabPage1.Controls.Add(this.LBL_numProc);
			this.tabPage1.Controls.Add(this.BTN_1RightProcess);
			this.tabPage1.Controls.Add(this.BTN_1LeftProcess);
			this.tabPage1.Controls.Add(this.LB_1Right);
			this.tabPage1.Controls.Add(this.LB_1Left);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(436, 335);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Метод 1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// BTN_1Reset
			// 
			this.BTN_1Reset.Location = new System.Drawing.Point(129, 296);
			this.BTN_1Reset.Name = "BTN_1Reset";
			this.BTN_1Reset.Size = new System.Drawing.Size(75, 23);
			this.BTN_1Reset.TabIndex = 9;
			this.BTN_1Reset.Text = "Сброс";
			this.BTN_1Reset.UseVisualStyleBackColor = true;
			this.BTN_1Reset.Click += new System.EventHandler(this.BTN_1Reset_Click);
			// 
			// LBL_numProc
			// 
			this.LBL_numProc.Location = new System.Drawing.Point(88, 212);
			this.LBL_numProc.Name = "LBL_numProc";
			this.LBL_numProc.Size = new System.Drawing.Size(164, 21);
			this.LBL_numProc.TabIndex = 8;
			this.LBL_numProc.Text = "numProc = 0";
			this.LBL_numProc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// BTN_1RightProcess
			// 
			this.BTN_1RightProcess.Location = new System.Drawing.Point(258, 211);
			this.BTN_1RightProcess.Name = "BTN_1RightProcess";
			this.BTN_1RightProcess.Size = new System.Drawing.Size(75, 23);
			this.BTN_1RightProcess.TabIndex = 7;
			this.BTN_1RightProcess.Text = "V";
			this.BTN_1RightProcess.UseVisualStyleBackColor = true;
			this.BTN_1RightProcess.Click += new System.EventHandler(this.BTN_1RightProcess_Click);
			// 
			// BTN_1LeftProcess
			// 
			this.BTN_1LeftProcess.Location = new System.Drawing.Point(7, 212);
			this.BTN_1LeftProcess.Name = "BTN_1LeftProcess";
			this.BTN_1LeftProcess.Size = new System.Drawing.Size(75, 23);
			this.BTN_1LeftProcess.TabIndex = 6;
			this.BTN_1LeftProcess.Text = "V";
			this.BTN_1LeftProcess.UseVisualStyleBackColor = true;
			this.BTN_1LeftProcess.Click += new System.EventHandler(this.BTN_1LeftProcess_Click);
			// 
			// LB_1Right
			// 
			this.LB_1Right.FormattingEnabled = true;
			this.LB_1Right.Location = new System.Drawing.Point(170, 6);
			this.LB_1Right.Name = "LB_1Right";
			this.LB_1Right.Size = new System.Drawing.Size(163, 199);
			this.LB_1Right.TabIndex = 4;
			// 
			// LB_1Left
			// 
			this.LB_1Left.FormattingEnabled = true;
			this.LB_1Left.Location = new System.Drawing.Point(6, 6);
			this.LB_1Left.Name = "LB_1Left";
			this.LB_1Left.Size = new System.Drawing.Size(158, 199);
			this.LB_1Left.TabIndex = 5;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.Transparent;
			this.tabPage2.Controls.Add(this.CB_2Right);
			this.tabPage2.Controls.Add(this.CB_2Left);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.BTN_2Reset);
			this.tabPage2.Controls.Add(this.BTN_2Right);
			this.tabPage2.Controls.Add(this.BTN_2Left);
			this.tabPage2.Controls.Add(this.LB_2Right);
			this.tabPage2.Controls.Add(this.LB_2Left);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(436, 335);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Метод 2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// CB_2Right
			// 
			this.CB_2Right.AutoSize = true;
			this.CB_2Right.Location = new System.Drawing.Point(129, 238);
			this.CB_2Right.Name = "CB_2Right";
			this.CB_2Right.Size = new System.Drawing.Size(68, 17);
			this.CB_2Right.TabIndex = 19;
			this.CB_2Right.Text = "inProc[1]";
			this.CB_2Right.UseVisualStyleBackColor = true;
			// 
			// CB_2Left
			// 
			this.CB_2Left.AutoSize = true;
			this.CB_2Left.Location = new System.Drawing.Point(129, 215);
			this.CB_2Left.Name = "CB_2Left";
			this.CB_2Left.Size = new System.Drawing.Size(68, 17);
			this.CB_2Left.TabIndex = 19;
			this.CB_2Left.Text = "inProc[0]";
			this.CB_2Left.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(255, 277);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "label1";
			// 
			// BTN_2Reset
			// 
			this.BTN_2Reset.Location = new System.Drawing.Point(129, 296);
			this.BTN_2Reset.Name = "BTN_2Reset";
			this.BTN_2Reset.Size = new System.Drawing.Size(75, 23);
			this.BTN_2Reset.TabIndex = 15;
			this.BTN_2Reset.Text = "Сброс";
			this.BTN_2Reset.UseVisualStyleBackColor = true;
			this.BTN_2Reset.Click += new System.EventHandler(this.BTN_2Reset_Click);
			// 
			// BTN_2Right
			// 
			this.BTN_2Right.Location = new System.Drawing.Point(258, 211);
			this.BTN_2Right.Name = "BTN_2Right";
			this.BTN_2Right.Size = new System.Drawing.Size(75, 23);
			this.BTN_2Right.TabIndex = 13;
			this.BTN_2Right.Text = "V";
			this.BTN_2Right.UseVisualStyleBackColor = true;
			this.BTN_2Right.Click += new System.EventHandler(this.BTN_2Right_Click);
			// 
			// BTN_2Left
			// 
			this.BTN_2Left.Location = new System.Drawing.Point(7, 212);
			this.BTN_2Left.Name = "BTN_2Left";
			this.BTN_2Left.Size = new System.Drawing.Size(75, 23);
			this.BTN_2Left.TabIndex = 12;
			this.BTN_2Left.Text = "V";
			this.BTN_2Left.UseVisualStyleBackColor = true;
			this.BTN_2Left.Click += new System.EventHandler(this.BTN_2Left_Click);
			// 
			// LB_2Right
			// 
			this.LB_2Right.FormattingEnabled = true;
			this.LB_2Right.Location = new System.Drawing.Point(170, 6);
			this.LB_2Right.Name = "LB_2Right";
			this.LB_2Right.Size = new System.Drawing.Size(163, 199);
			this.LB_2Right.TabIndex = 10;
			this.LB_2Right.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
			// 
			// LB_2Left
			// 
			this.LB_2Left.FormattingEnabled = true;
			this.LB_2Left.Location = new System.Drawing.Point(6, 6);
			this.LB_2Left.Name = "LB_2Left";
			this.LB_2Left.Size = new System.Drawing.Size(158, 199);
			this.LB_2Left.TabIndex = 11;
			this.LB_2Left.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Transparent;
			this.tabPage3.Controls.Add(this.LBL_PnumProc);
			this.tabPage3.Controls.Add(this.ChB_Pinproc1);
			this.tabPage3.Controls.Add(this.ChB_Pinproc0);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.BTN_ResetPeterson);
			this.tabPage3.Controls.Add(this.BTN_PRight);
			this.tabPage3.Controls.Add(this.BTN_PLeft);
			this.tabPage3.Controls.Add(this.LB_PRight);
			this.tabPage3.Controls.Add(this.LB_PLeft);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(436, 335);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Петерсон";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// LBL_PnumProc
			// 
			this.LBL_PnumProc.AutoSize = true;
			this.LBL_PnumProc.Location = new System.Drawing.Point(126, 261);
			this.LBL_PnumProc.Name = "LBL_PnumProc";
			this.LBL_PnumProc.Size = new System.Drawing.Size(35, 13);
			this.LBL_PnumProc.TabIndex = 28;
			this.LBL_PnumProc.Text = "label3";
			// 
			// ChB_Pinproc1
			// 
			this.ChB_Pinproc1.AutoSize = true;
			this.ChB_Pinproc1.Location = new System.Drawing.Point(129, 238);
			this.ChB_Pinproc1.Name = "ChB_Pinproc1";
			this.ChB_Pinproc1.Size = new System.Drawing.Size(68, 17);
			this.ChB_Pinproc1.TabIndex = 26;
			this.ChB_Pinproc1.Text = "inProc[1]";
			this.ChB_Pinproc1.UseVisualStyleBackColor = true;
			// 
			// ChB_Pinproc0
			// 
			this.ChB_Pinproc0.AutoSize = true;
			this.ChB_Pinproc0.Location = new System.Drawing.Point(129, 215);
			this.ChB_Pinproc0.Name = "ChB_Pinproc0";
			this.ChB_Pinproc0.Size = new System.Drawing.Size(68, 17);
			this.ChB_Pinproc0.TabIndex = 27;
			this.ChB_Pinproc0.Text = "inProc[0]";
			this.ChB_Pinproc0.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(255, 277);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 25;
			this.label2.Text = "label2";
			// 
			// BTN_ResetPeterson
			// 
			this.BTN_ResetPeterson.Location = new System.Drawing.Point(129, 296);
			this.BTN_ResetPeterson.Name = "BTN_ResetPeterson";
			this.BTN_ResetPeterson.Size = new System.Drawing.Size(75, 23);
			this.BTN_ResetPeterson.TabIndex = 24;
			this.BTN_ResetPeterson.Text = "Сброс";
			this.BTN_ResetPeterson.UseVisualStyleBackColor = true;
			this.BTN_ResetPeterson.Click += new System.EventHandler(this.BTN_ResetPeterson_Click);
			// 
			// BTN_PRight
			// 
			this.BTN_PRight.Location = new System.Drawing.Point(258, 211);
			this.BTN_PRight.Name = "BTN_PRight";
			this.BTN_PRight.Size = new System.Drawing.Size(75, 23);
			this.BTN_PRight.TabIndex = 23;
			this.BTN_PRight.Text = "V";
			this.BTN_PRight.UseVisualStyleBackColor = true;
			this.BTN_PRight.Click += new System.EventHandler(this.BTN_PRight_Click);
			// 
			// BTN_PLeft
			// 
			this.BTN_PLeft.Location = new System.Drawing.Point(7, 212);
			this.BTN_PLeft.Name = "BTN_PLeft";
			this.BTN_PLeft.Size = new System.Drawing.Size(75, 23);
			this.BTN_PLeft.TabIndex = 22;
			this.BTN_PLeft.Text = "V";
			this.BTN_PLeft.UseVisualStyleBackColor = true;
			this.BTN_PLeft.Click += new System.EventHandler(this.BTN_PLeft_Click);
			// 
			// LB_PRight
			// 
			this.LB_PRight.FormattingEnabled = true;
			this.LB_PRight.Location = new System.Drawing.Point(218, 6);
			this.LB_PRight.Name = "LB_PRight";
			this.LB_PRight.Size = new System.Drawing.Size(214, 199);
			this.LB_PRight.TabIndex = 20;
			// 
			// LB_PLeft
			// 
			this.LB_PLeft.FormattingEnabled = true;
			this.LB_PLeft.Location = new System.Drawing.Point(6, 6);
			this.LB_PLeft.Name = "LB_PLeft";
			this.LB_PLeft.Size = new System.Drawing.Size(210, 199);
			this.LB_PLeft.TabIndex = 21;
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.Transparent;
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Controls.Add(this.BTN_semReset);
			this.tabPage4.Controls.Add(this.Lbl_Semaphore);
			this.tabPage4.Controls.Add(this.BTN_semRight);
			this.tabPage4.Controls.Add(this.BTN_semLeft);
			this.tabPage4.Controls.Add(this.LB_SemLeft);
			this.tabPage4.Controls.Add(this.LB_SemRight);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(436, 335);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Семафор";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(255, 296);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "label4";
			// 
			// BTN_semReset
			// 
			this.BTN_semReset.Location = new System.Drawing.Point(129, 296);
			this.BTN_semReset.Name = "BTN_semReset";
			this.BTN_semReset.Size = new System.Drawing.Size(75, 23);
			this.BTN_semReset.TabIndex = 15;
			this.BTN_semReset.Text = "Сброс";
			this.BTN_semReset.UseVisualStyleBackColor = true;
			this.BTN_semReset.Click += new System.EventHandler(this.Btn_semReset_Click);
			// 
			// Lbl_Semaphore
			// 
			this.Lbl_Semaphore.Location = new System.Drawing.Point(88, 212);
			this.Lbl_Semaphore.Name = "Lbl_Semaphore";
			this.Lbl_Semaphore.Size = new System.Drawing.Size(164, 21);
			this.Lbl_Semaphore.TabIndex = 14;
			this.Lbl_Semaphore.Text = "semaphore = 1";
			this.Lbl_Semaphore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// BTN_semRight
			// 
			this.BTN_semRight.Location = new System.Drawing.Point(258, 211);
			this.BTN_semRight.Name = "BTN_semRight";
			this.BTN_semRight.Size = new System.Drawing.Size(75, 23);
			this.BTN_semRight.TabIndex = 13;
			this.BTN_semRight.Text = "V";
			this.BTN_semRight.UseVisualStyleBackColor = true;
			this.BTN_semRight.Click += new System.EventHandler(this.Btn_semRight_Click);
			// 
			// BTN_semLeft
			// 
			this.BTN_semLeft.Location = new System.Drawing.Point(7, 212);
			this.BTN_semLeft.Name = "BTN_semLeft";
			this.BTN_semLeft.Size = new System.Drawing.Size(75, 23);
			this.BTN_semLeft.TabIndex = 12;
			this.BTN_semLeft.Text = "V";
			this.BTN_semLeft.UseVisualStyleBackColor = true;
			this.BTN_semLeft.Click += new System.EventHandler(this.Btn_semLeft_Click);
			// 
			// LB_SemLeft
			// 
			this.LB_SemLeft.FormattingEnabled = true;
			this.LB_SemLeft.Location = new System.Drawing.Point(6, 6);
			this.LB_SemLeft.Name = "LB_SemLeft";
			this.LB_SemLeft.Size = new System.Drawing.Size(158, 199);
			this.LB_SemLeft.TabIndex = 10;
			// 
			// LB_SemRight
			// 
			this.LB_SemRight.FormattingEnabled = true;
			this.LB_SemRight.Location = new System.Drawing.Point(170, 6);
			this.LB_SemRight.Name = "LB_SemRight";
			this.LB_SemRight.Size = new System.Drawing.Size(163, 199);
			this.LB_SemRight.TabIndex = 11;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.LBL_PCRight);
			this.tabPage5.Controls.Add(this.LBL_PCLeft);
			this.tabPage5.Controls.Add(this.LBL_PCresCount);
			this.tabPage5.Controls.Add(this.CB_PCsmf2);
			this.tabPage5.Controls.Add(this.CB_PCSmf);
			this.tabPage5.Controls.Add(this.label5);
			this.tabPage5.Controls.Add(this.BTN_PCReset);
			this.tabPage5.Controls.Add(this.BTN_PCRight);
			this.tabPage5.Controls.Add(this.BTN_PCLeft);
			this.tabPage5.Controls.Add(this.LB_PCLeft);
			this.tabPage5.Controls.Add(this.LB_PCRight);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(436, 335);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Произв-потреб";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// CB_PCsmf2
			// 
			this.CB_PCsmf2.AutoSize = true;
			this.CB_PCsmf2.Location = new System.Drawing.Point(129, 238);
			this.CB_PCsmf2.Name = "CB_PCsmf2";
			this.CB_PCsmf2.Size = new System.Drawing.Size(50, 17);
			this.CB_PCsmf2.TabIndex = 34;
			this.CB_PCsmf2.Text = "Smf2";
			this.CB_PCsmf2.UseVisualStyleBackColor = true;
			// 
			// CB_PCSmf
			// 
			this.CB_PCSmf.AutoSize = true;
			this.CB_PCSmf.Location = new System.Drawing.Point(129, 215);
			this.CB_PCSmf.Name = "CB_PCSmf";
			this.CB_PCSmf.Size = new System.Drawing.Size(44, 17);
			this.CB_PCSmf.TabIndex = 35;
			this.CB_PCSmf.Text = "Smf";
			this.CB_PCSmf.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(255, 296);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 33;
			this.label5.Text = "label5";
			// 
			// BTN_PCReset
			// 
			this.BTN_PCReset.Location = new System.Drawing.Point(129, 296);
			this.BTN_PCReset.Name = "BTN_PCReset";
			this.BTN_PCReset.Size = new System.Drawing.Size(75, 23);
			this.BTN_PCReset.TabIndex = 32;
			this.BTN_PCReset.Text = "Сброс";
			this.BTN_PCReset.UseVisualStyleBackColor = true;
			this.BTN_PCReset.Click += new System.EventHandler(this.BTN_PCReset_Click);
			// 
			// BTN_PCRight
			// 
			this.BTN_PCRight.Location = new System.Drawing.Point(258, 211);
			this.BTN_PCRight.Name = "BTN_PCRight";
			this.BTN_PCRight.Size = new System.Drawing.Size(75, 23);
			this.BTN_PCRight.TabIndex = 30;
			this.BTN_PCRight.Text = "V";
			this.BTN_PCRight.UseVisualStyleBackColor = true;
			this.BTN_PCRight.Click += new System.EventHandler(this.BTN_PCRight_Click);
			// 
			// BTN_PCLeft
			// 
			this.BTN_PCLeft.Location = new System.Drawing.Point(7, 212);
			this.BTN_PCLeft.Name = "BTN_PCLeft";
			this.BTN_PCLeft.Size = new System.Drawing.Size(75, 23);
			this.BTN_PCLeft.TabIndex = 29;
			this.BTN_PCLeft.Text = "V";
			this.BTN_PCLeft.UseVisualStyleBackColor = true;
			this.BTN_PCLeft.Click += new System.EventHandler(this.BTN_PCLeft_Click);
			// 
			// LB_PCLeft
			// 
			this.LB_PCLeft.FormattingEnabled = true;
			this.LB_PCLeft.Location = new System.Drawing.Point(6, 32);
			this.LB_PCLeft.Name = "LB_PCLeft";
			this.LB_PCLeft.Size = new System.Drawing.Size(158, 173);
			this.LB_PCLeft.TabIndex = 27;
			// 
			// LB_PCRight
			// 
			this.LB_PCRight.FormattingEnabled = true;
			this.LB_PCRight.Location = new System.Drawing.Point(170, 32);
			this.LB_PCRight.Name = "LB_PCRight";
			this.LB_PCRight.Size = new System.Drawing.Size(163, 173);
			this.LB_PCRight.TabIndex = 28;
			// 
			// LBL_PCresCount
			// 
			this.LBL_PCresCount.AutoSize = true;
			this.LBL_PCresCount.Location = new System.Drawing.Point(129, 262);
			this.LBL_PCresCount.Name = "LBL_PCresCount";
			this.LBL_PCresCount.Size = new System.Drawing.Size(49, 13);
			this.LBL_PCresCount.TabIndex = 36;
			this.LBL_PCresCount.Text = "resCount";
			// 
			// LBL_PCLeft
			// 
			this.LBL_PCLeft.AutoSize = true;
			this.LBL_PCLeft.Location = new System.Drawing.Point(3, 13);
			this.LBL_PCLeft.Name = "LBL_PCLeft";
			this.LBL_PCLeft.Size = new System.Drawing.Size(86, 13);
			this.LBL_PCLeft.TabIndex = 37;
			this.LBL_PCLeft.Text = "Производитель";
			// 
			// LBL_PCRight
			// 
			this.LBL_PCRight.AutoSize = true;
			this.LBL_PCRight.Location = new System.Drawing.Point(170, 13);
			this.LBL_PCRight.Name = "LBL_PCRight";
			this.LBL_PCRight.Size = new System.Drawing.Size(73, 13);
			this.LBL_PCRight.TabIndex = 38;
			this.LBL_PCRight.Text = "Потребитель";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 362);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "Примеры алгоритмов";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BTN_1Reset;
        private System.Windows.Forms.Label LBL_numProc;
        private System.Windows.Forms.Button BTN_1RightProcess;
        private System.Windows.Forms.Button BTN_1LeftProcess;
        private System.Windows.Forms.ListBox LB_1Right;
        private System.Windows.Forms.ListBox LB_1Left;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BTN_2Reset;
        private System.Windows.Forms.Button BTN_2Right;
        private System.Windows.Forms.Button BTN_2Left;
        private System.Windows.Forms.ListBox LB_2Right;
        private System.Windows.Forms.ListBox LB_2Left;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox CB_2Right;
		private System.Windows.Forms.CheckBox CB_2Left;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox ChB_Pinproc1;
        private System.Windows.Forms.CheckBox ChB_Pinproc0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_ResetPeterson;
        private System.Windows.Forms.Button BTN_PRight;
        private System.Windows.Forms.Button BTN_PLeft;
        private System.Windows.Forms.ListBox LB_PRight;
        private System.Windows.Forms.ListBox LB_PLeft;
        private System.Windows.Forms.Label LBL_PnumProc;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button BTN_semReset;
        private System.Windows.Forms.Label Lbl_Semaphore;
        private System.Windows.Forms.Button BTN_semRight;
        private System.Windows.Forms.Button BTN_semLeft;
        private System.Windows.Forms.ListBox LB_SemLeft;
        private System.Windows.Forms.ListBox LB_SemRight;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button BTN_PCReset;
		private System.Windows.Forms.Button BTN_PCRight;
		private System.Windows.Forms.Button BTN_PCLeft;
		private System.Windows.Forms.ListBox LB_PCLeft;
		private System.Windows.Forms.ListBox LB_PCRight;
		private System.Windows.Forms.CheckBox CB_PCsmf2;
		private System.Windows.Forms.CheckBox CB_PCSmf;
		private System.Windows.Forms.Label LBL_PCresCount;
		private System.Windows.Forms.Label LBL_PCRight;
		private System.Windows.Forms.Label LBL_PCLeft;

    }
}

