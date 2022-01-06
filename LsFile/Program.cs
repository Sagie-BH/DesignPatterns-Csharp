using System;

namespace LsFile
{
    class Program
    {
        // Classes would implement only the interfaces needed and then the interfaces would be replaceable without any issues
        static void Main(string[] args)
        {
            IFileReader fileReader = new AdminDataFileUserFixed();
            fileReader.ReadFile(@"c:\temp\a.txt");

            IFileWriter fileWriter = new AdminDataFileUserFixed();
            fileWriter.WriteFile(@"c:\temp\a.txt");

            IFileReader fileReaderR = new RegularDataFileUserFixed();
            fileReaderR.ReadFile(@"c:\temp\a.txt");
        }
    }
    // Following the Liskov Substitution Principle    
    public interface IFileReader
    {
        void ReadFile(string filePath);
    }
    public interface IFileWriter
    {
        void WriteFile(string filePath);
    }
    public class AdminDataFileUserFixed : IFileReader, IFileWriter
    {
        public void ReadFile(string filePath)
        {
            // Read File logic    
            Console.WriteLine($"File {filePath} has been read");
        }
        public void WriteFile(string filePath)
        {
            //Write File Logic    
            Console.WriteLine($"File {filePath} has been written");
        }
    }
    public class RegularDataFileUserFixed : IFileReader
    {
        public void ReadFile(string filePath)
        {
            // Read File logic    
            Console.WriteLine($"File {filePath} has been read");
        }
    }
}
