// See https://aka.ms/new-console-template for more information
public sealed class MySingleton
{
    private static MySingleton _instance;

    private MySingleton() { }

    public static MySingleton Create()
    {
        if (_instance == default(MySingleton))
        {
            _instance = new MySingleton();
        }
        return _instance;
    }
}