using System;

namespace FlyingCarIS
{
    public class Class1
    {
    }
    public interface ICar
    {
        void Drive();
    }
    public interface IAirplane
    {
        void Fly();
    }
    public class Car : ICar
    {
        public void Drive()
        {
            //actions to drive a car
            Console.WriteLine("Driving a car");
        }
    }
    public class Airplane : IAirplane
    {
        public void Fly()
        {
            //actions to fly a plane
            Console.WriteLine("Flying a plane");
        }
    }
    //public class MultiFunctionalCar : ICar, IAirplane
    //{
    //    public void Drive()
    //    {
    //        //actions to start driving car
    //        Console.WriteLine("Drive a multifunctional car");
    //    }
    //    public void Fly()
    //    {
    //        //actions to start flying
    //        Console.WriteLine("Fly a multifunctional car");
    //    }
    //}
    public interface IMultiFunctionalVehicle : ICar, IAirplane
    {
    }
    public class MultiFunctionalCar : IMultiFunctionalVehicle
    {
        public void Drive()
        {
            //actions to start driving car
            Console.WriteLine("Drive a multifunctional car");
        }
        public void Fly()
        {
            //actions to start flying
            Console.WriteLine("Fly a multifunctional car");
        }
    }
    public class MultiFunctionalCarDecorator : IMultiFunctionalVehicle
    {
        private readonly ICar _car;
        private readonly IAirplane _airplane;
        public MultiFunctionalCarDecorator(ICar car, IAirplane airplane) 
        {
            _car = car;
            _airplane = airplane;
        }
        public void Drive()
        {
            _car.Drive();
        }
        public void Fly()
        {
            _airplane.Fly();
        }
    }
}
