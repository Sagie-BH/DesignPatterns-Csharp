using System;

namespace CarStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            Console.WriteLine($"Car State: {car.CurrentState}");

            car.TakeAction(Car.Action.Start);
            Console.WriteLine($"Car State: {car.CurrentState}");

            car.TakeAction(Car.Action.Accelerate);
            Console.WriteLine($"Car State: {car.CurrentState}");

            car.TakeAction(Car.Action.Stop);
            Console.WriteLine($"Car State: {car.CurrentState}");
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
