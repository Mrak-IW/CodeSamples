namespace GraphEditor
{
	partial class TFRM_Analyse
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.DGV_Analyse = new System.Windows.Forms.DataGridView();
			this.CLM_Begin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CLM_End = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CLM_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TB_Begin = new System.Windows.Forms.TextBox();
			this.TB_End = new System.Windows.Forms.TextBox();
			this.TB_Descr = new System.Windows.Forms.TextBox();
			this.BTN_Add = new System.Windows.Forms.Button();
			this.ERR = new System.Windows.Forms.ErrorProvider(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.CHB_AnalyseVisible = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DGV_Analyse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).BeginInit();
			this.SuspendLayout();
			// 
			// DGV_Analyse
			// 
			this.DGV_Analyse.AllowUserToAddRows = false;
			this.DGV_Analyse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DGV_Analyse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGV_Analyse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLM_Begin,
            this.CLM_End,
            this.CLM_Description});
			this.DGV_Analyse.Location = new System.Drawing.Point(12, 12);
			this.DGV_Analyse.Name = "DGV_Analyse";
			this.DGV_Analyse.ReadOnly = true;
			this.DGV_Analyse.Size = new System.Drawing.Size(394, 118);
			this.DGV_Analyse.TabIndex = 0;
			this.DGV_Analyse.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Analyse_CellEnter);
			this.DGV_Analyse.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DGV_Analyse_RowsRemoved);
			// 
			// CLM_Begin
			// 
			dataGridViewCellStyle1.Format = "N3";
			dataGridViewCellStyle1.NullValue = "NULL";
			this.CLM_Begin.DefaultCellStyle = dataGridViewCellStyle1;
			this.CLM_Begin.HeaderText = "Начало";
			this.CLM_Begin.Name = "CLM_Begin";
			this.CLM_Begin.ReadOnly = true;
			this.CLM_Begin.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.CLM_Begin.Width = 80;
			// 
			// CLM_End
			// 
			dataGridViewCellStyle2.Format = "N3";
			dataGridViewCellStyle2.NullValue = "NULL";
			this.CLM_End.DefaultCellStyle = dataGridViewCellStyle2;
			this.CLM_End.HeaderText = "Окончание";
			this.CLM_End.Name = "CLM_End";
			this.CLM_End.ReadOnly = true;
			this.CLM_End.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.CLM_End.Width = 80;
			// 
			// CLM_Description
			// 
			this.CLM_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle3.NullValue = null;
			this.CLM_Description.DefaultCellStyle = dataGridViewCellStyle3;
			this.CLM_Description.HeaderText = "Описание";
			this.CLM_Description.Name = "CLM_Description";
			this.CLM_Description.ReadOnly = true;
			// 
			// TB_Begin
			// 
			this.TB_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TB_Begin.Location = new System.Drawing.Point(80, 139);
			this.TB_Begin.Name = "TB_Begin";
			this.TB_Begin.Size = new System.Drawing.Size(70, 20);
			this.TB_Begin.TabIndex = 1;
			// 
			// TB_End
			// 
			this.TB_End.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TB_End.Location = new System.Drawing.Point(80, 165);
			this.TB_End.Name = "TB_End";
			this.TB_End.Size = new System.Drawing.Size(70, 20);
			this.TB_End.TabIndex = 2;
			// 
			// TB_Descr
			// 
			this.TB_Descr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TB_Descr.Location = new System.Drawing.Point(177, 155);
			this.TB_Descr.Multiline = true;
			this.TB_Descr.Name = "TB_Descr";
			this.TB_Descr.Size = new System.Drawing.Size(230, 86);
			this.TB_Descr.TabIndex = 3;
			// 
			// BTN_Add
			// 
			this.BTN_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BTN_Add.Location = new System.Drawing.Point(12, 193);
			this.BTN_Add.Name = "BTN_Add";
			this.BTN_Add.Size = new System.Drawing.Size(138, 23);
			this.BTN_Add.TabIndex = 4;
			this.BTN_Add.Text = "Добавить";
			this.BTN_Add.UseVisualStyleBackColor = true;
			this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
			// 
			// ERR
			// 
			this.ERR.ContainerControl = this;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 142);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Начало";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Окончание";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(174, 139);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Описание";
			// 
			// CHB_AnalyseVisible
			// 
			this.CHB_AnalyseVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CHB_AnalyseVisible.AutoSize = true;
			this.CHB_AnalyseVisible.Location = new System.Drawing.Point(13, 224);
			this.CHB_AnalyseVisible.Name = "CHB_AnalyseVisible";
			this.CHB_AnalyseVisible.Size = new System.Drawing.Size(150, 17);
			this.CHB_AnalyseVisible.TabIndex = 5;
			this.CHB_AnalyseVisible.Text = "Отображать результаты";
			this.CHB_AnalyseVisible.UseVisualStyleBackColor = true;
			// 
			// TFRM_Analyse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 253);
			this.Controls.Add(this.CHB_AnalyseVisible);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BTN_Add);
			this.Controls.Add(this.TB_Descr);
			this.Controls.Add(this.TB_End);
			this.Controls.Add(this.TB_Begin);
			this.Controls.Add(this.DGV_Analyse);
			this.MinimumSize = new System.Drawing.Size(345, 200);
			this.Name = "TFRM_Analyse";
			this.Text = "Анализ";
			this.Shown += new System.EventHandler(this.TFRM_Analyse_Shown);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TFRM_Analyse_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.DGV_Analyse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView DGV_Analyse;
		private System.Windows.Forms.TextBox TB_Begin;
		private System.Windows.Forms.TextBox TB_End;
		private System.Windows.Forms.TextBox TB_Descr;
		private System.Windows.Forms.Button BTN_Add;
		private System.Windows.Forms.DataGridViewTextBoxColumn CLM_Begin;
		private System.Windows.Forms.DataGridViewTextBoxColumn CLM_End;
		private System.Windows.Forms.DataGridViewTextBoxColumn CLM_Description;
		private System.Windows.Forms.ErrorProvider ERR;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox CHB_AnalyseVisible;
	}
}