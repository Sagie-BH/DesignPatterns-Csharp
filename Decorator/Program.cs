using System;
using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
        public interface IMenu
        {
            IEnumerable<IMenuItem> Items { get; }
        }
    
}
