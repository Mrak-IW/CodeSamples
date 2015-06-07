namespace MarkovChain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.TB_StartMatrix = new System.Windows.Forms.TextBox();
			this.BTN_Start = new System.Windows.Forms.Button();
			this.GB_StartData = new System.Windows.Forms.GroupBox();
			this.NUD_Pow = new System.Windows.Forms.NumericUpDown();
			this.LBL_Pow = new System.Windows.Forms.Label();
			this.NUD_StepCount = new System.Windows.Forms.NumericUpDown();
			this.CB_States = new System.Windows.Forms.ComboBox();
			this.LBL_StepCount = new System.Windows.Forms.Label();
			this.LBL_StartPosition = new System.Windows.Forms.Label();
			this.GB_PractData = new System.Windows.Forms.GroupBox();
			this.TB_PractMatrix = new System.Windows.Forms.TextBox();
			this.LB_Test = new System.Windows.Forms.ListBox();
			this.ErrP = new System.Windows.Forms.ErrorProvider(this.components);
			this.BTN_MatrixPow = new System.Windows.Forms.Button();
			this.SSTR_StatusRow = new System.Windows.Forms.StatusStrip();
			this.SSTRL_Label = new System.Windows.Forms.ToolStripStatusLabel();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.MMI_Options = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_TestCases = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.NUD_DispFirst = new System.Windows.Forms.NumericUpDown();
			this.LBL_DispFirst = new System.Windows.Forms.Label();
			this.MMI_Epur = new System.Windows.Forms.ToolStripMenuItem();
			this.GB_StartData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Pow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_StepCount)).BeginInit();
			this.GB_PractData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ErrP)).BeginInit();
			this.SSTR_StatusRow.SuspendLayout();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUD_DispFirst)).BeginInit();
			this.SuspendLayout();
			// 
			// TB_StartMatrix
			// 
			this.TB_StartMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TB_StartMatrix.Location = new System.Drawing.Point(6, 19);
			this.TB_StartMatrix.Multiline = true;
			this.TB_StartMatrix.Name = "TB_StartMatrix";
			this.TB_StartMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_StartMatrix.Size = new System.Drawing.Size(402, 147);
			this.TB_StartMatrix.TabIndex = 0;
			this.TB_StartMatrix.WordWrap = false;
			this.TB_StartMatrix.TextChanged += new System.EventHandler(this.TB_StartMatrix_TextChanged);
			this.TB_StartMatrix.Leave += new System.EventHandler(this.TB_StartMatrix_Leave);
			// 
			// BTN_Start
			// 
			this.BTN_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BTN_Start.Enabled = false;
			this.BTN_Start.Location = new System.Drawing.Point(507, 634);
			this.BTN_Start.Name = "BTN_Start";
			this.BTN_Start.Size = new System.Drawing.Size(75, 23);
			this.BTN_Start.TabIndex = 1;
			this.BTN_Start.Text = "Панеслася";
			this.BTN_Start.UseVisualStyleBackColor = true;
			this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
			// 
			// GB_StartData
			// 
			this.GB_StartData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.GB_StartData.Controls.Add(this.NUD_Pow);
			this.GB_StartData.Controls.Add(this.LBL_Pow);
			this.GB_StartData.Controls.Add(this.NUD_StepCount);
			this.GB_StartData.Controls.Add(this.CB_States);
			this.GB_StartData.Controls.Add(this.LBL_StepCount);
			this.GB_StartData.Controls.Add(this.LBL_StartPosition);
			this.GB_StartData.Controls.Add(this.TB_StartMatrix);
			this.GB_StartData.Location = new System.Drawing.Point(139, 27);
			this.GB_StartData.Name = "GB_StartData";
			this.GB_StartData.Size = new System.Drawing.Size(443, 231);
			this.GB_StartData.TabIndex = 0;
			this.GB_StartData.TabStop = false;
			this.GB_StartData.Text = "Исходные данные";
			// 
			// NUD_Pow
			// 
			this.NUD_Pow.Location = new System.Drawing.Point(311, 201);
			this.NUD_Pow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NUD_Pow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NUD_Pow.Name = "NUD_Pow";
			this.NUD_Pow.Size = new System.Drawing.Size(97, 20);
			this.NUD_Pow.TabIndex = 4;
			this.NUD_Pow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// LBL_Pow
			// 
			this.LBL_Pow.AutoSize = true;
			this.LBL_Pow.Location = new System.Drawing.Point(253, 203);
			this.LBL_Pow.Name = "LBL_Pow";
			this.LBL_Pow.Size = new System.Drawing.Size(52, 13);
			this.LBL_Pow.TabIndex = 3;
			this.LBL_Pow.Text = "Степень:";
			// 
			// NUD_StepCount
			// 
			this.NUD_StepCount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.NUD_StepCount.Location = new System.Drawing.Point(130, 201);
			this.NUD_StepCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.NUD_StepCount.Name = "NUD_StepCount";
			this.NUD_StepCount.Size = new System.Drawing.Size(111, 20);
			this.NUD_StepCount.TabIndex = 2;
			this.NUD_StepCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.NUD_StepCount.ValueChanged += new System.EventHandler(this.NUD_StepCount_ValueChanged);
			// 
			// CB_States
			// 
			this.CB_States.FormattingEnabled = true;
			this.CB_States.Location = new System.Drawing.Point(130, 173);
			this.CB_States.Name = "CB_States";
			this.CB_States.Size = new System.Drawing.Size(278, 21);
			this.CB_States.TabIndex = 1;
			this.CB_States.SelectedIndexChanged += new System.EventHandler(this.CB_States_SelectedIndexChanged);
			// 
			// LBL_StepCount
			// 
			this.LBL_StepCount.AutoSize = true;
			this.LBL_StepCount.Location = new System.Drawing.Point(7, 203);
			this.LBL_StepCount.Name = "LBL_StepCount";
			this.LBL_StepCount.Size = new System.Drawing.Size(100, 13);
			this.LBL_StepCount.TabIndex = 2;
			this.LBL_StepCount.Text = "Количество шагов";
			// 
			// LBL_StartPosition
			// 
			this.LBL_StartPosition.AutoSize = true;
			this.LBL_StartPosition.Location = new System.Drawing.Point(6, 176);
			this.LBL_StartPosition.Name = "LBL_StartPosition";
			this.LBL_StartPosition.Size = new System.Drawing.Size(118, 13);
			this.LBL_StartPosition.TabIndex = 2;
			this.LBL_StartPosition.Text = "Начальное состояние";
			// 
			// GB_PractData
			// 
			this.GB_PractData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.GB_PractData.Controls.Add(this.TB_PractMatrix);
			this.GB_PractData.Location = new System.Drawing.Point(139, 264);
			this.GB_PractData.Name = "GB_PractData";
			this.GB_PractData.Size = new System.Drawing.Size(443, 364);
			this.GB_PractData.TabIndex = 2;
			this.GB_PractData.TabStop = false;
			this.GB_PractData.Text = "Результаты";
			// 
			// TB_PractMatrix
			// 
			this.TB_PractMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TB_PractMatrix.BackColor = System.Drawing.SystemColors.Window;
			this.TB_PractMatrix.Location = new System.Drawing.Point(6, 19);
			this.TB_PractMatrix.Multiline = true;
			this.TB_PractMatrix.Name = "TB_PractMatrix";
			this.TB_PractMatrix.ReadOnly = true;
			this.TB_PractMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_PractMatrix.Size = new System.Drawing.Size(402, 339);
			this.TB_PractMatrix.TabIndex = 0;
			this.TB_PractMatrix.WordWrap = false;
			// 
			// LB_Test
			// 
			this.LB_Test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.LB_Test.FormattingEnabled = true;
			this.LB_Test.Location = new System.Drawing.Point(13, 26);
			this.LB_Test.Name = "LB_Test";
			this.LB_Test.Size = new System.Drawing.Size(120, 602);
			this.LB_Test.TabIndex = 3;
			this.LB_Test.SelectedIndexChanged += new System.EventHandler(this.LB_Test_SelectedIndexChanged);
			// 
			// ErrP
			// 
			this.ErrP.ContainerControl = this;
			this.ErrP.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrP.Icon")));
			// 
			// BTN_MatrixPow
			// 
			this.BTN_MatrixPow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BTN_MatrixPow.Enabled = false;
			this.BTN_MatrixPow.Location = new System.Drawing.Point(423, 634);
			this.BTN_MatrixPow.Name = "BTN_MatrixPow";
			this.BTN_MatrixPow.Size = new System.Drawing.Size(78, 23);
			this.BTN_MatrixPow.TabIndex = 4;
			this.BTN_MatrixPow.Text = "В степень";
			this.BTN_MatrixPow.UseVisualStyleBackColor = true;
			this.BTN_MatrixPow.Click += new System.EventHandler(this.BTN_MatrixPow_Click);
			// 
			// SSTR_StatusRow
			// 
			this.SSTR_StatusRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSTRL_Label});
			this.SSTR_StatusRow.Location = new System.Drawing.Point(0, 666);
			this.SSTR_StatusRow.Name = "SSTR_StatusRow";
			this.SSTR_StatusRow.Size = new System.Drawing.Size(594, 22);
			this.SSTR_StatusRow.TabIndex = 5;
			// 
			// SSTRL_Label
			// 
			this.SSTRL_Label.Name = "SSTRL_Label";
			this.SSTRL_Label.Size = new System.Drawing.Size(68, 17);
			this.SSTRL_Label.Text = "SSTRL_Label";
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_Options,
            this.MMI_Epur});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(594, 24);
			this.MainMenu.TabIndex = 6;
			this.MainMenu.Text = "menuStrip1";
			// 
			// MMI_Options
			// 
			this.MMI_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_TestCases,
            this.MMI_Settings});
			this.MMI_Options.Name = "MMI_Options";
			this.MMI_Options.Size = new System.Drawing.Size(51, 20);
			this.MMI_Options.Text = "Опции";
			// 
			// MMI_TestCases
			// 
			this.MMI_TestCases.Name = "MMI_TestCases";
			this.MMI_TestCases.Size = new System.Drawing.Size(191, 22);
			this.MMI_TestCases.Text = "Генерировать матрицу";
			this.MMI_TestCases.Click += new System.EventHandler(this.MMI_TestCases_Click);
			// 
			// MMI_Settings
			// 
			this.MMI_Settings.Name = "MMI_Settings";
			this.MMI_Settings.Size = new System.Drawing.Size(191, 22);
			this.MMI_Settings.Text = "Настройки";
			this.MMI_Settings.Click += new System.EventHandler(this.MMI_Settings_Click);
			// 
			// NUD_DispFirst
			// 
			this.NUD_DispFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.NUD_DispFirst.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUD_DispFirst.Location = new System.Drawing.Point(13, 634);
			this.NUD_DispFirst.Name = "NUD_DispFirst";
			this.NUD_DispFirst.Size = new System.Drawing.Size(120, 20);
			this.NUD_DispFirst.TabIndex = 7;
			this.NUD_DispFirst.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// LBL_DispFirst
			// 
			this.LBL_DispFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LBL_DispFirst.AutoSize = true;
			this.LBL_DispFirst.Location = new System.Drawing.Point(136, 639);
			this.LBL_DispFirst.Name = "LBL_DispFirst";
			this.LBL_DispFirst.Size = new System.Drawing.Size(108, 13);
			this.LBL_DispFirst.TabIndex = 8;
			this.LBL_DispFirst.Text = "Отобразить первые";
			// 
			// MMI_Epur
			// 
			this.MMI_Epur.Name = "MMI_Epur";
			this.MMI_Epur.Size = new System.Drawing.Size(55, 20);
			this.MMI_Epur.Text = "Эпюры";
			this.MMI_Epur.Click += new System.EventHandler(this.MMI_Ipur_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 688);
			this.Controls.Add(this.LBL_DispFirst);
			this.Controls.Add(this.NUD_DispFirst);
			this.Controls.Add(this.SSTR_StatusRow);
			this.Controls.Add(this.MainMenu);
			this.Controls.Add(this.BTN_MatrixPow);
			this.Controls.Add(this.LB_Test);
			this.Controls.Add(this.GB_PractData);
			this.Controls.Add(this.GB_StartData);
			this.Controls.Add(this.BTN_Start);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MainMenu;
			this.MinimumSize = new System.Drawing.Size(530, 515);
			this.Name = "Form1";
			this.Text = "Генератор Марковской цепи";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.GB_StartData.ResumeLayout(false);
			this.GB_StartData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Pow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_StepCount)).EndInit();
			this.GB_PractData.ResumeLayout(false);
			this.GB_PractData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ErrP)).EndInit();
			this.SSTR_StatusRow.ResumeLayout(false);
			this.SSTR_StatusRow.PerformLayout();
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUD_DispFirst)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BTN_Start;
		private System.Windows.Forms.GroupBox GB_StartData;
		private System.Windows.Forms.GroupBox GB_PractData;
		private System.Windows.Forms.TextBox TB_PractMatrix;
		private System.Windows.Forms.NumericUpDown NUD_StepCount;
		private System.Windows.Forms.Label LBL_StartPosition;
		private System.Windows.Forms.ListBox LB_Test;
		private System.Windows.Forms.ErrorProvider ErrP;
		private System.Windows.Forms.Label LBL_StepCount;
		private System.Windows.Forms.Button BTN_MatrixPow;
		private System.Windows.Forms.StatusStrip SSTR_StatusRow;
		private System.Windows.Forms.ToolStripStatusLabel SSTRL_Label;
		private System.Windows.Forms.MenuStrip MainMenu;
		public System.Windows.Forms.TextBox TB_StartMatrix;
		private System.Windows.Forms.Label LBL_DispFirst;
		private System.Windows.Forms.NumericUpDown NUD_DispFirst;
		private System.Windows.Forms.NumericUpDown NUD_Pow;
		private System.Windows.Forms.Label LBL_Pow;
		public System.Windows.Forms.ComboBox CB_States;
		private System.Windows.Forms.ToolStripMenuItem MMI_Options;
		private System.Windows.Forms.ToolStripMenuItem MMI_Settings;
		private System.Windows.Forms.ToolStripMenuItem MMI_TestCases;
		private System.Windows.Forms.ToolStripMenuItem MMI_Epur;
	}
}

