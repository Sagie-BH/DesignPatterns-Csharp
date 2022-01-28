using System;

namespace StateMachineStateless
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var car = new Stateless.StateMachine<Car.State, Car.Action>(Car.State.Stopped); // initial state

            car.Configure(Car.State.Stopped)
                .Permit(Car.Action.Start, Car.State.Stopped);

            car.Configure(Car.State.Started)
                .Permit(Car.Action.Accelerate, Car.State.Running)
                .Permit(Car.Action.Stop, Car.State.Stopped);
                //.OnEntry(s => Console.WriteLine("Enter " + s.Source + "\t" + s.Destination))
                //.OnExit(s => Console.WriteLine("Exit " + s.Source + "\t" + s.Destination))
                //.Ignore(Car.Action.Start);

            car.Configure(Car.State.Running)
                .Permit(Car.Action.Stop, Car.State.Stopped);

            Console.WriteLine($"Car State: {car.State}");

            car.Fire(Car.Action.Start);
            Console.WriteLine($"Car State:  {car.State}");

            //car.Fire(Car.Action.Start);
            //Console.WriteLine($"Car State:  {car.State}");

            car.Fire(Car.Action.Accelerate);
            Console.WriteLine($"Car State:  {car.State}");

            car.Fire(Car.Action.Stop);
            Console.WriteLine($"Car State:  {car.State}");
        }
    }
    public class Car
    {
        public enum State
        {
            Stopped, Started, Running
        }
        public enum Action
        {
            Stop, Start, Accelerate
        }

        private State state = State.Stopped;
        public State CurrentState { get => state; }

        // Can also use Observer to notify

        public void TakeAction(Action action)
        {

            state = (state, action) switch
            {
                (State.Stopped, Action.Start) => State.Started,
                (State.Started, Action.Accelerate) => State.Running,
                (State.Started, Action.Stop) => State.Stopped,
                (State.Running, Action.Stop) => State.Stopped,
                _ => state
            };
        }
    }
}
