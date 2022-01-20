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
}
