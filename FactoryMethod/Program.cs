using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
			new NavigationBar();
			new DropdownMenu();
			new AndroidNavigationBar();
			new AndroidDropdownMenu();
		}
    }
	public abstract class Element
	{
		protected abstract Button CreateButton();

		public Element() => CreateButton();
	}

	public class NavigationBar : Element
	{
		protected override Button CreateButton()
		{
			return new Button { Type = "Default Button" };
		}
	}

	public class DropdownMenu : Element
	{
		protected override Button CreateButton()
		{
			return new Button { Type = "Default Button" };
		}
	}

	public class AndroidNavigationBar : Element
	{
		protected override Button CreateButton()
		{
			return new Button { Type = "Android Button" };
		}
	}

	public class AndroidDropdownMenu : Element
	{
		protected override Button CreateButton()
		{
			return new Button { Type = "Android Button" };
		}
	}

	public class Button
	{
		public string Type { get; set; }
	}
}
