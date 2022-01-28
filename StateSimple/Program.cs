using System;

namespace StateSimple
{
    /*
     This is a class that holds a concrete state object that provides the behavior according to its current state. 
     This is used by the clients.
     */
    public class Context
    {
        private IState state;

        public Context(IState newstate)
        {
            state = newstate;
        }

        public void Request()
        {
            state.Handle(this);
        }

        public IState State
        {
            get { return state; }
            set { state = value; }
        }
    }

    // This is an interface that is used by the Context object to access the changeable functionality.
    public interface IState
    {
        void Handle(Context context);
    }

    /*
     These are classes that implement State interface and provide the real functionality that will be used by the Context object.
     Each concrete state class provides behavior that is applicable to a single state of the Context object.
     */
    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Handle called from ConcreteStateA");
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Handle called from ConcreteStateB");
            context.State = new ConcreteStateA();
        }
    }

}
