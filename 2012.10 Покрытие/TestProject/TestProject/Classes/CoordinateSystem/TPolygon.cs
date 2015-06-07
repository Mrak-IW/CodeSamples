using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Фигура - замкнутый многоугольник, заданый массивом точек, соединённых линией в порядке следования.
	/// </summary>
	public class TPolygon : iClosedFigure
	{
		/// <summary>
		/// Кисть для заливки фигуры.
		/// </summary>
		private Brush brush;
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		private Pen pen = Pens.Black;
		/// <summary>
		/// Список вершин полигона, соединённых рёбрами последовательно.
		/// </summary>
		private PointF[] points;

		/// <summary>
		/// Создать "пустой" полигон. Без единой вершины.
		/// </summary>
		public TPolygon()
		{ }

		/// <summary>
		/// Создать полигон из произвольного количества точек. Повторяющиеся подряд точки будут отброшены.
		/// </summary>
		/// <param name="pt1">Первая и обязательная для указания точка</param>
		/// <param name="points">Массив точек. При вызове функции его можно не указывать</param>
		public TPolygon(PointF pt1, params PointF[] points)
		{
			int i, j;
			this.points = new PointF[points.Length + 1];
			this.points[0] = pt1;
			PointF last = pt1;
			for (i = 0, j = 1; i < points.Length; i++)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualPointF(points[i], last))
				{
					this.points[j] = points[i];
					last = points[i];
					j++;
				}
			}
			j--;	//Возвращаем j на последний добавленный элемент.

			//Проверяем, не совпала-ли последняя добавленная точка с первой:
			if (TConstants.IsEqualPointF(this.points[0], this.points[j]))
			{
				j--;
			}

			//Если это необходимо, уменьшаем массив точек под размеры содержимого
			if (j < points.Length)
			{
				PointF[] buf = new PointF[j + 1];
				for (i = 0; i < buf.Length; i++)
				{
					buf[i] = this.points[i];
				}
				this.points = buf;
			}
		}

		/// <summary>
		/// Создать полигон из произвольного количества точек.
		/// </summary>
		/// <param name="xy">Координаты точек в порядке: x2, y2, x3, y3...</param>
		/// <param name="x1">Координата первой точки</param>
		/// <param name="y1">Координата первой точки</param>
		public TPolygon(float x1, float y1, params float[] xy)
		{
			PointF p;
			PointF last;
			int i, j;
			//int fix = 0;

			p = new PointF(x1, y1);
			if (xy != null)	//Проверяем, не пуст ли список необязательных вершин xy
				this.points = new PointF[(xy.Length - xy.Length % 2) / 2 + 1];
			else				//Если пуст, добавляем туда обязательную вершину и выходим.
			{
				this.points = new PointF[1];
				this.points[0] = p;
				return;
			}
			this.points[0] = p;
			last = p;

			//Если координат окажется нечётное количество, последняя отбрасывается.
			for (i = 0, j= 1; i < xy.Length - xy.Length % 2 /*+ fix*/; i += 2)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualFloat(xy[i], last.X) || !TConstants.IsEqualFloat(xy[i + 1], last.Y))
				{
					p = new PointF(xy[i], xy[i + 1]);
					this.points[j] = p;
					last = p;
					j++;	//j - индекс последней добавленной точки
				}
			}

			j--;	//Возвращаем j на последний добавленный элемент.

			//Проверяем, не совпала-ли последняя добавленная точка с первой:
			if (TConstants.IsEqualPointF(this.points[0], this.points[j]))
			{
				j--;
			}

			//Если это необходимо, уменьшаем массив точек под размеры содержимого
			if (j < xy.Length / 2)
			{
				PointF[] buf = new PointF[j + 1];
				for (i = 0; i < buf.Length; i++)
				{
					buf[i] = this.points[i];
				}
				this.points = buf;
			}
		}

		/// <summary>
		/// Создать полигон из списка точек
		/// </summary>
		/// <param name="points">Список точек</param>
		public TPolygon(List<PointF> points)
		{
			int i, j;
			this.points = new PointF[points.Count];
			PointF last = new PointF(float.NaN, float.NaN);
			for (i = 0, j = 0; i < this.points.Length; i++)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualPointF(points[i], last))
				{
					this.points[j] = points[i];
					last = points[i];
					j++;
				}
			}

			j--;	//Возвращаем j на последний добавленный элемент.

			//Проверяем, не совпала-ли последняя добавленная точка с первой:
			if (TConstants.IsEqualPointF(this.points[0], this.points[j]))
			{
				j--;
			}

			//Если это необходимо, уменьшаем массив точек под размеры содержимого
			if (j < points.Count - 1)
			{
				PointF[] buf = new PointF[j + 1];
				for (i = 0; i < buf.Length; i++)
				{
					buf[i] = this.points[i];
				}
				this.points = buf;
			}
		}

		/// <summary>
		/// Создать полигон, замкнув концы ломаной линии
		/// </summary>
		/// <param name="src"></param>
		public TPolygon(TLineCracked src)
			: this(src.Points)
		{
			this.pen = src.Pen;
			//this.Brush = src.Pen.Brush;
		}

		/// <summary>
		/// Список вершин полигона, соединённых рёбрами последовательно.
		/// </summary>
		public PointF[] Points
		{
			get
			{
				return this.points;
			}
			set
			{
				this.points = value;
			}
		}

		#region iClosedFigure Members

		/// <summary>
		/// Кисть для заливки фигуры.
		/// </summary>
		public Brush Brush
		{
			get
			{
				return this.brush;
			}
			set
			{
				this.brush = value;
			}
		}
		/// <summary>
		/// Определяет, находится ли точка внутри данной фигуры. Точка на границе фигуры тоже считается.
		/// </summary>
		/// <param name="pt">Точка в системе координат</param>
		public bool PointIsInside(PointF pt)
		{
			//Вычисления ведутся по методу трассировки луча
			//Проводим горизонтальный луч из проверяемой точки
			TRay ray = new TRay(pt, new PointF(1, 0));
			List<PointF> crosspoints = TTests.GetCrosspoints(this, ray);
			return (crosspoints != null ? (crosspoints.Count % 2 != 0) : false) || PointIsOnFigure(pt);
		}

		#endregion iClosedFigure Members

		#region iFigure Members

		/// <summary>
		/// Получить минимальные значений переменных в данной фигуре.
		/// Рекомендуется буферизовать полученное значение перед активным использованием
		/// для ускорения работы.
		/// </summary>
		public PointF Min
		{
			get
			{
				int i;
				PointF res;
				if (this.points != null && this.points.Length > 0)
				{
					res = new PointF(this.points[0].X, this.points[0].Y);
					for (i = 1; i < this.points.Length; i++)
					{
						if (this.points[i].X < res.X) res.X = this.points[i].X;
						if (this.points[i].Y < res.Y) res.Y = this.points[i].Y;
					}
				}
				else
					res = new PointF(float.NaN, float.NaN);
				return res;
			}
		}

		/// <summary>
		/// Максимальные значений переменных в данной фигуре.
		/// Рекомендуется буферизовать полученное значение перед активным использованием
		/// для ускорения работы.
		/// </summary>
		public PointF Max
		{
			get
			{
				int i;
				PointF res;
				if (this.points != null && this.points.Length > 0)
				{
					res = new PointF(this.points[0].X, this.points[0].Y);
					for (i = 1; i < this.points.Length; i++)
					{
						if (this.points[i].X > res.X) res.X = this.points[i].X;
						if (this.points[i].Y > res.Y) res.Y = this.points[i].Y;
					}
				}
				else
					res = new PointF(float.NaN, float.NaN);
				return res;
			}
		}

		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		public Pen Pen
		{
			get
			{
				return this.pen;
			}
			set
			{
				this.pen = value;
			}
		}

		/// <summary>
		/// Отрисовать фигуру на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="cs">Система координат, в которой находится фигура</param>
		public void Draw(Graphics g, TCoordinateSystemDecart cs)
		{
			Point[] corners = cs.GetPointsOnGraphicsObject(this.points);
			TDot dot;
			switch (this.points.Length)
			{
				case 0:
					break;
				case 1:	//Отрисовка начальной точки
					dot = new TDot(this.Points[0]);
					
					if (this.pen != null)
					{
						dot.Brush = this.Pen.Brush;
						dot.Diameter = this.Pen.Width;
					}
					else if (this.brush != null)
					{
						dot.Brush = this.Brush;
					}

					dot.Draw(g, cs);
					break;
				default:
					if (this.brush != null)
						g.FillPolygon(this.brush, corners);
					if (this.pen != null)
						g.DrawPolygon(this.pen, corners);
					break;
			}
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="pt">Проверяемая точка</param>
		public bool PointIsOnFigure(PointF pt)
		{
			TSegment[] segments = this.Segments;
			foreach (TSegment s in segments)
			{
				if (s.PointIsOnFigure(pt))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public float GetDistance(PointF pt)
		{
			float distance, buf;
			TSegment[] segments;
			int i;

			if (this.Points.Length == 1)
			{
				distance = TTests.GetDistance(pt, this.Points[0]);
			}
			else
			{
				segments = this.Segments;
				distance = segments[0].GetDistance(pt);
				for (i = 1; i < segments.Length; i++)
				{
					buf = segments[i].GetDistance(pt);
					if (buf < distance)
						distance = buf;
				}
			}
			return distance;
		}

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public PointF GetNearestPoint(PointF pt)
		{
			float distance, buf;
			TSegment[] segments;
			PointF res;
			int i;

			res = this.Points[0];
			if (this.Points.Length > 1)
			{
				segments = this.Segments;
				res = segments[0].GetNearestPoint(pt);
				distance = segments[0].GetDistance(pt);
				for (i = 1; i < segments.Length; i++)
				{
					buf = segments[i].GetDistance(pt);
					if (buf < distance)
					{
						distance = buf;
						res = segments[i].GetNearestPoint(pt);
					}
				}
			}
			return res;
		}

		#endregion iFigure Members

		/// <summary>
		/// Получить массив отрезков-граней, из которых состоит полигон.
		/// Для экономии времени выполнения, рекомендуется буферизовать
		/// полученный массив перед активным его использованием,
		/// поскольку он каждый раз создаётся заново.
		/// </summary>
		public TSegment[] Segments
		{
			get
			{
				if (this.Points == null || this.Points.Length < 2) return null;

				int i;
				TSegment[] res = new TSegment[this.points.Length];

				for (i = 0; i < res.Length - 1; i++)
				{
					res[i] = new TSegment(this.points[i], this.points[i + 1]);
				}
				res[i] = new TSegment(this.points[i], this.points[0]);

				return res;
			}
		}

		

	}
}
