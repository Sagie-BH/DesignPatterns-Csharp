using System;

namespace ElectronicDeviceCommand
{
    public class Television : IElectronicDevice
    {
        private int volume = 0;
        public void off()
        {
            Console.WriteLine("Tv is off");
        }

        public void on()
        {
            Console.WriteLine("Tv is on");
        }

        public void volumenDown()
        {
            Console.WriteLine("Tv Volume is at " + --volume);
        }

        public void volumeUp()
        {
            Console.WriteLine("Tv Volume is at " + ++volume);
        }
    }
}
