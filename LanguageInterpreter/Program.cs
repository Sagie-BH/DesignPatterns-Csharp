using System;
using System.Text.RegularExpressions;
using System.Web;

namespace LanguageInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
			// Language
			var domainLanguage = "order x10 '2L water bottles' from Tesco";
            Console.WriteLine(Order.Parse(domainLanguage));

			var a = "&amp; bla bla bla bla &qut;";
			var c = a.Replace("&amp;", "&");
			var b = HttpUtility.UrlDecode(a);
			while  (b != a)
            {
				a = b;
				b = HttpUtility.UrlDecode(a);
            }
		}
    }


    // Grammar Representation
    public class Order
	{
        static string optionalSpace = " ?";
        static string qty = "x(?<qty>\\d+)" + optionalSpace;
        static string product = "'(?<product>[\\w ]+)'" + optionalSpace;
        static string source = "from (?<source>\\w+)";
        static string orderCommand = "order" + optionalSpace + qty + product + source;

        static Regex _regex = new Regex(orderCommand);
		
		Order(int qty, string product, string source)
		{
			Qty = qty;
			Product = product;
			Source = source;
		}

		public int Qty { get; }
		public string Product { get; }
		public string Source { get; }

		// Interpreter
		public static Order Parse(string command)
		{
			var match = _regex.Match(command);
			if (!match.Success)
			{
				return null;
			}

			var qty = int.Parse(match.Groups["qty"].Value);
			var product = match.Groups["product"].Value;
			var source = match.Groups["source"].Value;

			return new Order(qty, product, source);
		}
	}
}
