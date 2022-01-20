using System;
using System.Collections.Generic;

namespace ObserverNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
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

	public class FireStation : IObserver<int>
	{
		public void Alert(Alarm value)
		{
			nameof(FireStation).Dump("RESPONDING!"); //RESPONDING!
		}

		public void OnCompleted()
		{
			nameof(FireStation).Dump("complete");
		}

		public void OnError(Exception error)
		{
			nameof(FireStation).Dump("error");
		}

		public void OnNext(int value)
		{
			nameof(FireStation).Dump("next: " + value);
		}
	}
}
