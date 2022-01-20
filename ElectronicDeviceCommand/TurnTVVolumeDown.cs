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
}
