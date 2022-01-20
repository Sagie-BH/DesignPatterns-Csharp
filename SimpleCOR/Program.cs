using System;

namespace SimpleCOR
{
    class Program
    {
        static void Main(string[] args)
        {
			// select code in editor tab
			var ide = new IDE(null);
			var editor = new CodeEditor(ide);
			var codeSelection = new CodeSelection(editor);

			codeSelection.HandleKey("Ctrl+F");
			codeSelection.HandleKey("Alt+F4");
		}
    }
	interface IKeyHandler
	{
		void HandleKey(string key);
	}

	class IDE : IKeyHandler
	{
		IKeyHandler _handler;

		public IDE(IKeyHandler handler) => _handler = handler;

		public void HandleKey(string key)
		{
			if (key == "Ctrl+F")
			{
                Console.WriteLine("Full Search");
			}
			else if (key == "Alt+F4")
			{
                Console.WriteLine("Close Application?");
			}
			else
			{
				_handler?.HandleKey(key);
			}
		}
	}

	class CodeEditor : IKeyHandler
	{
		IKeyHandler _handler;

		public CodeEditor(IKeyHandler handler) => _handler = handler;

		public void HandleKey(string key)
		{
			if (key == "Ctrl+F")
			{
                Console.WriteLine("Local Search");
			}
			else
			{
				_handler?.HandleKey(key);
			}
		}
	}

	class CodeSelection : IKeyHandler
	{
		IKeyHandler _handler;

		public CodeSelection(IKeyHandler handler) => _handler = handler;

		public void HandleKey(string key)
		{
			if (key == "Ctrl+F")
			{
                Console.WriteLine("Selection Search");
			}
			else
			{
				_handler?.HandleKey(key);
			}
		}
	}
}
