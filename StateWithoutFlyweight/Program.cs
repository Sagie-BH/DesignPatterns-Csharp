using System;
using System.Collections.Generic;

namespace StateWithoutFlyweight
{
    class Program
    {
        static void Main(string[] args)
        {
			var btn = ButtonProvider.GetButton<string[]>("settings", ButtonProvider.SettingsButtonFactory);


			btn.Click(new[] { "option1", "option2", "option3", "option4" });
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

		public static Button<T> GetButton<T>(string type, Func<Button<T>> buttonFactory)
		{
			if (!_cache.ContainsKey(type))
			{
				_cache[type] = buttonFactory();
			}

			return (Button<T>)_cache[type];
		}
		public static SettingsButton SettingsButtonFactory() => new SettingsButton();

	}


	abstract class Button
	{
		// intrinsic state
		public Icon Icon { get; set; }
	}

	abstract class Button<T> : Button
	{
		public abstract void Click(T config);
	}

	class SettingsButton : Button<string[]>
	{
		public SettingsButton()
		{
			Icon = new Icon("settings");
		}

		public override void Click(string[] config)
		{
			// display options
		}
	}
}
