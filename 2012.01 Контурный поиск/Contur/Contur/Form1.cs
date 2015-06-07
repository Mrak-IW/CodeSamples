using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Image_PGM;
using Perceptron;

namespace Contur
{
	public partial class Form1 : Form
	{
		PGM_Image image, contur;
		string imageName, conturName;
		ConturPerceptron cp;
		string formatString = "F6";

		public Form1()
		{
			InitializeComponent();
		}

		private void MMI_OpenImage_Click(object sender, EventArgs e)
		{
			OFD.Title = "Открыть исходное изображение";
			if (OFD.ShowDialog() == DialogResult.OK)
			{
				conturName = OFD.SafeFileName;
				Graphics g;

				image = new PGM_Image(OFD.FileName);

				PB_Original.Width = image.Width;
				PB_Original.Height = image.Height;
				PB_Original.Image = new Bitmap(image.Width, image.Height);
				g = Graphics.FromImage(PB_Original.Image);

				image.Draw(g);
				PB_Original.Refresh();
				TC_Images.SelectedTab = TP_Image;

				TB_Log.Text = "Открыт файл изображения:\r\n\tВысота:\t\t" + image.Height
					+ "\r\n\tШирина:\t\t" + image.Width + "\r\n\tОттенков серого:\t" + image.MaxGrey
					+ "\r\n\tКомментарий:" + (image.Comment.Length>0 ? "\r\n\t#"
					+ image.Comment.Replace("\n", "\r\n\t#") : "\tотстутсвует") + "\r\n\r\n" + TB_Log.Text;
				//image.SaveToFile("Test.pgm");
			}
		}

		private void MMI_OpenContur_Click(object sender, EventArgs e)
		{
			OFD.Title = "Открыть контур";
			if (OFD.ShowDialog() == DialogResult.OK)
			{
				imageName = OFD.SafeFileName;
				Graphics g;

				contur = new PGM_Image(OFD.FileName);

				PB_Contur.Width = contur.Width;
				PB_Contur.Height = contur.Height;
				PB_Contur.Image = new Bitmap(contur.Width, contur.Height);
				g = Graphics.FromImage(PB_Contur.Image);

				contur.Draw(g);
				PB_Contur.Refresh();
				TC_Images.SelectedTab = TP_Contur;

				TB_Log.Text = "Открыт файл контура:\r\n\tВысота:\t\t" + contur.Height
					+ "\r\n\tШирина:\t\t" + contur.Width + "\r\n\tОттенков серого:\t" + contur.MaxGrey
					+ "\r\n\tКомментарий:" + (contur.Comment.Length > 0 ? "\r\n\t#"
					+ contur.Comment.Replace("\n", "\r\n\t#") : "\tотстутсвует") + "\r\n\r\n" + TB_Log.Text;
			}
		}

		private void MMI_Teach_Click(object sender, EventArgs e)
		{
			int i, j, h;
			double nu = 1, diff = -1, nuMultiplier = 1, teta;

			if (image == null)
			{
				MessageBox.Show("Не задано исходное изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (contur == null)
			{
				MessageBox.Show("Не задан эталонный контур", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (image.Width != contur.Width || image.Height != contur.Height)
			{
				MessageBox.Show("Размеры изображения и контура не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				nu = double.Parse(TB_Koef.Text);
			}
			catch 
			{
				MessageBox.Show("Коефициент обучения не похож на число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				nuMultiplier = double.Parse(TB_nuMultiplier.Text);
			}
			catch
			{
				MessageBox.Show("Множитель не похож на число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				teta = double.Parse(TB_Teta.Text);
			}
			catch
			{
				MessageBox.Show("Порог срабатывания не похож на число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cp = null;
				return;
			}

			cp = new ConturPerceptron(Convert.ToInt32(NUD_Width.Value), Convert.ToInt32(NUD_Height.Value), teta, nu, ChB_ChangeTeta.Checked);
			
			DateTime timeStart = DateTime.Now;

			TB_Log.Text = "Обучение начато.\r\n\tКоэфициент обучения nu = " + nu + "\r\n\t"
				+ "Множитель изменения nu при смене эпохи = " + nuMultiplier
				+ "\r\n\r\n" + TB_Log.Text;

			for (h = 0; h < NUD_Epoch.Value; h++)
			{
				diff = 0;
				for (i = 0; i < image.Height; i++)
					for (j = 0; j < image.Width; j++)
					{
						cp.GetReceptorField(image, j, i);
						diff += cp.Teach(Convert.ToByte(contur[j, i] / contur.MaxGrey));
					}
				//nu /= 2;
				diff /= image.Height*image.Width;
				nu *= nuMultiplier;
				TB_Log.Text = "\tdiff[" + h + "] = " + diff.ToString(formatString) + "\r\n" + TB_Log.Text;
			}

			DateTime timeEnd = DateTime.Now;
			TB_PerceptronInfo.Text = cp.ToString(formatString);
			TB_Log.Text = "Обучение завершено за "
				+ (timeEnd - timeStart).TotalMilliseconds + " ms"
				+ "\r\n\tРецепторное поле:\t" + cp.Width + "x" + cp.Height
				+ "\r\n\tЭпох:\t" + NUD_Epoch.Value
				+ "\r\n\tПоследняя корректировка весов составила:\t" + diff.ToString(formatString)
				+ "\r\n\tИсходный файл:\t" + imageName
				+ "\r\n\tФайл контура:\t" + conturName
				+ "\r\n\tКоэфициент:\t" + nu
				+ "\r\n" + TB_Log.Text;
		}

		private void CM_Log_Clear_Click(object sender, EventArgs e)
		{
			TB_Log.Text = "";
		}

		private void MI_CreateContur_Click(object sender, EventArgs e)
		{
			if (cp == null)
			{
				MessageBox.Show("Перцептрон ещё не обучен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (image == null)
			{
				MessageBox.Show("Не задано исходное изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			
			int i, j;
			Graphics g;
			PGM_Image newContur = new PGM_Image(image);

			DateTime timeStart = DateTime.Now;

			for (i = 0; i < image.Height; i++)
				for (j = 0; j < image.Width; j++)
				{
					cp.GetReceptorField(image,j,i);
					newContur[j, i] = Convert.ToByte(cp.Out * newContur.MaxGrey);
				}

			PB_Result.Width = newContur.Width;
			PB_Result.Height = newContur.Height;
			PB_Result.Image = new Bitmap(newContur.Width, newContur.Height);
			g = Graphics.FromImage(PB_Result.Image);

			DateTime timeEnd = DateTime.Now;

			newContur.Draw(g);
			PB_Contur.Refresh();
			TC_Images.SelectedTab = TP_Result;

			TB_Log.Text = "Контур построен за " + (timeEnd - timeStart).TotalMilliseconds + " ms\r\n\r\n" + TB_Log.Text;
		}

	}
}
