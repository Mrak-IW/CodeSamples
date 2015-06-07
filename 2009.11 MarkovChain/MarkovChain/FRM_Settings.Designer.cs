namespace MarkovChain
{
	partial class FRM_Settings
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
			this.LBL_DecimalPoints = new System.Windows.Forms.Label();
			this.NUD_DecimalPoints = new System.Windows.Forms.NumericUpDown();
			this.BTN_OK = new System.Windows.Forms.Button();
			this.CHB_Logging = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.NUD_DecimalPoints)).BeginInit();
			this.SuspendLayout();
			// 
			// LBL_DecimalPoints
			// 
			this.LBL_DecimalPoints.AutoSize = true;
			this.LBL_DecimalPoints.Location = new System.Drawing.Point(12, 9);
			this.LBL_DecimalPoints.Name = "LBL_DecimalPoints";
			this.LBL_DecimalPoints.Size = new System.Drawing.Size(121, 13);
			this.LBL_DecimalPoints.TabIndex = 0;
			this.LBL_DecimalPoints.Text = "Знаков после запятой";
			// 
			// NUD_DecimalPoints
			// 
			this.NUD_DecimalPoints.Location = new System.Drawing.Point(12, 25);
			this.NUD_DecimalPoints.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.NUD_DecimalPoints.Name = "NUD_DecimalPoints";
			this.NUD_DecimalPoints.Size = new System.Drawing.Size(120, 20);
			this.NUD_DecimalPoints.TabIndex = 1;
			this.NUD_DecimalPoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.NUD_DecimalPoints.ValueChanged += new System.EventHandler(this.NUD_DecimalPoints_ValueChanged);
			// 
			// BTN_OK
			// 
			this.BTN_OK.Location = new System.Drawing.Point(35, 74);
			this.BTN_OK.Name = "BTN_OK";
			this.BTN_OK.Size = new System.Drawing.Size(75, 23);
			this.BTN_OK.TabIndex = 2;
			this.BTN_OK.Text = "OK";
			this.BTN_OK.UseVisualStyleBackColor = true;
			this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
			// 
			// CHB_Logging
			// 
			this.CHB_Logging.AutoSize = true;
			this.CHB_Logging.Checked = true;
			this.CHB_Logging.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CHB_Logging.Location = new System.Drawing.Point(12, 51);
			this.CHB_Logging.Name = "CHB_Logging";
			this.CHB_Logging.Size = new System.Drawing.Size(76, 17);
			this.CHB_Logging.TabIndex = 3;
			this.CHB_Logging.Text = "Вести лог";
			this.CHB_Logging.UseVisualStyleBackColor = true;
			this.CHB_Logging.CheckedChanged += new System.EventHandler(this.CHB_Logging_CheckedChanged);
			// 
			// FRM_Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(146, 104);
			this.Controls.Add(this.CHB_Logging);
			this.Controls.Add(this.BTN_OK);
			this.Controls.Add(this.NUD_DecimalPoints);
			this.Controls.Add(this.LBL_DecimalPoints);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FRM_Settings";
			this.Text = "FRM_Settings";
			this.Enter += new System.EventHandler(this.FRM_Settings_Enter);
			this.VisibleChanged += new System.EventHandler(this.FRM_Settings_VisibleChanged);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Settings_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.NUD_DecimalPoints)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LBL_DecimalPoints;
		private System.Windows.Forms.NumericUpDown NUD_DecimalPoints;
		private System.Windows.Forms.Button BTN_OK;
		private System.Windows.Forms.CheckBox CHB_Logging;
	}
}