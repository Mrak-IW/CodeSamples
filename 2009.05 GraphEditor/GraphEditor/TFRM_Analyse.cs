using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphEditor
{
	public partial class TFRM_Analyse : Form
	{
		public FRM_Main parent;

		public TFRM_Analyse()
		{
			InitializeComponent();
		}

		public void RefreshList()
		{
			int i;

			DGV_Analyse.Rows.Clear();

			for (i = 0; i < parent.lst.Count; i++)
			{
				DGV_Analyse.Rows.Add(parent.lst[i].begin.ToString(), parent.lst[i].end.ToString(), parent.lst[i].description);
			}
		}

		private void BTN_Add_Click(object sender, EventArgs e)
		{
			TAnRec buf = new TAnRec();
			bool fl = true;

			try
			{
				ERR.SetError(TB_Begin, "");
				buf.begin = double.Parse(TB_Begin.Text);
			}
			catch 
			{
				ERR.SetError(TB_Begin, "Ошибка ввода");
				fl = false;
			}

			try
			{
				ERR.SetError(TB_End, "");
				buf.end = double.Parse(TB_End.Text);
			}
			catch
			{
				ERR.SetError(TB_End, "Ошибка ввода");
				fl = false;
			}

			buf.description = TB_Descr.Text == "" ? "<Нет описания>" : TB_Descr.Text;

			if (fl)
			{
				parent.lst.Add(buf);
				DGV_Analyse.Rows.Add(TB_Begin.Text, TB_End.Text, buf.description);
			}
		}

		private void TFRM_Analyse_Shown(object sender, EventArgs e)
		{
			RefreshList();
			CHB_AnalyseVisible.Checked = parent.GB_Analyse.Visible;
		}

		private void DGV_Analyse_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			TB_Begin.Text = DGV_Analyse[0, e.RowIndex].Value.ToString();
			TB_End.Text = DGV_Analyse[1, e.RowIndex].Value.ToString();
			TB_Descr.Text = DGV_Analyse[2, e.RowIndex].Value.ToString();
		}

		private void DGV_Analyse_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			int i;
			TAnRec buf;

			parent.lst.Clear();

			for (i = 0; i < DGV_Analyse.Rows.Count; i++)
			{
				buf = new TAnRec();
				try
				{
					buf.begin = double.Parse(DGV_Analyse[0, i].Value.ToString());
					buf.end = double.Parse(DGV_Analyse[1, i].Value.ToString());
					buf.description = DGV_Analyse[2, i].Value.ToString();
				}
				catch
				{
					MessageBox.Show("Ошибка при заполнении списка из DataGridView. Строка " + i.ToString(), "Вай, бяда!!!");
					return;
				}

				parent.lst.Add(buf);
			}
			//RefreshList();
		}

		private void TFRM_Analyse_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.InterfaceRefresh();
			parent.GB_Analyse.Visible = CHB_AnalyseVisible.Checked;
		}

	}
}
