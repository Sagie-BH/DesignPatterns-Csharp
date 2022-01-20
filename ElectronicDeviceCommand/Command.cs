namespace ElectronicDeviceCommand
{
    // Each command you want to issue will implement
    // the Command interface

    public interface Command
    {
        public void execute();
        public void undo();

    }
}
