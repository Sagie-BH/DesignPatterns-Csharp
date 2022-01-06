using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
			new NavigationBar(new Android());
			new DropdownMenu(new Android());
		}
    }
	public class NavigationBar
	{
		public NavigationBar(IUIFactory factory) => factory.CreateButton();
	}

	public class DropdownMenu
	{
		public DropdownMenu(IUIFactory factory) => factory.CreateButton();
	}

	public interface IUIFactory
	{
		public Button CreateButton();

	}

	public class Apple : IUIFactory
	{
		public Button CreateButton()
		{
			return new Button { Type = "iOS Button" };
		}
	}

	public class Android : IUIFactory
	{
		public Button CreateButton()
		{
			return new Button { Type = "Android Button" };
		}
	}

	public class Button
	{
		public string Type { get; set; }
	}
}
