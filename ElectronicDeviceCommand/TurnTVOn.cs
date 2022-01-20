namespace ElectronicDeviceCommand
{
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
