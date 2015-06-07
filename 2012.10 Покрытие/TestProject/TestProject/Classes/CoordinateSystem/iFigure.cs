using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Интерфейс некоторой абстрактной фигуры, которую можно отобразить в системе координат
	/// </summary>
	public interface iFigure
	{
		/// <summary>
		/// Минимальные значений переменных в данной фигуре
		/// </summary>
		PointF Min
		{
			get;
		}

		/// <summary>
		/// Максимальные значений переменных в данной фигуре
		/// </summary>
		PointF Max
		{
			get;
		}

		/// <summary>
		/// Перо для отрисовки линий фигуры
		/// </summary>
		Pen Pen
		{
			get;
			set;
		}

		/// <summary>
		/// Отрисовать фигуру на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="coordinates">Система координат, в которой находится фигура</param>
		void Draw(Graphics g, TCoordinateSystemDecart coordinates);

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="pt">Проверяемая точка</param>
		bool PointIsOnFigure(PointF pt);

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		float GetDistance(PointF pt);

		/// <summary>
		/// Получить точку на фигуре, ближайшую к заданной.
		/// </summary>
		/// <param name="pt">Заданная точка</param>
		PointF GetNearestPoint(PointF pt);
	}
}
