using System;

namespace SimpleExmpleMediator
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class WithOutMediator
    {
        public class LogicA
        {
            LogicB b;
            public void Do() { b.Do(); }
        }
        public class LogicB
        {
            public void Do() { }
        }
    }
    public class WithMediator
    {
        public class LogicA
        {
            Mediator m;
            public void Do() { m.DoLogic("b"); }
        }

        public class Mediator
        {
            public void DoLogic(string logic)
            {
                if (logic == "b") { new LogicB().Do(); }
            }
        }
        public class LogicB
        {
            public void Do() { }
        }
    }
}
