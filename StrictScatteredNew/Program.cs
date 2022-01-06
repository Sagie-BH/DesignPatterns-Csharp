using System;
using System.Configuration;

namespace StrictScatteredNew
{
    class Program
    {
        static void Main(string[] args)
        {
            //var myObj = new ConcreteObject();
            var myObj = ObjectFactory.Create();
        }
    }
    class ConcreteObject: IObject
    {
        public ConcreteObject(int num)
        {
            Num = num;
        }

        public int Num { get; }

        public void DoSomething()
        {
            Console.WriteLine("I did it");
        }
    }
    interface IObject
    {
        void DoSomething();
    }
    // יצירת האובייקט עוברת למחלקה אחרת
    static class ObjectFactory
    {
        public static IObject Create()
        {
            // אפשר לשנות את האובייקט בזמן ריצה
            var condition = ConfigurationManager.AppSettings["Condition"];

            if (condition == "") return new ConcreteObject(123);
            else return new NewConcreteObject();
        }
    }
    class NewConcreteObject : IObject
    {
        public void DoSomething()
        {
            Console.WriteLine("I did it in a new way");
        }
    }
}
