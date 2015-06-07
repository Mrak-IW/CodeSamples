using System;
using System.Collections.Generic;
using System.Text;

namespace GraphEditor
{
	public enum EdgeTypes
	{
		/// <summary>
		/// Вершина со значением
		/// </summary>
		Regular = 0,
		/// <summary>
		/// Логическая вершина. И
		/// </summary>
		AND = 1,
		/// <summary>
		/// Логическая вершина. ИЛИ
		/// </summary>
		OR = 2,
		/// <summary>
		/// Логическая вершина. Исключающее ИЛИ
		/// </summary>
		/// 
		XOR = 3,
		/// <summary>
		/// Логическая вершина. Выбор минимума
		/// </summary>
		MIN = 4,
		/// <summary>
		/// Операторная вершина. Принимает значение суммы значений всех вершин на входящих дугах.
		/// </summary>
		SUM = 5
	}
}
