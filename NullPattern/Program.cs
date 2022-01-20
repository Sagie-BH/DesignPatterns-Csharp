using System;

namespace NullPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClassA a = new MyClassA();
            Console.WriteLine(a.MyClassB.Prop); // this will display the default text we inputted at creation time
            a.MyClassB.Prop = "456"; // this will throw an exception if we tried and changed it
        }
        class MyClassA
        {
            public MyClassB MyClassB { get; set; } = MyClassB.None;
        }

        class MyClassB
        {
            private string _propValue = string.Empty;

            public static MyClassB None { get; } = new MyClassB
            {
                Prop = "123" // example of default data for our null object
            };

            public string Prop
            {
                get { return _propValue; }
                set
                {
                    if (this == None)
                    {
                        throw new InvalidOperationException($"Cannot set {nameof(Prop)} on instance of {nameof(None)}");
                    }
                    _propValue = value;
                }
            }
        }
    }
}
