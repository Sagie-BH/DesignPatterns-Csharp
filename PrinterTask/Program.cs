using System;

namespace PrinterTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public interface IPrinterTasks
    {
        void Print(string PrintContent);
        void Scan(string ScanContent);
        void Fax(string FaxContent);
        void PrintDuplex(string PrintDuplexContent);
    }
    class HpLaserJetPrinter : IPrinterTasks
    {
        public void Fax(string FaxContent)
        {
            Console.WriteLine("Done Faxing Content" + FaxContent);
        }

        public void Print(string PrintContent)
        {
            Console.WriteLine("Done Printing:" + PrintContent);
        }

        public void PrintDuplex(string PrintDuplexContent)
        {
            Console.WriteLine("Done Printing Duplex:" + PrintDuplexContent);
        }

        public void Scan(string ScanContent)
        {
            Console.WriteLine("Done Scaning:" + ScanContent);
        }
    }


    class LiquidInkPrinter : IPrinterTasks
    {
        public void Fax(string FaxContent)
        {
            Console.WriteLine("Done Faxing Content" + FaxContent);
        }

        public void Print(string PrintContent)
        {
            Console.WriteLine("Done Printing:" + PrintContent);
        }

        public void PrintDuplex(string PrintDuplexContent)
        {
            throw new NotImplementedException();
        }

        public void Scan(string ScanContent)
        {
            throw new NotImplementedException();
        }
    }
}
