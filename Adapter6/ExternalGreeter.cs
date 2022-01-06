namespace Adapter6
{
    public class ExternalGreeter
    {
        public string GreetByName(string name)
        {
            return $"Adaptee says: hi {name}!";
        }
    }

    public interface IGreeter
    {
        string Greeting();
    }

    public class ExternalGreeterAdapter : IGreeter
    {
        private readonly ExternalGreeter _adaptee;

        public ExternalGreeterAdapter(ExternalGreeter adaptee)
        {
            _adaptee = adaptee ?? throw new ArgumentNullException(nameof(adaptee));
        }

        public string Greeting()
        {
            return _adaptee.GreetByName("System");
        }
    }
}
