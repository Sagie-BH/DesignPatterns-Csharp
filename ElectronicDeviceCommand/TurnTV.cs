namespace ElectronicDeviceCommand
{
    public class TurnTVOff : Command
    {
        IElectronicDevice _device;
        public TurnTVOff(IElectronicDevice device)
        {
            _device = device;
        }
        public void execute()
        {
            _device.off();
        }

        public void undo()
        {
            _device.on();
        }
    }
    public class MicroOff : Command
    {
        IElectronicDevice _device;
        public MicroOff(IElectronicDevice device)
        {
            _device = device;
        }
        public void execute()
        {
            _device.off();
        }

        public void undo()
        {
            _device.on();
        }
    }

    public class TurnTVOn : Command
    {
        IElectronicDevice _device;
        public TurnTVOn(IElectronicDevice device)
        {
            _device = device;
        }
        public void execute()
        {
            _device.on();
        }

        public void undo()
        {
            _device.off();
        }
    }
}
