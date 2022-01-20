namespace ElectronicDeviceCommand
{
    public class TurnTVVolumeDown : Command
    {
        IElectronicDevice _device;
        public TurnTVVolumeDown(IElectronicDevice device)
        {
            _device = device;
        }
        public void execute()
        {
            _device.volumenDown();
        }

        public void undo()
        {
            _device.volumeUp();
        }
    }
    public class TurnTVVolumeUp : Command
    {
        IElectronicDevice _device;
        public TurnTVVolumeUp(IElectronicDevice device)
        {
            _device = device;
        }
        public void execute()
        {
            _device.volumeUp();
        }

        public void undo()
        {
            _device.volumenDown();
        }
    }
}
