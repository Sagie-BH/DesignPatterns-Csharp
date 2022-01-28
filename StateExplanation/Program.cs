using System;

namespace StateExplanation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
	public class StateMess 
	{
		private int state = 0;
		private bool charging = true;

		public void PressPowerButton()
		{
			// off
			if (state == 0)
			{
				// do work
				state = 1;
				return;
			}

			// on
			if (state == 1)
			{
				// do work
				if (charging)
				{
					state = 2;
					return;
				}
				state = 0;
				return;
			}

			// standby
			// do work
			state = 1;
		}
	}

}
