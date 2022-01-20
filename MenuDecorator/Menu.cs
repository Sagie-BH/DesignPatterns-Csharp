using System.Collections.Generic;
using System.Linq;

namespace MenuDecorator
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




    public class DiscountMenu : IMenu
    {
        private readonly IMenu _menu;
        private readonly double _discountPercentage;

        public IEnumerable<IMenuItem> Items => _menu.Items.Select(ToDiscountMenuItems);

        public DiscountMenu(IMenu menu, double discountPercentage)
        {
            _menu = menu;
            _discountPercentage = discountPercentage;
        }

        private IMenuItem ToDiscountMenuItems(IMenuItem menuItem)
        {
            return new DiscountMenuItem(menuItem, _discountPercentage);
        }
    }
    public class DailySpecialMenu : IMenu
    {
        private readonly IMenu _menu;
        private readonly IMenuItem _dailySpecialMenuItem;

        public IEnumerable<IMenuItem> Items => _menu.Items.Append(_dailySpecialMenuItem);

        public DailySpecialMenu(IMenu menu, IMenuItem dailySpecialMenuItem)
        {
            _menu = menu;
            _dailySpecialMenuItem = dailySpecialMenuItem;
        }
    }
}
