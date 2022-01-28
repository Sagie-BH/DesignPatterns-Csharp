using System;
using System.Collections.Generic;

namespace ObserverFireStation
{
    // With c# support
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
	//  IObservable - What to watch
	public class Alarm : IObservable<int>, IDisposable
	{
		List<IObserver<int>> watchers = new List<IObserver<int>>();

		public IDisposable Subscribe(IObserver<int> observer)
		{
			watchers.Add(observer);
			return this;
		}
		int i = 0;

		public void Notify()
		{
			if (i > 3)
			{
				watchers.ForEach(x => x.OnCompleted());
				return;
			}

			watchers.ForEach(x => x.OnNext(i++));
		}

		public void Dispose() => throw new NotImplementedException();
	}
	// IObserver - Watcher
	public class FireStation : IObserver<int>
	{
		public void Alert(Alarm value)
		{
			Console.WriteLine(nameof(FireStation) + "RESPONDING!");
		}

		public void OnCompleted()
		{
			Console.WriteLine(nameof(FireStation) + "COMPLETE!");
		}

		public void OnError(Exception error)
		{
			Console.WriteLine(nameof(FireStation) + "ERROR: " + error);
		}

		public void OnNext(int value)
		{
			Console.WriteLine(nameof(FireStation) + "NEXT: " + value);
		}
	}
}
