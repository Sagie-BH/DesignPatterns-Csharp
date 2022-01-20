using System;

namespace NullObjectProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClassA a = new MyClassA();

            if (a.MyClassB.IsNotNull()) // checking for nullability with the extension method
            {
                a.MyClassB.Prop.ToString(); // this gives off a warning/error even if we checked for nullability
                a.MyClassB!.Prop.ToString(); // this not gives off a warning/error because we used the null-forgiving operator
            }

            if (a.MyClassB != null)
            {
                a.MyClassB.Prop
                    .ToString(); // this will not give off a warning/error because the compiler sees that we checked for nullability in this code block
            }

            if (!(a.MyClassB is null))
            {
                a.MyClassB.Prop
                    .ToString(); // this won't throw an warning/error as well because the compiler knows that we're negating a pattern match for null
            }

            if (a.MyClassB is { }) // this is a somewhat better way to check if something not null, instead of pattern matching with null and then negating it
            {
                a.MyClassB.Prop.ToString(); // this also won't throw an warning/error
            }
        }
    }

    class MyClassA
    {
        public MyClassB? MyClassB { get; set; }
    }

    class MyClassB
    {
        public string Prop { get; set; } = string.Empty;
    }

    public static class NullableObjectExtensions
    {
        public static bool IsNull<T>(this T objectInstance) where T : new()
        {
            return objectInstance is null;
        }

        public static bool IsNotNull<T>(this T objectInstance) where T : new()
        {
            return !objectInstance.IsNull();
        }
    }
}
