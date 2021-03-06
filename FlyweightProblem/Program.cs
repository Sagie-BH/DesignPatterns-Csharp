using System;

namespace FlyweightProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

	public class Icon
	{
		public Icon(string path)
		{
			// load icon
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
			Icon = new Icon("path_to_settings_icon");
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
