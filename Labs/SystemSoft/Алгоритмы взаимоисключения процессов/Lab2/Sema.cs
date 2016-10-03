namespace Lab2
{
	public class Sema
	{
		private bool semafor = true;
		public bool wait()
		{
			bool buf = true;
			if (semafor)
			{
				semafor = false;
				buf = false;
			}
			return buf;
		}
		public void signal()
		{
			semafor = true;
		}
		public void reset()
		{
			semafor = false;
		}
		public bool Value
		{
			get { return semafor; }
		}
		public override string ToString()
		{
			return semafor.ToString();
		}
	}
}
