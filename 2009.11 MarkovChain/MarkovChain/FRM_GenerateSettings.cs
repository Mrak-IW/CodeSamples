using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Matrix;

namespace MarkovChain
{
	public partial class FRM_GenerateSettings : Form
	{
		public Form1 parent;

		public FRM_GenerateSettings()
		{
			InitializeComponent();
		}

		private void BTN_Generate_Click(object sender, EventArgs e)
		{
			int i, j;
			double sum;
			string s;
			bool fl;
			int size = Convert.ToInt32(NUD_Size.Value);
			//Генерируем случайную матрицу
			TMatrix m = TMatrix.RND(size, size);
			//Теперь нормируем ее
			for (i = 0; i < m.Heigth; i++)
			{
				sum = 0;
				//Накапливаем сумму по строке
				for (j = 0; j < m.Width; j++)
				{
					sum += m[i, j];
				}
				//Делим строку на сумму по строке
				for (j = 0; j < m.Width; j++)
				{
					m[i, j] /= sum;
				}
			}
			//Теперь приведем матрицу к необходимому формату
			s = m.ToString(parent.format);
			m = TMatrix.Parse(s);
			//Корректируем возникшие погрешности нормировки
			for (i = 0; i < m.Heigth; i++)
			{
				sum = 0;
				//Накапливаем сумму по строке
				for (j = 0; j < m.Width; j++)
				{
					sum += m[i, j];
				}
				//Производим коррекцию
				sum = 1 - sum;
				fl = (sum * sum < TMarkovChain.eps * TMarkovChain.eps);	//Индикатор того, что нормировка была произведена
				for (j = m.Width - 1; j >= 0 && !fl; j--)
				{
					if ((m[i, j] + sum <= 1) && (m[i, j] + sum >= 0))
					{
						m[i, j] += sum;
						fl = true;
					}
				}
			}
			parent.TB_StartMatrix.Text = m.ToString(parent.format);
			//parent.TB_StartMatrix.Focus();
		}

		private void FRM_GenerateSettings_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.frmGenerate = null;
			
		}
	}
}
