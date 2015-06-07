using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Matrix;

namespace AffinCurves
{
	public partial class FRM_Data : Form
	{
		public Form1 parent = null;
		string affinStart = "20,00\t100,00\t1\r\n20,00\t140,00\t1\r\n50,00\t100,00\t1";
		string besierStart = "10,00\t20,00\r\n150,00\t150,00\r\n240,00\t160,00\r\n270,00\t100,00";
		string ermitStart = "10,00\t20,00\r\n270,00\t100,00\r\n280,00\t260,00\r\n-150,00\t300,00";

		public FRM_Data()
		{
			InitializeComponent();
		}

		private void BTN_Aply_Click(object sender, EventArgs e)
		{
			TMatrix buf;
			int i;

			//Получение данных для аффинных преобразований
			try
			{
				buf = TMatrix.Parse(TB_AffinData.Text);
				if (buf.Width != 3)
					throw new Exception("В матрице для аффинных преобразований должно быть 3 столбца - координаты и коэфициент однородности");
				if (buf.Heigth < 2)
					throw new Exception("В матрице для аффинных преобразований должно быть не менее, чем 2 строки - точки");

				parent.marr=new TMatrix[buf.Heigth];

				for (i = 0; i < buf.Heigth; i++)
				{
					parent.marr[i] = new TMatrix(3);
					parent.marr[i][0] = buf.row(i)[0];
					parent.marr[i][1] = buf.row(i)[1];
					parent.marr[i][2] = 1;
				}
				TB_AffinData.Text = buf.ToString("F2");

				parent.TC_Mode_SelectedIndexChanged(null, null);
			}
			catch (Exception ex)
			{
				ERR.SetError(BTN_Apply, ex.Message);
				return;
			}

			//Получение данных для аффинных преобразований
			try
			{
				buf = TMatrix.Parse(TB_Besier.Text);
				if (buf.Width != 2)
					throw new Exception("В матрице для кривых должно быть 2 столбца - координаты");
				if (buf.Heigth < 2)
					throw new Exception("В матрице для кривых должно быть 4 строки - точки");

				parent.besier = buf;
				TB_Besier.Text = buf.ToString("F2");
				//parent.ermit = new TMatrix(4, 2);

				/*parent.ermit[0, 0] = parent.besier[0, 0];	//10
				parent.ermit[0, 1] = parent.besier[0, 1];	//20
				//besier[1, 0] = 150;
				//besier[1, 1] = 150;
				//besier[2, 0] = 240;
				//besier[2, 1] = 160;
				parent.ermit[1, 0] = parent.besier[3, 0];	//270
				parent.ermit[1, 1] = parent.besier[3, 1];	//100

				buf = (parent.besier.row(1) - parent.besier.row(0)) * 2;
				parent.ermit[2, 0] = buf[0];
				parent.ermit[2, 1] = buf[1];
				buf = (parent.besier.row(2) - parent.besier.row(3)) * 5;
				parent.ermit[3, 0] = buf[0];
				parent.ermit[3, 1] = buf[1];
				*/

				buf = TMatrix.Parse(TB_Ermit.Text);
				if (buf.Width != 2)
					throw new Exception("В матрице для кривых должно быть 2 столбца - координаты");
				if (buf.Heigth < 2)
					throw new Exception("В матрице для кривых должно быть 4 строки - точки");

				parent.ermit = buf;
				TB_Ermit.Text = buf.ToString("F2");

				parent.TC_Mode_SelectedIndexChanged(null, null);
			}
			catch (Exception ex)
			{
				ERR.SetError(BTN_Apply, ex.Message);
				return;
			}
		}

		private void FRM_Data_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.frm_Data = null;
		}

		private void BTN_OK_Click(object sender, EventArgs e)
		{
			BTN_Aply_Click(sender, e);
			this.Close();
		}

		private void FRM_Data_Load(object sender, EventArgs e)
		{
			int i;
			TB_AffinData.Text = "";
			if (parent.marr != null)
			{
				for (i = 0; i < parent.marr.Length; i++)
				{
					TB_AffinData.Text = TB_AffinData.Text + parent.marr[i].ToString("F2");
				}
			}
			else
			{
				TB_AffinData.Text = affinStart; 
			}

			if (parent.besier != null)
			{
				TB_Besier.Text = parent.besier.ToString("F2");
			}
			else
			{
				TB_Besier.Text = besierStart;
			}

			if (parent.ermit != null)
			{
				TB_Ermit.Text = parent.ermit.ToString("F2");
			}
			else
			{
				TB_Ermit.Text = ermitStart;
			}
			TB_AffinSample.Text = affinStart;
			TB_BesierSample.Text = besierStart;
			TB_ErmitSample.Text = ermitStart;
		}

		private void TB_AffinData_TextChanged(object sender, EventArgs e)
		{
			ERR.SetError(BTN_Apply, "");
		}
	}
}
