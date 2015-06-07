using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoordinateSystem;

namespace CoordinateSystem
{
	public partial class Form1 : Form
	{
		Bitmap bmp;
		TCoordinateSystemDecart cs = null;
		TLineCracked crl = null;
		TPolygon targetPolygon = null;
		TPolygon forbidden = null;
		TDot nearest = null;
		TDot dot = new TDot(1000, 500);
		TSegment seg = null;
		List<iFigure> covering = null;
		/// <summary>
		/// Текущий десятичный разделитель
		/// </summary>
		Char separator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

		Color redTransparent = Color.FromArgb(120, 255, 0, 0);
		Color greenTransparent = Color.FromArgb(120, 0, 255, 0);
		Color greenTransparent60 = Color.FromArgb(60, 0, 255, 0);
		Color blueTransparent = Color.FromArgb(120, 0, 0, 255);
		Color yellowTransparent = Color.FromArgb(120, Color.Yellow.R, Color.Yellow.G, Color.Yellow.B);

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			bmp = new Bitmap("small.jpg");
			PB_Picture.Size = bmp.Size;

			//PB_Picture.BackgroundImage = bmp;
			PB_Picture.Image = new Bitmap(PB_Picture.Width, PB_Picture.Height);

			//PB_Picture.Image = new Bitmap(bmp);

			cs = new TCoordinateSystemDecart(PB_Picture.Height - 20, PB_Picture.Width - 20, 10, 10);
			//cs.Autoscale = true;
			cs.Max = new PointF(PB_Picture.Width - 70, PB_Picture.Height - 70);
			cs.Min = new PointF(-50, -50);

			//Левая граница поля графика
			TLineStraight border = new TLineStraight(1, 0, cs.Min.X);
			cs.Figures.Add(border);
			//Правая граница поля графика
			border = new TLineStraight(1, 0, cs.Max.X);
			cs.Figures.Add(border);
			//Верхняя граница поля графика
			border = new TLineStraight(0, 1, cs.Max.Y);
			cs.Figures.Add(border);
			//Нижняя граница поля графика
			border = new TLineStraight(0, 1, cs.Min.Y);
			cs.Figures.Add(border);

			cs.Figures.Add(dot);
		}
		
		private void BTN_Start_Click(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(PB_Picture.Image);
			//Graphics g = Graphics.FromImage(bmp);
			/*TRay ray;

			

			TSegment segment = new TSegment(new PointF(-20, 0), new PointF(20, 0));
			segment.Pen = new Pen(greenTransparent, 5);
			cs.Figures.Add(segment);

			TCircle circle = new TCircle(segment.PointBegin, 8);
			circle.Brush = new SolidBrush(greenTransparent);
			cs.Figures.Add(circle);

			circle = new TCircle(segment.PointEnd, 8);
			circle.Brush = new SolidBrush(greenTransparent);
			cs.Figures.Add(circle);

			TLineStraight line = new TLineStraight(cs.Max, cs.Min);
			line.Pen = new Pen(redTransparent, 10);
			cs.Figures.Add(line);

			PointF crosspoint;
			if (TTests.IsCrossing(segment, line, out crosspoint))
			{
				circle = new TCircle(crosspoint, 10);
				circle.Brush = new SolidBrush(redTransparent);
				cs.Figures.Add(circle);
			}

			PointF middle = new PointF((cs.Max.X + cs.Min.X) / 2, (cs.Max.Y + cs.Min.Y) / 2);
			PointF zero = new PointF();
			line = line.GetPerpendicular(new PointF(300, 300));
			line.Pen = new Pen(greenTransparent, 10);
			cs.Figures.Add(line);

			line = line.GetPerpendicular(new PointF(0, -150));
			line.Pen = new Pen(blueTransparent, 10);
			cs.Figures.Add(line);
			
			//Левая граница поля графика
			TLineStraight border = new TLineStraight(1, 0, cs.Min.X);
			cs.Figures.Add(border);
			//Правая граница поля графика
			border = new TLineStraight(1, 0, cs.Max.X);
			cs.Figures.Add(border);
			//Верхняя граница поля графика
			border = new TLineStraight(0, 1, cs.Max.Y);
			cs.Figures.Add(border);
			//Нижняя граница поля графика
			border = new TLineStraight(0, 1, cs.Min.Y);
			cs.Figures.Add(border);

			circle = new TCircle(new PointF(0, 0), 10);
			circle.Brush = new SolidBrush(blueTransparent);
			cs.Figures.Add(circle);

			ray = new TRay(new PointF(0, 0), new PointF(-1, 1));
			ray.Pen = new Pen(yellowTransparent, 5);
			cs.Figures.Add(ray);

			ray = new TRay(new PointF(-100, 0), new PointF(1, 1));
			ray.Pen = new Pen(yellowTransparent, 5);
			cs.Figures.Add(ray);*/

			if (targetPolygon != null && cs != null)
				cs.Figures.Remove(targetPolygon);

			targetPolygon = new TPolygon(100, 100, 600, 100, 600, 500, 100, 500);
			targetPolygon.Pen = new Pen(redTransparent, 10);
			cs.Figures.Add(targetPolygon);

			if (CB_BackGroundImage.Checked)
				g.DrawImage(bmp, new Rectangle(0, 0, PB_Picture.Width, PB_Picture.Height));
			else
				g.Clear(Color.White);
			cs.DrawFigures(g);

			PB_Picture.Refresh();
		}

