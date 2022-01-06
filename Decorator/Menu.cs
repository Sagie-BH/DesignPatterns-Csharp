using System.Collections.Generic;

namespace Decorator
{
    public interface IMenu
    {
        IEnumerable<IMenuItem> Items { get; }
    }

    public class Menu : IMenu
        {
            public IEnumerable<IMenuItem> Items { get; }

            public Menu(IEnumerable<IMenuItem> menuItems)
            {
                Items = menuItems;
            }
        }
    
}
