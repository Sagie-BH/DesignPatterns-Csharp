// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int size = 8;
Task[] tasks = new Task[size];
for (int i = 0; i < size; i++)
{
	tasks[i] = Task.Run(() => MemoryCache.Create());
}
Task.WaitAll(tasks);
//MemoryCache.Create();



public class MemoryCache
{
	private static int i = 0;
	private static MemoryCache _instance;

	static MemoryCache()
	{
		_instance = new MemoryCache();
	}

	private MemoryCache()
	{
        Console.WriteLine($"Created {i++}");
	}

	public static MemoryCache Create()
	{
		return _instance;
	}
}