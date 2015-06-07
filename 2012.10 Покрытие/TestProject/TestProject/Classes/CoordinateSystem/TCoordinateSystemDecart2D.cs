using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Предоставляет услуги преобразования точки на объекте графики в точку на системе координат
	/// и обратно. Также отрисовывает саму систему координат.
	/// </summary>
	public class TCoordinateSystemDecart
	{
		/// <summary>
		/// Высота поля графика
		/// </summary>
		private int height;
		/// <summary>
		/// Ширина поля графика
		/// </summary>
		private int width;
		/// <summary>
		/// Расстояние от поля графика до верхней границы поля рисования
		/// </summary>
		private int top;
		/// <summary>
		/// Расстояние от поля грфика до левой границы поля рисования.
		/// </summary>
		private int left;
		/// <summary>
		/// Нижние показываемые границы значений переменных на графике
		/// </summary>
		private PointF min;
		/// <summary>
		/// Верхние показываемые границы значений переменных на графике
		/// </summary>
		private PointF max;
		/// <summary>
		/// Флаг автовыбора размера поля графика
		/// </summary>
		private bool autoscale;
		/// <summary>
		/// Коллекция фигур, которые будут отображены на графике.
		/// </summary>
		private List<iFigure> figures = new List<iFigure>();

		/// <summary>
		/// Создать пустую систему координат с параметрами по-умолчанию.
		/// Автовыбор границ отображаемых занчений включен.
		/// </summary>
		public TCoordinateSystemDecart()
		{
			this.Autoscale = true;
			this.Height = 100;
			this.Width = 100;
			this.Top = 0;
			this.Left = 0;
		}

		/// <summary>
		/// Создать пустую систему координат с заданными размером и положением.
		/// Автовыбор границ отображаемых занчений отключен.
		/// </summary>
		/// <param name="height">Высота результирующего изображения в пикселях</param>
		/// <param name="width">Ширина результирующего изображения в пикселях</param>
		/// <param name="top">Расстояние от границ поля графика до верхней границы
		/// целевого объекта графики в пикселях</param>
		/// <param name="left">Расстояние от границ поля графика до левой границы
		/// целевого объекта графики в пикселях</param>
		public TCoordinateSystemDecart(int height, int width, int top, int left)
		{
			this.Autoscale = false;
			this.Height = height;
			this.Width = width;
			this.Top = top;
			this.Left = left;
		}

		/// <summary>
		/// Высота поля графика
		/// </summary>
		public int Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		/// <summary>
		/// Ширина поля графика
		/// </summary>
		public int Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		/// <summary>
		/// Расстояние от поля графика до верхней границы поля рисования
		/// </summary>
		public int Top
		{
			get
			{
				return this.top;
			}
			set
			{
				this.top = value;
			}
		}

		/// <summary>
		/// Расстояние от поля грфика до левой границы поля рисования.
		/// </summary>
		public int Left
		{
			get
			{
				return this.left;
			}
			set
			{
				this.left = value;
			}
		}

		/// <summary>
		/// Получить "цену" одной единицы на графике в пикселях.
		/// </summary>
		public PointF One
		{
			get
			{
				return new PointF(this.Width / (max.X - min.X), this.Height / (max.Y - min.Y));
			}
		}

		/// <summary>
		/// Нижние показываемые границы значений переменных на графике.. Если свойство Autoscale == true, этот параметр расчитывается автоматически.
		/// </summary>
		public PointF Min
		{
			get
			{
				//Случай с отключённым автоподбором размеров поля системы координат:
				if (!this.Autoscale) return this.min;

				//Если автоподбор всё-же включен:
				PointF min = new PointF(0, 0), buf;

				//Проверим наличие фигур на графике
				if (this.Figures != null && this.Figures.Count != 0)
				{

					//Вычисляем минимальные значения переменных
					foreach (iFigure f in this.Figures)
					{
						buf = f.Min;
						if (buf.X < min.X) min.X = buf.X;
						if (buf.Y < min.Y) min.Y = buf.Y;
					}
				}
				return min;
			}
			set
			{
				//Задать это свойство можно только если this.Autoscale == false
				if (!this.Autoscale)
					this.min = value;
			}
		}

		/// <summary>
		/// Верхние показываемые границы значений переменных на графике. Если свойство Autoscale == true, этот параметр расчитывается автоматически.
		/// </summary>
		public PointF Max
		{
			get
			{
				//Случай с отключённым автоподбором размеров поля системы координат:
				if (!this.Autoscale) return this.max;

				//Если автоподбор всё-же включен:
				PointF max = new PointF(0, 0), buf;

				//Проверим наличие фигур на графике
				if (this.Figures != null && this.Figures.Count != 0)
				{
					//Вычисляем минимальные значения переменных
					foreach (iFigure f in this.Figures)
					{
						buf = f.Max;
						if (buf.X > max.X) max.X = buf.X;
						if (buf.Y > max.Y) max.Y = buf.Y;
					}
				}
				return max;
			}
			set
			{
				//Задать это свойство можно только если this.Autoscale == false
				if (!this.Autoscale)
					this.max = value;
			}
		}

		/// <summary>
		/// Если true, верхние и нижние показываемые границы значений переменных
		/// будут определяться автоматически по тем фигурам, что размещены на графике.
		/// </summary>
		public bool Autoscale
		{
			get
			{
				return this.autoscale;
			}
			set
			{
				this.autoscale = value;
			}
		}

		/// <summary>
		/// Коллекция фигур, которые будут отображены на графике.
		/// </summary>
		public List<iFigure> Figures
		{
			get
			{
				return this.figures;
			}
			set
			{
				//if (value == null) this.figures = new List<iFigure>();
				this.figures = value;
			}
		}

		/// <summary>
		/// Получить точку на объекте графики, в которой находится начало координат.
		/// </summary>
		public Point Zero
		{
			get
			{
				//Вычисляем "цену" единицы на графике в пикселях.
				PointF one = this.One;
				return new Point(Convert.ToInt32(this.Left + (min.X > 0 ? min.X : -min.X) * one.X), Convert.ToInt32(this.Top + (max.Y > 0 ? max.Y : -max.Y) * one.Y));
			}
		}

		/// <summary>
		/// Отрисовать на объекте графики саму систему координат.
		/// </summary>
		/// <param name="g">Целевой объект графики.</param>
		public void DrawAxis(Graphics g)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Отрисовать все фигуры на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		public void DrawFigures(Graphics g)
		{
			if (this.Figures != null)
			{
				foreach (iFigure f in this.Figures)
				{
					f.Draw(g, this);
				}
			}
		}

		/// <summary>
		/// Получить точку на графическом объекте из точки в системе координат
		/// </summary>
		/// <param name="pt">Точка в этой системе координат</param>
		public Point GetPointOnGraphicsObject(PointF pt)
		{
			//Буферные переменные. Чтобы не гонять расчёт по нескольку раз, когда включен this.Autoscale
			PointF min = this.Min, max = this.Max;

			//Вычисляем "цену" единицы на графике в пикселях.
			PointF one = this.One;

			//Находим положение в пикселях точки {0; 0}
			Point zero = new Point(Convert.ToInt32(this.Left + (min.X > 0 ? min.X : -min.X) * one.X), Convert.ToInt32(this.Top + (max.Y > 0 ? max.Y : -max.Y) * one.Y));

			//Вычисляем положение искомой точки
			return new Point(Convert.ToInt32(zero.X + pt.X * one.X), Convert.ToInt32(zero.Y - pt.Y * one.Y));
		}

		/// <summary>
		/// Получить массив точек на графическом объекте из массива точек в системе координат
		/// </summary>
		/// <param name="ptArray">Точки в этой системе координат</param>
		public Point[] GetPointsOnGraphicsObject(params PointF[] ptArray)
		{
			if (ptArray == null || ptArray.Length == 0) return null;

			int i;
			Point[] res = new Point[ptArray.Length];

			//Буферные переменные. Чтобы не гонять расчёт по нескольку раз, когда включен this.Autoscale
			PointF min = this.Min, max = this.Max;

			//Вычисляем "цену" единицы на графике в пикселях.
			PointF one = this.One;

			//Находим положение в пикселях точки {0; 0}
			Point zero = new Point(Convert.ToInt32(this.Left + (min.X > 0 ? min.X : -min.X) * one.X), Convert.ToInt32(this.Top + (max.Y > 0 ? max.Y : -max.Y) * one.Y));

			//Вычисляем положение искомых точек
			for (i = 0; i < ptArray.Length; i++)
				res[i] = new Point(Convert.ToInt32(zero.X + ptArray[i].X * one.X), Convert.ToInt32(zero.Y - ptArray[i].Y * one.Y));

			return res;
		}

		/// <summary>
		/// Получить точку в системе координат из точки на графическом объекте
		/// </summary>
		/// <param name="pt">Точка на графическом объекте</param>
		public PointF GetPointCoordinates(Point pt)
		{
			//Буферные переменные. Чтобы не гонять расчёт по нескольку раз, когда включен this.Autoscale
			PointF min = this.Min, max = this.Max;

			//Вычисляем "цену" единицы на графике в пикселях.
			PointF one = this.One;

			//Находим положение в пикселях точки {0; 0}
			Point zero = new Point(Convert.ToInt32(this.Left + (min.X > 0 ? min.X : -min.X) * one.X), Convert.ToInt32(this.Top + (max.Y > 0 ? max.Y : -max.Y) * one.Y));

			//Вычисляем координаты искомой точки
			return new PointF((pt.X - zero.X) / one.X, (zero.Y - pt.Y) / one.Y);
		}


		/// <summary>
		/// Получить массив точек в системе координат из массива точек на графическом объекте
		/// </summary>
		/// <param name="ptArray">Точки на графическом объекте</param>
		public PointF[] GetPointsCoordinates(params Point[] ptArray)
		{
			if (ptArray == null || ptArray.Length == 0) return null;

			int i;
			PointF[]res = new PointF[ptArray.Length];

			//Буферные переменные. Чтобы не гонять расчёт по нескольку раз, когда включен this.Autoscale
			PointF min = this.Min, max = this.Max;

			//Вычисляем "цену" единицы на графике в пикселях.
			PointF one = this.One;

			//Находим положение в пикселях точки {0; 0}
			Point zero = new Point(Convert.ToInt32(this.Left + (min.X > 0 ? min.X : -min.X) * one.X), Convert.ToInt32(this.Top + (max.Y > 0 ? max.Y : -max.Y) * one.Y));

			//Вычисляем координаты искомых точек
			for (i = 0; i < ptArray.Length;i++ )
				res[i] = new PointF((ptArray[i].X - zero.X) / one.X, (zero.Y - ptArray[i].Y) / one.Y);

			return res;
		}

		/// <summary>
		/// Проверить, вмещается-ли объект в видимое поле системы координат.
		/// </summary>
		/// <param name="point">Проверяемая точка</param>
		public bool IsInside(PointF point)
		{
			PointF min = this.Min;
			PointF max = this.Max;
			return point.X <= max.X
				&& point.X >= min.X
				&& point.Y <= max.Y 
				&& point.Y >= min.Y;
		}

	}
}
