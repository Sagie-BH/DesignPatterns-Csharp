using System;

namespace NullDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (objectVariable == null)  
            //  return;
            // do some work();

            var mobileRepository = new MobileFactory();
            IMobile mobile = mobileRepository.GetMobileByName("sony");
            mobile.TurnOn();
            mobile.TurnOff();
        }
    }
    public interface IMobile
    {
        void TurnOn();
        void TurnOff();
    }

    //mobile type implementing IMobile interface  
    public class SamsungGalaxy : IMobile
    {
        public void TurnOff()
        {
            Console.WriteLine("\nSamsung Galaxy Turned OFF!");
        }

        public void TurnOn()
        {
            Console.WriteLine("\nSamsung Galaxy Turned ON!");
        }
    }

    //our null object class implementing IMobile interface as a singleton  
    public class NullMobile : IMobile
    {
        private static NullMobile _instance;
        private NullMobile()
        { }

        public static NullMobile Instance
        {
            get
            {
                if (_instance == null)
                    return new NullMobile();
                return _instance;
            }
        }

        //do nothing methods  
        public void TurnOff()
        { }

        public void TurnOn()
        { }
    }
    public class MobileFactory
    {
        public IMobile GetMobileByName(string mobileName)
        {
            IMobile mobile = NullMobile.Instance;
            switch (mobileName)
            {
                case "sony":
                    mobile = new SonyXperia();
                    break;

                case "apple":
                    mobile = new AppleIPhone();
                    break;

                case "samsung":
                    mobile = new SamsungGalaxy();
                    break;
            }
            return mobile;
        }
    }
    internal class AppleIPhone : IMobile 
    {
        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public void TurnOn()
        {
            throw new NotImplementedException();
        }
    }
    internal class SonyXperia : IMobile
    {
        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public void TurnOn()
        {
            throw new NotImplementedException();
        }
    }
}
