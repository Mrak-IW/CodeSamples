using System;
using System.Collections.Generic;
using System.Text;

namespace GraphEditor
{
	public class TAnRec
	{
		public double begin = 0, end = 0;

		/// <summary>
		/// Если число входит в интервал, вернет описание, заданное для этого интервала, иначе - пустую строку.
		/// </summary>
		/// <param name="val">Тестируемое число</param>
		/// <returns></returns>
		public string TestValue(double val)
		{ 
			string res="";

			if (val >= begin && val < end)
				res = description;

			return res;
		}

		public string description = "";

		public override string ToString()
		{
			return begin.ToString() + "\n" + end.ToString() + "\n" + description.Replace("\r", "<r>").Replace("\n", "<n>").Replace("\t", "<t>").Replace(" ","<s>");
		}
	}
}
