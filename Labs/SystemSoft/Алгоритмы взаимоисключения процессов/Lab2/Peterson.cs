using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
	public class MethodPeterson
	{
		public static int ProcessCnt = 0;	//Количество процессов, созданных в программе
		public int ID;						//Идентификатор данного процесса
		public static bool[] inProc;
		public static int numProc = 0;		//Номер избранного процесса
		public int cnt = 0;					//Счетчики для процессов
		public string[] text;

		public MethodPeterson()
		{
			ID = ProcessCnt;
			ProcessCnt++;

			string[] buf = {"void process"+ID+"()",
						"{", "while (1)", 
						"    {", 
						"        _Какие - то_операции;",
						"        inProc["+ID+"] = true;",
						"        numProc = "+(1-ID)+";",
						"        while (inProc["+(1-ID)+"] && (numProc == "+(1-ID)+")) {};",
						"        _Критическая_секция;",
						"        inProc["+ID+"] = false;",
						"        _Какие - то_операции;",
						"    }",
						"}" };
			text = buf;

			inProc = new bool[ProcessCnt];
		}

		public void reset()
		{
			inProc[ID] = false;
			numProc = 0;
			cnt = 0;
		}

		public void next()
		{
			switch (cnt)
			{
				case 5:
					inProc[ID] = true;
					cnt++;
					break;
				case 6:
					numProc = (ID + 1) % ProcessCnt;
					cnt++;
					break;
				case 7:
					if (!(inProc[(ID + 1) % ProcessCnt] && numProc == (ID + 1) % ProcessCnt))
						cnt++;
					break;
				case 9:
					inProc[ID] = false;
					cnt++;
					break;
				case 11:
					cnt = 2;
					break;
				default:
					cnt++;
					break;
			}
		}
	}
}