		private void PB_Picture_MouseClick(object sender, MouseEventArgs e)
		{
			Graphics g = Graphics.FromImage(PB_Picture.Image);
			if (cs != null)
			{
				PointF newpt = cs.GetPointCoordinates(e.Location);
				if (crl != null)
				{
					crl.Points.Add(newpt);
				}
				else
				{
					crl = new TLineCracked(newpt);
					cs.Figures.Add(crl);
				}

				if (CB_Forbidden.Checked)
					crl.Pen = new Pen(blueTransparent, 10);
				else
					crl.Pen = new Pen(redTransparent, 10);

				if (nearest != null)
					cs.Figures.Remove(nearest);
				nearest = new TDot(crl.GetNearestPoint(dot.point));
				nearest.Brush = crl.Pen.Brush;
				nearest.Diameter = (float)(crl.Pen.Width * 1.5);
				dot.Brush = crl.Pen.Brush;
				dot.Diameter = (float)(crl.Pen.Width * 1.5);
				cs.Figures.Add(nearest);
				if (seg != null)
					cs.Figures.Remove(seg);
				seg = new TSegment(dot.point, nearest.point);
				cs.Figures.Add(seg);

				if (CB_BackGroundImage.Checked)
					g.DrawImage(bmp, new Rectangle(0, 0, PB_Picture.Width, PB_Picture.Height));
				else
					g.Clear(Color.White);
				cs.DrawFigures(g);
				PB_Picture.Refresh();
			}
		}

		private void PB_Picture_MouseMove(object sender, MouseEventArgs e)
		{
			if (cs != null)
			{
				LBL_Status.Text = "Форма: " + e.Location + "; СК: " + cs.GetPointCoordinates(e.Location) + "Начало координат находится в: " + cs.Zero;
			}
		}

		private void PB_Picture_DoubleClick(object sender, EventArgs e)
		{
			float eps = 20 / (cs.One.X + cs.One.Y);	//Допуск расстояния, при котором точки считаются сливающимися.
			Graphics g = Graphics.FromImage(PB_Picture.Image);
			PointF[] points;
			TPolygon bufpol;
			int i;
			if (crl != null)
			{
				if (CB_Forbidden.Checked)
					bufpol = forbidden;
				else
					bufpol = targetPolygon;

				if (bufpol != null)
				{
					cs.Figures.Remove(bufpol);
				}
				bufpol = new TPolygon(crl);
				points = bufpol.Points;
				//Удаляем последнюю точку, если она ближе к первой или предпоследней, чем допуск.
				if (bufpol.Points.Length > 1 && (TConstants.IsEqualPointF(points[points.Length - 1], points[0], eps) || TConstants.IsEqualPointF(points[points.Length - 1], points[points.Length - 2], eps)))
				{
					PointF[] bufarr = new PointF[points.Length - 1];
					for (i = 0; i < bufarr.Length; i++)
						bufarr[i] = points[i];
					bufpol.Points = bufarr;
				}

				if (CB_Forbidden.Checked)
				{
					forbidden = bufpol;
					forbidden.Brush = forbidden.Pen.Brush;
					forbidden.Pen = null;
				}
				else
					targetPolygon = bufpol;

				cs.Figures.Add(bufpol);
				cs.Figures.Remove(crl);
			}
			crl = null;

			if (CB_BackGroundImage.Checked)
				g.DrawImage(bmp, new Rectangle(0, 0, PB_Picture.Width, PB_Picture.Height));
			else
				g.Clear(Color.White);
			cs.DrawFigures(g);
			PB_Picture.Refresh();
		}

