using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace CoordinateSystem
{
	/// <summary>
	/// Модель ломаной линии, заданной набором точек-вершин.
	/// </summary>
	public class TLineCracked : iFigure
	{
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		private Pen pen = Pens.Black;
		/// <summary>
		/// Список вершин ломаной, соединённых рёбрами последовательно.
		/// </summary>
		private List<PointF> points;

		/// <summary>
		/// Создать "пустую" ломаную. Без единой вершины.
		/// </summary>
		public TLineCracked()
		{ }

		/// <summary>
		/// Создать ломаную из произвольного количества точек. Повторяющиеся подряд точки будут отброшены.
		/// </summary>
		/// <param name="points">Массив точек</param>
		/// <param name="pt1">Первая точка</param>
		public TLineCracked(PointF pt1, params PointF[] points)
		{
			int i;
			this.points = new List<PointF>();
			this.points.Add(pt1);
			PointF last = pt1;
			for (i = 0; i < points.Length; i++)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualPointF(points[i], last))
				{
					this.points.Add(points[i]);
					last = points[i];
				}
			}
		}

		/// <summary>
		/// Создать ломаную из произвольного количества точек.
		/// </summary>
		/// <param name="xy">Координаты точек в порядке: x1, y1, x2, y2...</param>
		/// <param name="x1">Координата первой точки</param>
		/// <param name="y1">Координата первой точки</param>
		public TLineCracked(float x1, float y1, params float[] xy)
		{
			PointF p;
			PointF last;
			int i, j;

			this.points = new List<PointF>();

			p = new PointF(x1, y1);
			this.points.Add(p);
			last = p;

			//Если координат окажется нечётное количество, последняя отбрасывается.
			for (i = 0, j= 1; i < xy.Length - xy.Length % 2; i += 2, j++)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualFloat(xy[i], last.X) || !TConstants.IsEqualFloat(xy[i + 1], last.Y))
				{
					p = new PointF(xy[i], xy[i + 1]);
					this.points.Add(p);
					last = p;
				}
			}
		}

		/// <summary>
		/// Список вершин ломаной, соединённых рёбрами последовательно.
		/// </summary>
		public List<PointF> Points
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
				if (this.points != null && this.points.Count > 0)
				{
					res = new PointF(this.points[0].X, this.points[0].Y);
					for (i = 1; i < this.points.Count; i++)
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
				if (this.points != null && this.points.Count > 0)
				{
					res = new PointF(this.points[0].X, this.points[0].Y);
					for (i = 1; i < this.points.Count; i++)
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
			TDot dot;
			switch (this.points.Count)
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

					dot.Draw(g, cs);
					break;
				default:
					Point[] corners = cs.GetPointsOnGraphicsObject(this.GetPointsArray());
					if (this.pen != null)
						g.DrawLines(this.pen, corners);
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

			if (this.Points.Count == 1)
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
			if (this.Points.Count > 1)
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
		/// Получить массив отрезков-граней, из которых состоит ломаная.
		/// Для экономии времени выполнения, рекомендуется буферизовать
		/// полученный массив перед активным его использованием,
		/// поскольку он каждый раз создаётся заново.
		/// </summary>
		public virtual TSegment[] Segments
		{
			get
			{
				if (this.Points == null || this.Points.Count < 2) return null;

				int i;
				TSegment[] res = new TSegment[this.points.Count - 1];

				for (i = 0; i < res.Length; i++)
				{
					res[i] = new TSegment(this.points[i], this.points[i + 1]);
				}

				return res;
			}
		}

		

		/// <summary>
		/// Получить массив точек-углов ломаной
		/// </summary>
		public PointF[] GetPointsArray()
		{
			int i;
			PointF[] res = new PointF[this.points.Count];
			for (i = 0; i < res.Length; i++)
			{
				res[i] = this.points[i];
			}
			return res;
		}

	}
}
