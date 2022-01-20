using System;

namespace MementoSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
	public class A
	{
		// Getting access private propery / field - loose coupeling 
		private int c;   // memento
		int Do(A a) => a.c;
		A GetState() => new A();
	}


	public class B
	{
		private int c; // memento
		public class C	// still nested
		{
			public int Do(B b) => b.c;
			public B GetState() => new B();
		}
	}
	// No knowing of Concrete C
	public class D
	{
		// inheriting from a blank interface
		public interface C { }
		private class E : C
		{
			public int c;
		}
		private E e;
		public int Do(C b) => ((E)b).c; // casting it
		public C GetState() => e;
	}

}
