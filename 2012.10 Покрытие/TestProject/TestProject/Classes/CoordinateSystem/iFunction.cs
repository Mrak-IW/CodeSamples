using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Класс представляет собой график некоторой функции.
	/// </summary>
	public interface iFunction : iFigure
	{
		/// <summary>
		/// Получить значение Y при заданном значении X
		/// </summary>
		/// <param name="X">Значение X</param>
		float GetY(float X);
	}
}
