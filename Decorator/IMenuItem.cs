namespace Decorator
{
    public interface IMenuItem
    {
        string Name { get; }
        double Price { get; }
        bool IsSpecial { get; }
    }
    public class MenuItem : IMenuItem
    {
        public string Name { get; }
        public double Price { get; }
        public bool IsSpecial { get; }

        public MenuItem(string name, double price, bool isSpecial = false)
        {
            Name = name;
            Price = price;
            IsSpecial = isSpecial;
        }

        public override string ToString()
        {
            string specialDisplay = IsSpecial ? "-=- SPECIAL -=- " : string.Empty;
            return $"{specialDisplay}{Name}: {Price:C}";
        }
    }
    public class DiscountMenuItem : IMenuItem
    {
        private readonly IMenuItem _menuItem;
        private readonly double _discountPercentage;

        public double Price => _menuItem.Price * (_discountPercentage / 100);

        public string Name => _menuItem.Name;
        public bool IsSpecial => _menuItem.IsSpecial;

        public DiscountMenuItem(IMenuItem menuItem, double discountPercentage)
        {
            _menuItem = menuItem;
            _discountPercentage = discountPercentage;
        }

        public override string ToString()
        {
            // Lazily copy/pasted from MenuItem.cs
            string specialDisplay = IsSpecial ? "-=- SPECIAL -=- " : string.Empty;
            return $"{specialDisplay}{Name}: {Price:C}";
        }
    }
}
