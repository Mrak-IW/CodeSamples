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
		private Pen pen;
		/// <summary>
		/// Список вершин полигона, соединённых рёбрами последовательно.
		/// </summary>
		private List<PointF> points;

		/// <summary>
		/// Создать "пустой" полигон. Без единой вершины.
		/// </summary>
		public TPolygon()
		{ }

		/// <summary>
		/// Создать полигон из произвольного количества точек. Повторяющиеся подряд точки будут отброшены.
		/// </summary>
		/// <param name="points">Массив точек</param>
		public TPolygon(PointF pt1, params PointF[] points)
		{
			this.points = new List<PointF>();
			this.points.Add(pt1);
			PointF last = pt1;
			foreach (PointF p in points)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualPointF(p, last))
				{
					this.points.Add(p);
					last = p;
				}
			}
		}

		/// <summary>
		/// Создать полигон из произвольного количества точек.
		/// </summary>
		/// <param name="points">Координаты точек в порядке: x1, y1, x2, y2...</param>
		public TPolygon(float x1, float y1, params float[] xy)
		{
			PointF p;
			PointF last;
			int i;

			this.points = new List<PointF>();

			p = new PointF(x1, y1);
			this.points.Add(p);
			last = p;

			//Если координат окажется нечётное количество, последняя отбрасывается.
			for (i = 0; i < xy.Length - xy.Length % 2; i+=2)
			{
				//Проверяем, не совпадает ли добавляемая точка с последней добавленной
				if (!TConstants.IsEqualFloat(xy[i], last.X) || !TConstants.IsEqualFloat(xy[i+1], last.Y))
				{
					p = new PointF(xy[i], xy[i + 1]);
					this.points.Add(p);
					last = p;
				}
			}
		}

		/// <summary>
		/// Список вершин полигона, соединённых рёбрами последовательно.
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
		/// Определяет, находится ли точка внутри данной фигуры
		/// </summary>
		/// <param name="pt">Точка в системе координат</param>
		public bool PointIsInside(PointF pt)
		{
			//Вычисления ведутся по методу трассировки луча
			//Проводим горизонтальный луч из проверяемой точки
			TRay ray = new TRay(pt, new PointF(1, 0));
			List<PointF> crosspoints = this.GetCrosspoints(ray);
			return crosspoints != null ? (crosspoints.Count % 2 != 0) : false;
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
		/// <param name="coordinates">Система координат, в которой находится фигура</param>
		public void Draw(Graphics g, TCoordinateSystemDecart coordinates)
		{
			//g.FillPolygon(
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="pt">Проверяемая точка</param>
		public bool PointIsOnFigure(PointF pt)
		{
			return false;
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
				if (this.Points == null || this.Points.Count < 2) return null;

				int i;
				TSegment[] res = new TSegment[this.points.Count];

				for (i = 0; i < res.Length - 1; i++)
				{
					res[i] = new TSegment(this.points[i], this.points[i + 1]);
				}
				res[i] = new TSegment(this.points[i], this.points[0]);

				return res;
			}
		}

		/// <summary>
		/// Получить все точки пересечения полигона с лучём
		/// </summary>
		/// <param name="ray">Целевой луч</param>
		public List<PointF> GetCrosspoints(TRay ray)
		{
			//Реализуется метод трассировки луча
			List<PointF> crosspoints = new List<PointF>();
			PointF cp;

			//Получаем массив отрезков, из которых состоит полигон:
			TSegment[] edges = this.Segments;

			foreach (TSegment e in edges)
			{
				//Пересечение считается только в том случае, если луч проходит не по нижнему концу отрезка.
				if (ray.IsCrossing(e, out cp) && !TConstants.IsEqualFloat(cp.Y, e.Min.Y))
				{
					crosspoints.Add(cp);
				}
			}

			if (crosspoints.Count == 0)
				return null;
			else 
				return crosspoints;
		}
	}
}
