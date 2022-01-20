using System;
using System.Collections.Generic;

namespace FlyweightSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
	public interface IICon
    {

    }
	// flyweight
	public class Icon: IICon
	{
		public Icon(string type)
		{
			// load icon
		}
	}
	public class LogoIcon : IICon
	{
		public LogoIcon(string type)
		{
			// load icon
		}
	}

	static class IconProvider
	{
		private static Dictionary<string, Icon> _cache = new Dictionary<string, Icon>();

		public static Icon GetIcon(string type)
		{
			if (!_cache.ContainsKey(type))
			{
				_cache[type] = new Icon(type);
			}
			return _cache[type];
		}
	}

	abstract class Button
	{
		public Icon Icon { get; set; }
	}

	class SettingsButton : Button
	{
		public SettingsButton()
		{
			Icon = IconProvider.GetIcon("settings");
		}
	}

	class SolutionWindow
	{
		SettingsButton settings = new SettingsButton();
	}

	class TerminalWindow
	{
		SettingsButton settings = new SettingsButton();
	}

	class TestRunnerWindow
	{
		SettingsButton settings = new SettingsButton();
	}
}
