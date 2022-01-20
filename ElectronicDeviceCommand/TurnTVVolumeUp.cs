namespace ElectronicDeviceCommand
{
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
