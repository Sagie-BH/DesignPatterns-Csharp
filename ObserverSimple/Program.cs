using System;
using System.Collections.Generic;

namespace ObserverSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
	public class Alarm
	{

		List<IWatcher<Alarm>> watchers = new List<IWatcher<Alarm>>();

		public void AddWatcher(IWatcher<Alarm> alarmWatcher)
		{
			watchers.Add(alarmWatcher);
		}

		public void Notify()
		{
			foreach (var w in watchers)
			{
				w.Alert(this);
			}
		}
	}

	public interface IWatcher<T>
	{
		public void Alert(T value);
	}

	public class FireStation : IWatcher<Alarm>
	{
		public void Alert(Alarm value)
		{
            Console.WriteLine(nameof(FireStation) + "RESPONDING!");
		}
	}

	public class PoliceStation : IWatcher<Alarm>
	{
		public void Alert(Alarm value)
		{
            Console.WriteLine(nameof(PoliceStation) + "RESPONDING!");
		}
	}

	public class HospitalStation : IWatcher<Alarm>
	{
		public void Alert(Alarm value)
		{
            Console.WriteLine(nameof(HospitalStation) + "RESPONDING!");
		}
	}

}
