using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class SemaphorProcess
    {
        ///Семафор
		static public Sema smf = new Sema();
        static public int cntProc = 0;  //Количество процессов

        public int cnt = 0;	        //Счетчик для процесса
        public int num;             //Номер процесса
        public string[] text = { "void process<*>()",
								   "{",
								   "while (1)",
								   "    {",
								   "        _Какие - то_операции;",
								   "        wait(&s);",
								   "        _Критическая_секция;",
								   "        signal(&s);",
								   "        _Какие - то_операции;",
								   "    }",
								   "}"
							   };

        public SemaphorProcess()
        {
            num = cntProc;
            cntProc++;
            for (int i = 0; i < text.Length; i++)
                while (text[i].IndexOf("<*>") > 0)
                    text[i] = text[i].Replace("<*>", num.ToString());
        }
        /// <summary>
        /// Сброс семафора и счетчика команд данного процесса
        /// </summary>
        public void reset()
        {
            cnt = 0;
            smf.signal();
        }
        /// <summary>
        /// Следующий шаг алгоритма
        /// </summary>
        public void next()
        {
            switch (cnt)
            {
                case 9:
                    cnt = 2;
                    break;
                case 5:
                    if (!smf.wait())
                        cnt++;
                    break;
                case 7:
					smf.signal();
                    cnt++;
                    break;
                default:
                    cnt++;
                    break;
            }
        }
    }
}
