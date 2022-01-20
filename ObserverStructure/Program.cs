using System;
using System.Collections.Generic;

namespace ObserverStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Observer pattern
            ConcreteSubject s = new ConcreteSubject();
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));
            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Subject' abstract class
    /// knows its observers. Any number of Observer objects may observe a subject
    /// provides an interface for attaching and detaching Observer objects.
    /// </summary>
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }
    /// <summary>
    /// The 'ConcreteSubject' class
    /// stores state of interest to ConcreteObserver
    /// sends a notification to its observers when its state changes
     /// </summary>
    public class ConcreteSubject : Subject
    {
        private string subjectState;
        // Gets or sets subject state
        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }
    /// <summary>
    /// The 'Observer' abstract class
    /// defines an updating interface for objects that should be notified of changes in a subject.
    /// </summary>
    public abstract class Observer
    {
        public abstract void Update();
    }
    /// <summary>
    /// The 'ConcreteObserver' class
    /// maintains a reference to a ConcreteSubject object
    /// stores state that should stay consistent with the subject's
    /// implements the Observer updating interface to keep its state consistent with the subject's
    /// </summary>
    public class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;
        private ConcreteSubject subject;
        // Constructor
        public ConcreteObserver(
            ConcreteSubject subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }
        public override void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
                name, observerState);
        }
        // Gets or sets subject
        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}
