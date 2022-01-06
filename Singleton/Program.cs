// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class MySimpleSingleton
{
    public static MySimpleSingleton Instance { get; } = new MySimpleSingleton();

    private MySimpleSingleton() { }
}


public class MySingletonWithLock
{
    private readonly static object _myLock = new object();

    private static MySingletonWithLock _instance;
    private MySingletonWithLock() { }

    public static MySingletonWithLock Create()
    {
        lock (_myLock)
        {
            if (_instance == default(MySingletonWithLock))
            {
                _instance = new MySingletonWithLock();
            }
        }
        return _instance;
    }
}

public class MyAmbientContext
{
    public static MyAmbientContext Current { get; } = new MyAmbientContext();

    private MyAmbientContext() { }

    public void WriteSomething(string something)
    {
        Console.WriteLine($"This is your something: {something}");
    }
}