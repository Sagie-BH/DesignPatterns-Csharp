using System;

namespace Pub_Sub.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var pub = new Publisher();
            var sub = new Subscriber();
            sub.Subscribe(pub);
            pub.DoSomething();
        }
    }

    public class SomeEventArgs : EventArgs
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public SomeEventArgs(string description, DateTime date)
        {
            Description = description;
            Date = date;
        }
    }

    public class Publisher
    {
        // Add the public eventhandler
        public event EventHandler<SomeEventArgs> OnSomeEvent;
        public void DoSomething()
        {
            // Do something here
            //RunSomeCode();
            // Send a notification that an event has occurred
            if (OnSomeEvent != null)
            {
                // OnTransactionProcessed(this, new SomeEventArgs("something happened", DateTime.Now);
            }
        }
    }
    public class Subscriber
    {
        private void RespondToEvent(object sender, SomeEventArgs e)
        {
            //DoStuff(e.Description, e.Date);
        }
        public void Subscribe(Publisher publisher)
        {
            publisher.OnSomeEvent += RespondToEvent;
        }
    }
}
