using System;

namespace ElectronicDeviceCommand
{
    class Program
    {
        static void Main(string[] args)
        {

            IElectronicDevice newDevice = TVRemote.getDevice();
            TurnTVOn onCommand = new TurnTVOn(newDevice);
            DeviceButton onPressed = new DeviceButton(onCommand);
            onPressed.press();

        }
    }
    public class DeviceButton
    {
        Command theCommand;
        public DeviceButton(Command newCommand)
        {
            theCommand = newCommand;
        }
        public void press()
        {
            theCommand.execute();
        }
        // Now the remote can undo past commands
        public void pressUndo()
        {
            theCommand.undo();
        }
    }
    public class TVRemote
    {
        public static IElectronicDevice getDevice()
        {
            return new Television();
        }
    }

}
