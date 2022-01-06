using System;

namespace FactoryP
{
    class Program
    {
        static void Main(string[] args)
        {
            new NavigationBar();
            new DropdownMenu();
        }
    }
    public class NavigationBar
    {
        public NavigationBar() => ButtonFactory.CreateButton();
    }

    public class DropdownMenu
    {
        public DropdownMenu() => ButtonFactory.CreateButton();
    }

    public class ButtonFactory
    {
        public static Button CreateButton()
        {
            return new Button { Type = "Red Button" };
        }
    }

    public class Button
    {
        public string Type { get; set; }
    }

}
