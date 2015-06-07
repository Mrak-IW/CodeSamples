using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using NSGraphic;

namespace CodeDivision
{
	public class TTestMethods
	{
		/// <summary>
		/// Функция корелляции между двумя массивами чисел.
		/// </summary>
		public int[] Corellation(int[] array1, int[] array2)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Отрисовать график корелляции между двумя массивами
		/// </summary>
		/// <param name="gr">Объект графики, на котором нужно отобразить функцию корелляции</param>
		/// <param name="position">Позиция и размеры рисунка на объекте графики</param>
		/// <param name="arr1Name">Имя первого массива</param>
		/// <param name="arr2Name">Имя второго массива</param>
		/// <param name="pen">Стиль линии</param>
		public void CorellationDraw(Graphics gr, int[] array1, int[] array2, Rectangle position, string arr1Name, string arr2Name, Pen pen)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Функция отрисует на одном графике графики автокорелляций всех трёх массивов, а также все варианты их корелляции попарно.
		/// </summary>
		/// <param name="gr">Объект графики, на котором нужно отобразить функцию корелляции</param>
		/// <param name="position">Позиция и размеры рисунка на объекте графики</param>
		/// <param name="arr1Name">Имя первого массива</param>
		/// <param name="arr2Name">Имя второго массива</param>
		/// <param name="arr3Name">Имя третьего массива</param>
		public void CorellationDraw(Graphics gr, int[] array1, int[] array2, int[] array3, Rectangle position, string arr1Name, string arr2Name, string arr3Name)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Отрисовать график функции автокорелляции массива
		/// </summary>
		/// <param name="gr">Объект графики, на котором нужно отобразить функцию корелляции</param>
		/// <param name="position">Позиция и размеры рисунка на объекте графики</param>
		/// <param name="pen">Стиль линии</param>
		/// <param name="arr1Name">Имя первого массива</param>
		/// <param name="arr2Name">Имя второго массива</param>
		public void AutoCorellationDraw(Graphics gr, int[] array, Rectangle position, string arrName, Pen pen)
		{
			throw new System.NotImplementedException();
		}
	}
}