		private void BTN_NearestPoint_Click(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(PB_Picture.Image);
			
			if (nearest != null)
				cs.Figures.Remove(nearest);
			if (targetPolygon != null)
			{
				nearest = new TDot(targetPolygon.GetNearestPoint(dot.point));
				nearest.Brush = targetPolygon.Pen.Brush;
				nearest.Diameter = (float)(targetPolygon.Pen.Width * 1.5);
				dot.Brush = targetPolygon.Pen.Brush;
				dot.Diameter = (float)(targetPolygon.Pen.Width * 1.5);
				cs.Figures.Add(nearest);
				if (seg != null)
					cs.Figures.Remove(seg);
				seg = new TSegment(dot.point, nearest.point);
				cs.Figures.Add(seg);
			}

			if (CB_BackGroundImage.Checked)
				g.DrawImage(bmp, new Rectangle(0, 0, PB_Picture.Width, PB_Picture.Height));
			else
				g.Clear(Color.White);
			cs.DrawFigures(g);
			PB_Picture.Refresh();
		}

		private void BTN_Cover_Click(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(PB_Picture.Image);
			TCircle sample;
			float radius, coef;	//Радиус окружности и коэфициент наложения для алгоритма покрытия

			//Лечим систему от десятично-разделительного шовинизма
			TB_Radius.Text = TB_Radius.Text.Replace('.', separator);
			TB_CoefOverlay.Text = TB_CoefOverlay.Text.Replace('.', separator);
			TB_Radius.Text = TB_Radius.Text.Replace(',', separator);
			TB_CoefOverlay.Text = TB_CoefOverlay.Text.Replace(',', separator);

			radius = float.Parse(TB_Radius.Text);
			coef = float.Parse(TB_CoefOverlay.Text);

			if (cs != null)
			{
				if (covering != null)
					foreach (TCircle c in covering)
						cs.Figures.Remove(c);

				if (targetPolygon != null)
				{
					sample = new TCircle(new PointF(), radius);
					sample.Brush = new SolidBrush(greenTransparent60);
					//sample.Pen = null;
					covering = TCoveringAlgorithm.Triangles(targetPolygon, sample, coef, forbidden);	// 1/sqrt(3) == 0.57735026918962576450914878050225
					cs.Figures.AddRange(covering);

					if (CB_BackGroundImage.Checked)
						g.DrawImage(bmp, new Rectangle(0, 0, PB_Picture.Width, PB_Picture.Height));
					else
						g.Clear(Color.White);
					cs.DrawFigures(g);
					PB_Picture.Refresh();
					TB_Log.Text = "Радиус:\t" + sample.Radius + "\r\nКоэфициент наложения:\t" + coef + "\r\nИспользовано " + covering.Count + " окружностей\r\n\r\n" + TB_Log.Text;
				}
			}
		}

		private void CB_BackGroundImage_CheckedChanged(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(PB_Picture.Image);
			if (CB_BackGroundImage.Checked)
				g.DrawImage(bmp, new Rectangle(0, 0, PB_Picture.Width, PB_Picture.Height));
			else
				g.Clear(Color.White);
			cs.DrawFigures(g);
			PB_Picture.Refresh();
		}
	}
}
