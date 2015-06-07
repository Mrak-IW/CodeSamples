namespace CoordinateSystem
{
	/// <summary>
	/// Основная форма проекта
	/// </summary>
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.PB_Picture = new System.Windows.Forms.PictureBox();
			this.CB_Forbidden = new System.Windows.Forms.CheckBox();
			this.BTN_Cover = new System.Windows.Forms.Button();
			this.BTN_NearestPoint = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.LBL_Status = new System.Windows.Forms.ToolStripStatusLabel();
			this.BTN_Start = new System.Windows.Forms.Button();
			this.TB_CoefOverlay = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TB_Radius = new System.Windows.Forms.TextBox();
			this.CB_BackGroundImage = new System.Windows.Forms.CheckBox();
			this.TB_Log = new System.Windows.Forms.TextBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_Picture)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.Controls.Add(this.PB_Picture);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TB_Log);
			this.splitContainer1.Panel2.Controls.Add(this.CB_BackGroundImage);
			this.splitContainer1.Panel2.Controls.Add(this.TB_Radius);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.TB_CoefOverlay);
			this.splitContainer1.Panel2.Controls.Add(this.CB_Forbidden);
			this.splitContainer1.Panel2.Controls.Add(this.BTN_Cover);
			this.splitContainer1.Panel2.Controls.Add(this.BTN_NearestPoint);
			this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
			this.splitContainer1.Panel2.Controls.Add(this.BTN_Start);
			this.splitContainer1.Size = new System.Drawing.Size(746, 504);
			this.splitContainer1.SplitterDistance = 360;
			this.splitContainer1.TabIndex = 0;
			// 
			// PB_Picture
			// 
			this.PB_Picture.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.PB_Picture.Location = new System.Drawing.Point(0, 0);
			this.PB_Picture.Name = "PB_Picture";
			this.PB_Picture.Size = new System.Drawing.Size(600, 600);
			this.PB_Picture.TabIndex = 0;
			this.PB_Picture.TabStop = false;
			this.PB_Picture.DoubleClick += new System.EventHandler(this.PB_Picture_DoubleClick);
			this.PB_Picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Picture_MouseMove);
			this.PB_Picture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PB_Picture_MouseClick);
			// 
			// CB_Forbidden
			// 
			this.CB_Forbidden.AutoSize = true;
			this.CB_Forbidden.Location = new System.Drawing.Point(261, 9);
			this.CB_Forbidden.Name = "CB_Forbidden";
			this.CB_Forbidden.Size = new System.Drawing.Size(107, 17);
			this.CB_Forbidden.TabIndex = 4;
			this.CB_Forbidden.Text = "Запретная зона";
			this.CB_Forbidden.UseVisualStyleBackColor = true;
			// 
			// BTN_Cover
			// 
			this.BTN_Cover.Location = new System.Drawing.Point(179, 3);
			this.BTN_Cover.Name = "BTN_Cover";
			this.BTN_Cover.Size = new System.Drawing.Size(75, 23);
			this.BTN_Cover.TabIndex = 3;
			this.BTN_Cover.Text = "Cover";
			this.BTN_Cover.UseVisualStyleBackColor = true;
			this.BTN_Cover.Click += new System.EventHandler(this.BTN_Cover_Click);
			// 
			// BTN_NearestPoint
			// 
			this.BTN_NearestPoint.Location = new System.Drawing.Point(86, 3);
			this.BTN_NearestPoint.Name = "BTN_NearestPoint";
			this.BTN_NearestPoint.Size = new System.Drawing.Size(86, 23);
			this.BTN_NearestPoint.TabIndex = 2;
			this.BTN_NearestPoint.Text = "NearestPoint";
			this.BTN_NearestPoint.UseVisualStyleBackColor = true;
			this.BTN_NearestPoint.Click += new System.EventHandler(this.BTN_NearestPoint_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_Status});
			this.statusStrip1.Location = new System.Drawing.Point(0, 116);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(744, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// LBL_Status
			// 
			this.LBL_Status.Name = "LBL_Status";
			this.LBL_Status.Size = new System.Drawing.Size(60, 17);
			this.LBL_Status.Text = "LBL_Status";
			// 
			// BTN_Start
			// 
			this.BTN_Start.Location = new System.Drawing.Point(4, 4);
			this.BTN_Start.Name = "BTN_Start";
			this.BTN_Start.Size = new System.Drawing.Size(75, 23);
			this.BTN_Start.TabIndex = 0;
			this.BTN_Start.Text = "Start";
			this.BTN_Start.UseVisualStyleBackColor = true;
			this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
			// 
			// TB_CoefOverlay
			// 
			this.TB_CoefOverlay.Location = new System.Drawing.Point(121, 32);
			this.TB_CoefOverlay.Name = "TB_CoefOverlay";
			this.TB_CoefOverlay.Size = new System.Drawing.Size(133, 20);
			this.TB_CoefOverlay.TabIndex = 5;
			this.TB_CoefOverlay.Text = "0,577";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Коэф. наложения";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Радиус";
			// 
			// TB_Radius
			// 
			this.TB_Radius.Location = new System.Drawing.Point(121, 59);
			this.TB_Radius.Name = "TB_Radius";
			this.TB_Radius.Size = new System.Drawing.Size(133, 20);
			this.TB_Radius.TabIndex = 8;
			this.TB_Radius.Text = "50";
			// 
			// CB_BackGroundImage
			// 
			this.CB_BackGroundImage.AutoSize = true;
			this.CB_BackGroundImage.Location = new System.Drawing.Point(375, 9);
			this.CB_BackGroundImage.Name = "CB_BackGroundImage";
			this.CB_BackGroundImage.Size = new System.Drawing.Size(127, 17);
			this.CB_BackGroundImage.TabIndex = 9;
			this.CB_BackGroundImage.Text = "Показать подложку";
			this.CB_BackGroundImage.UseVisualStyleBackColor = true;
			this.CB_BackGroundImage.CheckedChanged += new System.EventHandler(this.CB_BackGroundImage_CheckedChanged);
			// 
			// TB_Log
			// 
			this.TB_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					  | System.Windows.Forms.AnchorStyles.Left)
					  | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_Log.Location = new System.Drawing.Point(261, 27);
			this.TB_Log.Multiline = true;
			this.TB_Log.Name = "TB_Log";
			this.TB_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_Log.Size = new System.Drawing.Size(472, 86);
			this.TB_Log.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(746, 504);
			this.Controls.Add(this.splitContainer1);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PB_Picture)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox PB_Picture;
		private System.Windows.Forms.Button BTN_Start;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel LBL_Status;
		private System.Windows.Forms.Button BTN_NearestPoint;
		private System.Windows.Forms.Button BTN_Cover;
		private System.Windows.Forms.CheckBox CB_Forbidden;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TB_CoefOverlay;
		private System.Windows.Forms.TextBox TB_Radius;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox CB_BackGroundImage;
		private System.Windows.Forms.TextBox TB_Log;
	}
}

