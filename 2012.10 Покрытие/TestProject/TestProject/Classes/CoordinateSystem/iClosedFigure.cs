using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Интерфейс фигуры, которая представляет собой замкнутый контур
	/// </summary>
	public interface iClosedFigure : iFigure
	{
		/// <summary>
		/// Кисть для заливки фигуры.
		/// </summary>
		Brush Brush
		{
			get;
			set;
		}
		/// <summary>
		/// Определяет, находится ли точка внутри данной фигуры
		/// </summary>
		/// <param name="point">Проверяемая точка</param>
		bool PointIsInside(PointF point);
	}
}
