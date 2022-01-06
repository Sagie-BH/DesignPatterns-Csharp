using System;
using System.Collections.Generic;

namespace StateWithFlyweight
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
		public Icon(string type)
		{
			// load icon
		}
	}

	static class ButtonProvider
	{
		private static Dictionary<string, Button> _cache = new Dictionary<string, Button>();

		public static Button GetButton(string type, Func<Button> buttonFactory)
		{
			if (!_cache.ContainsKey(type))
			{
				_cache[type] = buttonFactory();
			}

			return _cache[type];
		}
        public static Button SettingsButtonFactory() => new SettingsButton();
    }


    abstract class Button
	{
		// intrinsic state
		public Icon Icon { get; set; }
		public abstract void Click();
	}

	class SettingsButton : Button
	{
		public SettingsButton()
		{
			Icon = new Icon("settings");
		}

		public override void Click()
		{
			// do something
		}
	}

	class DropdownButton : Button
	{
		Button _btn;
		public DropdownButton(Button btn, params string[] options)
		{
			_btn = btn;
		}

		public override void Click()
		{
			_btn.Click(); // do the original thing
						  // display options
		}
	}

	class SolutionWindow
	{
		Button settings = new DropdownButton(ButtonProvider.GetButton("settings", ButtonProvider.SettingsButtonFactory), "option1", "option2");
	}

	class TerminalWindow
	{
		Button settings = new DropdownButton(ButtonProvider.GetButton("settings", ButtonProvider.SettingsButtonFactory), "option2", "option3", "option4");
	}

	class TestRunnerWindow
	{
		Button settings = new DropdownButton(ButtonProvider.GetButton("settings", ButtonProvider.SettingsButtonFactory), "option1", "option2", "option4");
	}
}
