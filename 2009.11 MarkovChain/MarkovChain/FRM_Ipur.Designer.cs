namespace MarkovChain
{
	partial class FRM_Epur
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
			this.P_Ipur = new System.Windows.Forms.Panel();
			this.PB_Epur = new System.Windows.Forms.PictureBox();
			this.NUD_Scale = new System.Windows.Forms.NumericUpDown();
			this.LBL_Scale = new System.Windows.Forms.Label();
			this.CB_State = new System.Windows.Forms.ComboBox();
			this.TB_StateValue = new System.Windows.Forms.TextBox();
			this.ERR = new System.Windows.Forms.ErrorProvider(this.components);
			this.GB_SteStateValues = new System.Windows.Forms.GroupBox();
			this.TB_States = new System.Windows.Forms.TextBox();
			this.CHB_Lines = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.TB_FormatY = new System.Windows.Forms.TextBox();
			this.P_Ipur.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_Epur)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Scale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).BeginInit();
			this.GB_SteStateValues.SuspendLayout();
			this.SuspendLayout();
			// 
			// P_Ipur
			// 
			this.P_Ipur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.P_Ipur.AutoScroll = true;
			this.P_Ipur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.P_Ipur.Controls.Add(this.PB_Epur);
			this.P_Ipur.Location = new System.Drawing.Point(13, 13);
			this.P_Ipur.Name = "P_Ipur";
			this.P_Ipur.Size = new System.Drawing.Size(766, 387);
			this.P_Ipur.TabIndex = 2;
			// 
			// PB_Epur
			// 
			this.PB_Epur.BackColor = System.Drawing.SystemColors.Window;
			this.PB_Epur.Location = new System.Drawing.Point(3, 3);
			this.PB_Epur.Name = "PB_Epur";
			this.PB_Epur.Size = new System.Drawing.Size(760, 382);
			this.PB_Epur.TabIndex = 1;
			this.PB_Epur.TabStop = false;
			this.PB_Epur.Resize += new System.EventHandler(this.PB_Epur_SizeChanged);
			this.PB_Epur.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Epur_Paint);
			// 
			// NUD_Scale
			// 
			this.NUD_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.NUD_Scale.Location = new System.Drawing.Point(337, 407);
			this.NUD_Scale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUD_Scale.Name = "NUD_Scale";
			this.NUD_Scale.Size = new System.Drawing.Size(64, 20);
			this.NUD_Scale.TabIndex = 3;
			this.NUD_Scale.TabStop = false;
			this.NUD_Scale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NUD_Scale.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
			this.NUD_Scale.ValueChanged += new System.EventHandler(this.NUD_Scale_ValueChanged);
			// 
			// LBL_Scale
			// 
			this.LBL_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LBL_Scale.AutoSize = true;
			this.LBL_Scale.Location = new System.Drawing.Point(278, 409);
			this.LBL_Scale.Name = "LBL_Scale";
			this.LBL_Scale.Size = new System.Drawing.Size(53, 13);
			this.LBL_Scale.TabIndex = 4;
			this.LBL_Scale.Text = "Масштаб";
			// 
			// CB_State
			// 
			this.CB_State.FormattingEnabled = true;
			this.CB_State.Location = new System.Drawing.Point(7, 20);
			this.CB_State.Name = "CB_State";
			this.CB_State.Size = new System.Drawing.Size(121, 21);
			this.CB_State.TabIndex = 5;
			this.CB_State.SelectedIndexChanged += new System.EventHandler(this.CB_State_SelectedIndexChanged);
			// 
			// TB_StateValue
			// 
			this.TB_StateValue.Location = new System.Drawing.Point(134, 20);
			this.TB_StateValue.Name = "TB_StateValue";
			this.TB_StateValue.Size = new System.Drawing.Size(120, 20);
			this.TB_StateValue.TabIndex = 6;
			this.TB_StateValue.TextChanged += new System.EventHandler(this.TB_StateValue_TextChanged);
			this.TB_StateValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_StateValue_KeyUp);
			this.TB_StateValue.Validating += new System.ComponentModel.CancelEventHandler(this.TB_StateValue_Validating);
			// 
			// ERR
			// 
			this.ERR.ContainerControl = this;
			// 
			// GB_SteStateValues
			// 
			this.GB_SteStateValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GB_SteStateValues.Controls.Add(this.CB_State);
			this.GB_SteStateValues.Controls.Add(this.TB_StateValue);
			this.GB_SteStateValues.Location = new System.Drawing.Point(274, 449);
			this.GB_SteStateValues.Name = "GB_SteStateValues";
			this.GB_SteStateValues.Size = new System.Drawing.Size(275, 48);
			this.GB_SteStateValues.TabIndex = 7;
			this.GB_SteStateValues.TabStop = false;
			this.GB_SteStateValues.Text = "Задать значения состояниям";
			// 
			// TB_States
			// 
			this.TB_States.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TB_States.BackColor = System.Drawing.SystemColors.Window;
			this.TB_States.Location = new System.Drawing.Point(15, 406);
			this.TB_States.Multiline = true;
			this.TB_States.Name = "TB_States";
			this.TB_States.ReadOnly = true;
			this.TB_States.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TB_States.Size = new System.Drawing.Size(253, 91);
			this.TB_States.TabIndex = 8;
			this.TB_States.TabStop = false;
			// 
			// CHB_Lines
			// 
			this.CHB_Lines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CHB_Lines.AutoSize = true;
			this.CHB_Lines.Checked = true;
			this.CHB_Lines.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CHB_Lines.Location = new System.Drawing.Point(409, 409);
			this.CHB_Lines.Name = "CHB_Lines";
			this.CHB_Lines.Size = new System.Drawing.Size(119, 17);
			this.CHB_Lines.TabIndex = 9;
			this.CHB_Lines.TabStop = false;
			this.CHB_Lines.Text = "Отображать сетку";
			this.CHB_Lines.UseVisualStyleBackColor = true;
			this.CHB_Lines.CheckedChanged += new System.EventHandler(this.CHB_Lines_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(705, 403);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// TB_FormatY
			// 
			this.TB_FormatY.Location = new System.Drawing.Point(677, 476);
			this.TB_FormatY.Name = "TB_FormatY";
			this.TB_FormatY.Size = new System.Drawing.Size(100, 20);
			this.TB_FormatY.TabIndex = 11;
			this.TB_FormatY.TextChanged += new System.EventHandler(this.TB_FormatY_TextChanged);
			// 
			// FRM_Epur
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 503);
			this.Controls.Add(this.TB_FormatY);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.CHB_Lines);
			this.Controls.Add(this.TB_States);
			this.Controls.Add(this.GB_SteStateValues);
			this.Controls.Add(this.LBL_Scale);
			this.Controls.Add(this.NUD_Scale);
			this.Controls.Add(this.P_Ipur);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(570, 300);
			this.Name = "FRM_Epur";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Эпюры";
			this.Load += new System.EventHandler(this.FRM_Epur_Load);
			this.Activated += new System.EventHandler(this.FRM_Epur_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Epur_FormClosed);
			this.P_Ipur.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PB_Epur)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Scale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).EndInit();
			this.GB_SteStateValues.ResumeLayout(false);
			this.GB_SteStateValues.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel P_Ipur;
		private System.Windows.Forms.PictureBox PB_Epur;
		private System.Windows.Forms.NumericUpDown NUD_Scale;
		private System.Windows.Forms.Label LBL_Scale;
		private System.Windows.Forms.ComboBox CB_State;
		private System.Windows.Forms.TextBox TB_StateValue;
		private System.Windows.Forms.ErrorProvider ERR;
		private System.Windows.Forms.GroupBox GB_SteStateValues;
		private System.Windows.Forms.TextBox TB_States;
		private System.Windows.Forms.CheckBox CHB_Lines;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox TB_FormatY;
	}
}