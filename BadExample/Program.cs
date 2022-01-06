


MemoryCache.Create();
MemoryCache.Create();
MemoryCache.Create();
MemoryCache.Create();
MemoryCache.Create();


public class MemoryCache
{
	private static MemoryCache _instance;

	private MemoryCache()
	{
        Console.WriteLine("Created");
	}

	public static MemoryCache Create()
	{
		return _instance ?? (_instance = new MemoryCache());
	}
}