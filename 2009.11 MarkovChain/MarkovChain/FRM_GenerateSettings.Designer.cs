namespace MarkovChain
{
	partial class FRM_GenerateSettings
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
			this.NUD_Size = new System.Windows.Forms.NumericUpDown();
			this.LBL_Size = new System.Windows.Forms.Label();
			this.BTN_Generate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Size)).BeginInit();
			this.SuspendLayout();
			// 
			// NUD_Size
			// 
			this.NUD_Size.Location = new System.Drawing.Point(3, 21);
			this.NUD_Size.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.NUD_Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NUD_Size.Name = "NUD_Size";
			this.NUD_Size.Size = new System.Drawing.Size(151, 20);
			this.NUD_Size.TabIndex = 0;
			this.NUD_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NUD_Size.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
			// 
			// LBL_Size
			// 
			this.LBL_Size.AutoSize = true;
			this.LBL_Size.Location = new System.Drawing.Point(4, 5);
			this.LBL_Size.Name = "LBL_Size";
			this.LBL_Size.Size = new System.Drawing.Size(150, 13);
			this.LBL_Size.TabIndex = 1;
			this.LBL_Size.Text = "Рамер квадратной матрицы";
			// 
			// BTN_Generate
			// 
			this.BTN_Generate.Location = new System.Drawing.Point(160, 5);
			this.BTN_Generate.Name = "BTN_Generate";
			this.BTN_Generate.Size = new System.Drawing.Size(87, 39);
			this.BTN_Generate.TabIndex = 2;
			this.BTN_Generate.Text = "Генерировать";
			this.BTN_Generate.UseVisualStyleBackColor = true;
			this.BTN_Generate.Click += new System.EventHandler(this.BTN_Generate_Click);
			// 
			// FRM_GenerateSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(252, 49);
			this.Controls.Add(this.BTN_Generate);
			this.Controls.Add(this.LBL_Size);
			this.Controls.Add(this.NUD_Size);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FRM_GenerateSettings";
			this.Text = "Генерация матрицы";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_GenerateSettings_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.NUD_Size)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown NUD_Size;
		private System.Windows.Forms.Label LBL_Size;
		private System.Windows.Forms.Button BTN_Generate;
	}
}