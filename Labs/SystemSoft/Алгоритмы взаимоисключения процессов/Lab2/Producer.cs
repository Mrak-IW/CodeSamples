using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
	public class Producer
	{
		public Sema smf, smf2;			//Ссылки на семафоры
        static public int cntProc = 0;  //Количество процессов

        public int cnt = 0;	        //Счетчик для процесса
        public int num;             //Номер процесса
		public int resCount = 0;	//Количество произведенных ресурсов в 		
		public string[] text = {"void producer<*>()",
								"{",
								"while (1)",
								"    {",
								"        int w_val;",
								"        wait(&smf);",
								"        produce(w_val);",
								"        resCount = 1;",
								"        sigal(&smf);",
								"        signal(&smf2);",
								"    }",
								"}"
							   };

        public Producer(Sema smf, Sema smf2)
        {
			this.smf2 = smf2;
			this.smf = smf;

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
            resCount = 0;
			smf.signal();
			smf2.reset();
        }
        /// <summary>
        /// Следующий шаг алгоритма
        /// </summary>
        public void next()
        {
            switch (cnt)
            {
                case 10:
                    cnt = 2;
                    break;
                case 5:
                    if (!smf.wait())
                        cnt++;
                    break;
				case 7:
                    resCount = 1;
					cnt++;
					break;
				case 8:
					smf.signal();
					cnt++;
					break;
                case 9:
					smf2.signal();
                    cnt++;
                    break;
                default:
                    cnt++;
                    break;
            }
        }
	}
}
