using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
	public class Method2
	{
		public bool[] inProc = new bool[2];
		public int[] cnt = new int[2];	//Счетчики для процессов
		public string[] text0 = { "void process0()", "{", "while (1)", "    {", "        _Какие - то_операции;", "        while (inProc[1] == true) { };", "        inProc[0] = true;", "        _Критическая_секция;", "        inProc[0] = false;", "        _Какие - то_операции;", "    }", "}" };
		public string[] text1 = { "void process1()", "{", "while (1)", "    {", "        _Какие - то_операции;", "        while (inProc[0] == true) { };", "        inProc[1] = true;", "        _Критическая_секция;", "        inProc[1] = false;", "        _Какие - то_операции;", "    }", "}" };

		public void reset()
		{
			inProc[0] = false;
			inProc[1] = false;
			cnt[0] = 0;
			cnt[1] = 0;
		}

		public void next0()
		{
			switch (cnt[0])
			{
				case 5:
					if (!inProc[1])
						cnt[0]++;
					break;
				case 6:
					inProc[0] = true;
					cnt[0]++;
					break;
				case 8:
					inProc[0] = false;
					cnt[0]++;
					break;
				case 10:
					cnt[0] = 2;
					break;
				default:
					cnt[0]++;
					break;
			}
		}

		public void next1()
		{
			switch (cnt[1])
			{
				case 5:
					if (!inProc[0])
						cnt[1]++;
					break;
				case 6:
					inProc[1] = true;
					cnt[1]++;
					break;
				case 8:
					inProc[1] = false;
					cnt[1]++;
					break;
				case 10:
					cnt[1] = 2;
					break;
				default:
					cnt[1]++;
					break;
			}
		}
	}
}
