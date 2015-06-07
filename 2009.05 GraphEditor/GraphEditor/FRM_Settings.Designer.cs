namespace GraphEditor
{
	partial class TFRM_Settings
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
            this.NUD_Height = new System.Windows.Forms.NumericUpDown();
            this.LBL_Height = new System.Windows.Forms.Label();
            this.LBL_Width = new System.Windows.Forms.Label();
            this.NUD_Width = new System.Windows.Forms.NumericUpDown();
            this.GB_SettingsEditField = new System.Windows.Forms.GroupBox();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Apply = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.GB_StepSettings = new System.Windows.Forms.GroupBox();
            this.LBL_StepY = new System.Windows.Forms.Label();
            this.LBL_StepX = new System.Windows.Forms.Label();
            this.NUD_StepX = new System.Windows.Forms.NumericUpDown();
            this.NUD_StepY = new System.Windows.Forms.NumericUpDown();
            this.GB_View = new System.Windows.Forms.GroupBox();
            this.RB_Value = new System.Windows.Forms.RadioButton();
            this.RB_Descr = new System.Windows.Forms.RadioButton();
            this.CHB_DebugMode = new System.Windows.Forms.CheckBox();
            this.TB_Format = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).BeginInit();
            this.GB_SettingsEditField.SuspendLayout();
            this.GB_StepSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StepX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StepY)).BeginInit();
            this.GB_View.SuspendLayout();
            this.SuspendLayout();
            // 
            // NUD_Height
            // 
            this.NUD_Height.Location = new System.Drawing.Point(57, 14);
            this.NUD_Height.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.NUD_Height.Name = "NUD_Height";
            this.NUD_Height.Size = new System.Drawing.Size(120, 20);
            this.NUD_Height.TabIndex = 0;
            // 
            // LBL_Height
            // 
            this.LBL_Height.AutoSize = true;
            this.LBL_Height.Location = new System.Drawing.Point(6, 16);
            this.LBL_Height.Name = "LBL_Height";
            this.LBL_Height.Size = new System.Drawing.Size(45, 13);
            this.LBL_Height.TabIndex = 1;
            this.LBL_Height.Text = "Высота";
            // 
            // LBL_Width
            // 
            this.LBL_Width.AutoSize = true;
            this.LBL_Width.Location = new System.Drawing.Point(5, 42);
            this.LBL_Width.Name = "LBL_Width";
            this.LBL_Width.Size = new System.Drawing.Size(46, 13);
            this.LBL_Width.TabIndex = 2;
            this.LBL_Width.Text = "Ширина";
            // 
            // NUD_Width
            // 
            this.NUD_Width.Location = new System.Drawing.Point(57, 40);
            this.NUD_Width.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.NUD_Width.Name = "NUD_Width";
            this.NUD_Width.Size = new System.Drawing.Size(120, 20);
            this.NUD_Width.TabIndex = 1;
            // 
            // GB_SettingsEditField
            // 
            this.GB_SettingsEditField.Controls.Add(this.LBL_Height);
            this.GB_SettingsEditField.Controls.Add(this.LBL_Width);
            this.GB_SettingsEditField.Controls.Add(this.NUD_Height);
            this.GB_SettingsEditField.Controls.Add(this.NUD_Width);
            this.GB_SettingsEditField.Location = new System.Drawing.Point(12, 12);
            this.GB_SettingsEditField.Name = "GB_SettingsEditField";
            this.GB_SettingsEditField.Size = new System.Drawing.Size(186, 70);
            this.GB_SettingsEditField.TabIndex = 0;
            this.GB_SettingsEditField.TabStop = false;
            this.GB_SettingsEditField.Text = "Поле редактирования";
            // 
            // BTN_OK
            // 
            this.BTN_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_OK.Location = new System.Drawing.Point(166, 227);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 3;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_Apply
            // 
            this.BTN_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Apply.Location = new System.Drawing.Point(247, 226);
            this.BTN_Apply.Name = "BTN_Apply";
            this.BTN_Apply.Size = new System.Drawing.Size(75, 23);
            this.BTN_Apply.TabIndex = 4;
            this.BTN_Apply.Text = "Применить";
            this.BTN_Apply.UseVisualStyleBackColor = true;
            this.BTN_Apply.Click += new System.EventHandler(this.BTN_Apply_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Cancel.Location = new System.Drawing.Point(328, 226);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.TabIndex = 5;
            this.BTN_Cancel.Text = "Отмена";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // GB_StepSettings
            // 
            this.GB_StepSettings.Controls.Add(this.LBL_StepY);
            this.GB_StepSettings.Controls.Add(this.LBL_StepX);
            this.GB_StepSettings.Controls.Add(this.NUD_StepX);
            this.GB_StepSettings.Controls.Add(this.NUD_StepY);
            this.GB_StepSettings.Location = new System.Drawing.Point(12, 89);
            this.GB_StepSettings.Name = "GB_StepSettings";
            this.GB_StepSettings.Size = new System.Drawing.Size(186, 81);
            this.GB_StepSettings.TabIndex = 1;
            this.GB_StepSettings.TabStop = false;
            this.GB_StepSettings.Text = "Шаг сетки для вершин (px)";
            // 
            // LBL_StepY
            // 
            this.LBL_StepY.AutoSize = true;
            this.LBL_StepY.Location = new System.Drawing.Point(7, 23);
            this.LBL_StepY.Name = "LBL_StepY";
            this.LBL_StepY.Size = new System.Drawing.Size(45, 13);
            this.LBL_StepY.TabIndex = 1;
            this.LBL_StepY.Text = "Высота";
            // 
            // LBL_StepX
            // 
            this.LBL_StepX.AutoSize = true;
            this.LBL_StepX.Location = new System.Drawing.Point(6, 49);
            this.LBL_StepX.Name = "LBL_StepX";
            this.LBL_StepX.Size = new System.Drawing.Size(46, 13);
            this.LBL_StepX.TabIndex = 2;
            this.LBL_StepX.Text = "Ширина";
            // 
            // NUD_StepX
            // 
            this.NUD_StepX.Location = new System.Drawing.Point(58, 47);
            this.NUD_StepX.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NUD_StepX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_StepX.Name = "NUD_StepX";
            this.NUD_StepX.Size = new System.Drawing.Size(120, 20);
            this.NUD_StepX.TabIndex = 1;
            this.NUD_StepX.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NUD_StepY
            // 
            this.NUD_StepY.Location = new System.Drawing.Point(58, 21);
            this.NUD_StepY.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NUD_StepY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_StepY.Name = "NUD_StepY";
            this.NUD_StepY.Size = new System.Drawing.Size(120, 20);
            this.NUD_StepY.TabIndex = 0;
            this.NUD_StepY.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // GB_View
            // 
            this.GB_View.Controls.Add(this.RB_Value);
            this.GB_View.Controls.Add(this.RB_Descr);
            this.GB_View.Location = new System.Drawing.Point(204, 12);
            this.GB_View.Name = "GB_View";
            this.GB_View.Size = new System.Drawing.Size(199, 70);
            this.GB_View.TabIndex = 2;
            this.GB_View.TabStop = false;
            this.GB_View.Text = "Отображать на вершинах";
            // 
            // RB_Value
            // 
            this.RB_Value.AutoSize = true;
            this.RB_Value.Checked = true;
            this.RB_Value.Location = new System.Drawing.Point(7, 41);
            this.RB_Value.Name = "RB_Value";
            this.RB_Value.Size = new System.Drawing.Size(125, 17);
            this.RB_Value.TabIndex = 1;
            this.RB_Value.TabStop = true;
            this.RB_Value.Text = "Числовое значение";
            this.RB_Value.UseVisualStyleBackColor = true;
            // 
            // RB_Descr
            // 
            this.RB_Descr.AutoSize = true;
            this.RB_Descr.Location = new System.Drawing.Point(7, 18);
            this.RB_Descr.Name = "RB_Descr";
            this.RB_Descr.Size = new System.Drawing.Size(124, 17);
            this.RB_Descr.TabIndex = 0;
            this.RB_Descr.Text = "Описание вершины";
            this.RB_Descr.UseVisualStyleBackColor = true;
            // 
            // CHB_DebugMode
            // 
            this.CHB_DebugMode.AutoSize = true;
            this.CHB_DebugMode.Location = new System.Drawing.Point(12, 233);
            this.CHB_DebugMode.Name = "CHB_DebugMode";
            this.CHB_DebugMode.Size = new System.Drawing.Size(105, 17);
            this.CHB_DebugMode.TabIndex = 6;
            this.CHB_DebugMode.TabStop = false;
            this.CHB_DebugMode.Text = "Режим отладки";
            this.CHB_DebugMode.UseVisualStyleBackColor = true;
            this.CHB_DebugMode.CheckedChanged += new System.EventHandler(this.CHB_DebugMode_CheckedChanged);
            // 
            // TB_Format
            // 
            this.TB_Format.Location = new System.Drawing.Point(12, 201);
            this.TB_Format.Name = "TB_Format";
            this.TB_Format.Size = new System.Drawing.Size(186, 20);
            this.TB_Format.TabIndex = 7;
            // 
            // TFRM_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 262);
            this.Controls.Add(this.TB_Format);
            this.Controls.Add(this.CHB_DebugMode);
            this.Controls.Add(this.GB_View);
            this.Controls.Add(this.GB_StepSettings);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Apply);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.GB_SettingsEditField);
            this.Name = "TFRM_Settings";
            this.Text = "Настройки";
            this.Activated += new System.EventHandler(this.TFRM_Settings_Activated);
            this.VisibleChanged += new System.EventHandler(this.TFRM_Settings_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFRM_Settings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).EndInit();
            this.GB_SettingsEditField.ResumeLayout(false);
            this.GB_SettingsEditField.PerformLayout();
            this.GB_StepSettings.ResumeLayout(false);
            this.GB_StepSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StepX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StepY)).EndInit();
            this.GB_View.ResumeLayout(false);
            this.GB_View.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown NUD_Height;
		private System.Windows.Forms.Label LBL_Height;
		private System.Windows.Forms.Label LBL_Width;
		private System.Windows.Forms.NumericUpDown NUD_Width;
		private System.Windows.Forms.GroupBox GB_SettingsEditField;
		private System.Windows.Forms.Button BTN_OK;
		private System.Windows.Forms.Button BTN_Apply;
		private System.Windows.Forms.Button BTN_Cancel;

		#region Элементы, введенные МНОЙ

		public FRM_Main FRM_MainForm;

		#endregion
		private System.Windows.Forms.GroupBox GB_StepSettings;
		private System.Windows.Forms.Label LBL_StepY;
		private System.Windows.Forms.Label LBL_StepX;
		private System.Windows.Forms.NumericUpDown NUD_StepX;
		private System.Windows.Forms.NumericUpDown NUD_StepY;
		private System.Windows.Forms.GroupBox GB_View;
		private System.Windows.Forms.RadioButton RB_Descr;
		private System.Windows.Forms.RadioButton RB_Value;
		private System.Windows.Forms.CheckBox CHB_DebugMode;
        private System.Windows.Forms.TextBox TB_Format;
	}
}