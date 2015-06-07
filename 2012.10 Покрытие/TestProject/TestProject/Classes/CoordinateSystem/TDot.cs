using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Точка в системе координат. Задаётся своими координатами и параметрами отрисовки.
	/// </summary>
	public class TDot:iFigure
	{
		/// <summary>
		/// Диаметр отображаемой точки в пикселях
		/// </summary>
		float size = 4;
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		private Pen pen;
		/// <summary>
		/// Кисть для заливки фигуры.
		/// </summary>
		private Brush brush = Brushes.Black;
		/// <summary>
		/// Собственно позиция точки в системе координат
		/// </summary>
		public PointF point;
	
		/// <summary>
		/// Создать точку с параметрами по-умолчанию
		/// </summary>
		public TDot()
		{ }

		/// <summary>
		/// Создать объект на основе точки с float-координатами
		/// </summary>
		/// <param name="point">Точка</param>
		public TDot(PointF point)
		{
			this.point = point;
		}

		/// <summary>
		/// Создать объект на основе float-координат
		/// </summary>
		public TDot(float x, float y)
		{
			this.point = new PointF(x, y);
		}

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
		/// Диаметр отображаемой точки в пикселях
		/// </summary>
		public float Diameter
		{
			get { return this.size; }
			set { this.size = value; }
		}

		#region iFigure Members

		/// <summary>
		/// Минимальные значений переменных в данной фигуре
		/// </summary>
		public PointF Min
		{
			get { return point; }
		}

		/// <summary>
		/// Максимальные значений переменных в данной фигуре
		/// </summary>
		public PointF Max
		{
			get { return point; }
		}

		/// <summary>
		/// Перо для отрисовки линий фигуры
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
		public virtual void Draw(Graphics g, TCoordinateSystemDecart cs)
		{
			Point pos = cs.GetPointOnGraphicsObject(this.point);
			if (this.brush != null)
			{
				g.FillEllipse(this.brush, pos.X - this.size / 2, pos.Y - this.size / 2, this.size, this.size);
			}

			if (this.pen != null)
			{
				g.DrawEllipse(this.pen, pos.X - this.size / 2, pos.Y - this.size / 2, this.size, this.size);
			}
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="pt">Проверяемая точка</param>
		public bool PointIsOnFigure(PointF pt)
		{
			return TConstants.IsEqualPointF(this.point, pt);
		}

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public float GetDistance(PointF pt)
		{
			return (float)Math.Sqrt((pt.X - this.point.X) * (pt.X - this.point.X) + (pt.Y - this.point.Y) * (pt.Y - this.point.Y));
		}

		/// <summary>
		/// Получить точку на фигуре, ближайшую к заданной.
		/// </summary>
		/// <param name="pt">Заданная точка</param>
		public PointF GetNearestPoint(PointF pt)
		{
			return point;
		}

		#endregion
	}
}
