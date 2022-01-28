using System;

namespace StateMachineCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
            state = (state, actiion) switch
            {

            }
        }
    }
}
