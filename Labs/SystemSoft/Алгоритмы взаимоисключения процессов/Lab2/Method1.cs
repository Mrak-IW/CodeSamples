using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
	public class Method1
	{
		public int numProc = 0;
		public int cntL = 0;	//Счетчик для левого процесса
		public int cntR = 0;	//Счетчик для правого процесса
        public string[] textL = { "void process0()", "{", "while (1)", "    {", "        _Какие - то_операции;", "        while (numProc != 0) { }", "        _Критическая_секция;", "        numProc = 1;", "        _Какие - то_операции;", "    }", "}" };
        public string[] textR = { "void process1()", "{", "while (1)", "    {", "        _Какие - то_операции;", "        while (numProc != 1) { }", "        _Критическая_секция;", "        numProc = 0;", "        _Какие - то_операции;", "    }", "}" };

		public void reset()
		{
			numProc = 0;
			cntL = 0;
			cntR = 0;
		}

		public void nextLeft()
		{
			switch (cntL)
			{
				case 9:
					cntL = 2;
					break;
				case 5:
					if (numProc == 0)
						cntL++;
					break;
				case 7:
					numProc = 1;
					cntL++;
					break;
                default:
                    cntL++;
                    break;
			}
		}

		public void nextRight()
		{
			switch (cntR)
			{
                case 9:
                    cntR = 2;
                    break;
                case 5:
                    if (numProc == 1)
                        cntR++;
                    break;
                case 7:
                    numProc = 0;
                    cntR++;
                    break;
                default:
                    cntR++;
                    break;
			}
		}
	}
}
