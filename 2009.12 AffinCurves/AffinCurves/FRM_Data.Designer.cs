namespace AffinCurves
{
	partial class FRM_Data
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
			this.TC_Data = new System.Windows.Forms.TabControl();
			this.TC_Data_Affin = new System.Windows.Forms.TabPage();
			this.LBL_AffinData = new System.Windows.Forms.Label();
			this.TB_AffinData = new System.Windows.Forms.TextBox();
			this.TC_Data_Curves = new System.Windows.Forms.TabPage();
			this.LBL_Ermit = new System.Windows.Forms.Label();
			this.LBL_Besier = new System.Windows.Forms.Label();
			this.TB_Ermit = new System.Windows.Forms.TextBox();
			this.TB_Besier = new System.Windows.Forms.TextBox();
			this.BTN_Apply = new System.Windows.Forms.Button();
			this.ERR = new System.Windows.Forms.ErrorProvider(this.components);
			this.BTN_OK = new System.Windows.Forms.Button();
			this.LBL_AffinSample = new System.Windows.Forms.Label();
			this.TB_AffinSample = new System.Windows.Forms.TextBox();
			this.TB_BesierSample = new System.Windows.Forms.TextBox();
			this.TB_ErmitSample = new System.Windows.Forms.TextBox();
			this.LBL_CurvesSample = new System.Windows.Forms.Label();
			this.TC_Data.SuspendLayout();
			this.TC_Data_Affin.SuspendLayout();
			this.TC_Data_Curves.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).BeginInit();
			this.SuspendLayout();
			// 
			// TC_Data
			// 
			this.TC_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TC_Data.Controls.Add(this.TC_Data_Affin);
			this.TC_Data.Controls.Add(this.TC_Data_Curves);
			this.TC_Data.Location = new System.Drawing.Point(0, 0);
			this.TC_Data.Name = "TC_Data";
			this.TC_Data.SelectedIndex = 0;
			this.TC_Data.Size = new System.Drawing.Size(276, 291);
			this.TC_Data.TabIndex = 0;
			// 
			// TC_Data_Affin
			// 
			this.TC_Data_Affin.Controls.Add(this.LBL_AffinSample);
			this.TC_Data_Affin.Controls.Add(this.LBL_AffinData);
			this.TC_Data_Affin.Controls.Add(this.TB_AffinSample);
			this.TC_Data_Affin.Controls.Add(this.TB_AffinData);
			this.TC_Data_Affin.Location = new System.Drawing.Point(4, 22);
			this.TC_Data_Affin.Name = "TC_Data_Affin";
			this.TC_Data_Affin.Padding = new System.Windows.Forms.Padding(3);
			this.TC_Data_Affin.Size = new System.Drawing.Size(268, 265);
			this.TC_Data_Affin.TabIndex = 0;
			this.TC_Data_Affin.Text = "Аффинные";
			this.TC_Data_Affin.UseVisualStyleBackColor = true;
			// 
			// LBL_AffinData
			// 
			this.LBL_AffinData.AutoSize = true;
			this.LBL_AffinData.Location = new System.Drawing.Point(6, 3);
			this.LBL_AffinData.Name = "LBL_AffinData";
			this.LBL_AffinData.Size = new System.Drawing.Size(78, 13);
			this.LBL_AffinData.TabIndex = 1;
			this.LBL_AffinData.Text = "Точки фигуры";
			// 
			// TB_AffinData
			// 
			this.TB_AffinData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.TB_AffinData.Location = new System.Drawing.Point(8, 19);
			this.TB_AffinData.Multiline = true;
			this.TB_AffinData.Name = "TB_AffinData";
			this.TB_AffinData.Size = new System.Drawing.Size(252, 122);
			this.TB_AffinData.TabIndex = 0;
			this.TB_AffinData.TextChanged += new System.EventHandler(this.TB_AffinData_TextChanged);
			// 
			// TC_Data_Curves
			// 
			this.TC_Data_Curves.Controls.Add(this.LBL_Ermit);
			this.TC_Data_Curves.Controls.Add(this.LBL_CurvesSample);
			this.TC_Data_Curves.Controls.Add(this.LBL_Besier);
			this.TC_Data_Curves.Controls.Add(this.TB_ErmitSample);
			this.TC_Data_Curves.Controls.Add(this.TB_Ermit);
			this.TC_Data_Curves.Controls.Add(this.TB_BesierSample);
			this.TC_Data_Curves.Controls.Add(this.TB_Besier);
			this.TC_Data_Curves.Location = new System.Drawing.Point(4, 22);
			this.TC_Data_Curves.Name = "TC_Data_Curves";
			this.TC_Data_Curves.Padding = new System.Windows.Forms.Padding(3);
			this.TC_Data_Curves.Size = new System.Drawing.Size(268, 265);
			this.TC_Data_Curves.TabIndex = 1;
			this.TC_Data_Curves.Text = "Кривые";
			this.TC_Data_Curves.UseVisualStyleBackColor = true;
			// 
			// LBL_Ermit
			// 
			this.LBL_Ermit.AutoSize = true;
			this.LBL_Ermit.Location = new System.Drawing.Point(134, 3);
			this.LBL_Ermit.Name = "LBL_Ermit";
			this.LBL_Ermit.Size = new System.Drawing.Size(131, 13);
			this.LBL_Ermit.TabIndex = 2;
			this.LBL_Ermit.Text = "Точки и вектора Эрмита";
			// 
			// LBL_Besier
			// 
			this.LBL_Besier.AutoSize = true;
			this.LBL_Besier.Location = new System.Drawing.Point(6, 3);
			this.LBL_Besier.Name = "LBL_Besier";
			this.LBL_Besier.Size = new System.Drawing.Size(71, 13);
			this.LBL_Besier.TabIndex = 2;
			this.LBL_Besier.Text = "Точки Безье";
			// 
			// TB_Ermit
			// 
			this.TB_Ermit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.TB_Ermit.Location = new System.Drawing.Point(141, 19);
			this.TB_Ermit.Multiline = true;
			this.TB_Ermit.Name = "TB_Ermit";
			this.TB_Ermit.Size = new System.Drawing.Size(119, 122);
			this.TB_Ermit.TabIndex = 1;
			this.TB_Ermit.TextChanged += new System.EventHandler(this.TB_AffinData_TextChanged);
			// 
			// TB_Besier
			// 
			this.TB_Besier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.TB_Besier.Location = new System.Drawing.Point(8, 19);
			this.TB_Besier.Multiline = true;
			this.TB_Besier.Name = "TB_Besier";
			this.TB_Besier.Size = new System.Drawing.Size(119, 122);
			this.TB_Besier.TabIndex = 1;
			this.TB_Besier.TextChanged += new System.EventHandler(this.TB_AffinData_TextChanged);
			// 
			// BTN_Apply
			// 
			this.BTN_Apply.Location = new System.Drawing.Point(89, 296);
			this.BTN_Apply.Name = "BTN_Apply";
			this.BTN_Apply.Size = new System.Drawing.Size(75, 23);
			this.BTN_Apply.TabIndex = 1;
			this.BTN_Apply.Text = "Применить";
			this.BTN_Apply.UseVisualStyleBackColor = true;
			this.BTN_Apply.Click += new System.EventHandler(this.BTN_Aply_Click);
			// 
			// ERR
			// 
			this.ERR.ContainerControl = this;
			// 
			// BTN_OK
			// 
			this.BTN_OK.Location = new System.Drawing.Point(189, 296);
			this.BTN_OK.Name = "BTN_OK";
			this.BTN_OK.Size = new System.Drawing.Size(75, 23);
			this.BTN_OK.TabIndex = 2;
			this.BTN_OK.Text = "OK";
			this.BTN_OK.UseVisualStyleBackColor = true;
			this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
			// 
			// LBL_AffinSample
			// 
			this.LBL_AffinSample.AutoSize = true;
			this.LBL_AffinSample.Location = new System.Drawing.Point(8, 144);
			this.LBL_AffinSample.Name = "LBL_AffinSample";
			this.LBL_AffinSample.Size = new System.Drawing.Size(90, 13);
			this.LBL_AffinSample.TabIndex = 2;
			this.LBL_AffinSample.Text = "Тестовый набор";
			// 
			// TB_AffinSample
			// 
			this.TB_AffinSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.TB_AffinSample.BackColor = System.Drawing.SystemColors.Window;
			this.TB_AffinSample.Location = new System.Drawing.Point(8, 160);
			this.TB_AffinSample.Multiline = true;
			this.TB_AffinSample.Name = "TB_AffinSample";
			this.TB_AffinSample.ReadOnly = true;
			this.TB_AffinSample.Size = new System.Drawing.Size(252, 99);
			this.TB_AffinSample.TabIndex = 0;
			// 
			// TB_BesierSample
			// 
			this.TB_BesierSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.TB_BesierSample.BackColor = System.Drawing.SystemColors.Window;
			this.TB_BesierSample.Location = new System.Drawing.Point(8, 160);
			this.TB_BesierSample.Multiline = true;
			this.TB_BesierSample.Name = "TB_BesierSample";
			this.TB_BesierSample.ReadOnly = true;
			this.TB_BesierSample.Size = new System.Drawing.Size(119, 99);
			this.TB_BesierSample.TabIndex = 1;
			// 
			// TB_ErmitSample
			// 
			this.TB_ErmitSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.TB_ErmitSample.BackColor = System.Drawing.SystemColors.Window;
			this.TB_ErmitSample.Location = new System.Drawing.Point(141, 160);
			this.TB_ErmitSample.Multiline = true;
			this.TB_ErmitSample.Name = "TB_ErmitSample";
			this.TB_ErmitSample.ReadOnly = true;
			this.TB_ErmitSample.Size = new System.Drawing.Size(119, 99);
			this.TB_ErmitSample.TabIndex = 1;
			// 
			// LBL_CurvesSample
			// 
			this.LBL_CurvesSample.AutoSize = true;
			this.LBL_CurvesSample.Location = new System.Drawing.Point(8, 144);
			this.LBL_CurvesSample.Name = "LBL_CurvesSample";
			this.LBL_CurvesSample.Size = new System.Drawing.Size(90, 13);
			this.LBL_CurvesSample.TabIndex = 2;
			this.LBL_CurvesSample.Text = "Тестовый набор";
			// 
			// FRM_Data
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 325);
			this.Controls.Add(this.BTN_OK);
			this.Controls.Add(this.BTN_Apply);
			this.Controls.Add(this.TC_Data);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FRM_Data";
			this.Text = "Исходные данные";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FRM_Data_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Data_FormClosed);
			this.TC_Data.ResumeLayout(false);
			this.TC_Data_Affin.ResumeLayout(false);
			this.TC_Data_Affin.PerformLayout();
			this.TC_Data_Curves.ResumeLayout(false);
			this.TC_Data_Curves.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TC_Data;
		private System.Windows.Forms.TabPage TC_Data_Affin;
		private System.Windows.Forms.TabPage TC_Data_Curves;
		private System.Windows.Forms.Label LBL_AffinData;
		private System.Windows.Forms.TextBox TB_AffinData;
		private System.Windows.Forms.Button BTN_Apply;
		private System.Windows.Forms.TextBox TB_Besier;
		private System.Windows.Forms.Label LBL_Besier;
		private System.Windows.Forms.ErrorProvider ERR;
		private System.Windows.Forms.Button BTN_OK;
		private System.Windows.Forms.Label LBL_Ermit;
		private System.Windows.Forms.TextBox TB_Ermit;
		private System.Windows.Forms.Label LBL_AffinSample;
		private System.Windows.Forms.TextBox TB_AffinSample;
		private System.Windows.Forms.Label LBL_CurvesSample;
		private System.Windows.Forms.TextBox TB_ErmitSample;
		private System.Windows.Forms.TextBox TB_BesierSample;
	}
}