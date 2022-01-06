using System;
using System.Collections.Generic;
using OPC;

/*
הרעיון המרכזי של עיקרון זה הוא לשמור על קוד קיים מלהישבר כאשר אתה מיישם תכונות חדשות.
במקום לשנות את הקוד של המחלקה ישירות, אתה יכול ליצור תת מחלקה ולעקוף חלקים ממנה ולשנות מקרים
בהם אתה רוצה התנהגות אחרת וככה לא לשבור אף קוד קיים של המחלקה המקורית
כמובן שבמקרה שיש באג במחלקה המקורית עלינו לתקן אותו ולא לעוף עם תת מחלקה.

 */
namespace OPC
{
    class Program
    {
        static void Main(string[] args)
        {
            var devReports = new List<DeveloperReport>
            {
                new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 160 },
                new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate  = 20, WorkingHours = 150 },
                new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 180 }
            };
            var calculator = new SalaryCalculator(devReports);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");

            Console.WriteLine("\nAfter modification\n");

            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalariesModified()} dollars");
            



            //Invoice
            Invoice FInvoice = new FinalInvoice();
            Invoice PInvoice = new ProposedInvoice();
            Invoice RInvoice = new RecurringInvoice();
            double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
            double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
            double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);
            Console.ReadKey();
        }
    }

    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
    }

    public class SalaryCalculator
    {
        private readonly IEnumerable<DeveloperReport> _developerReports;
        public SalaryCalculator(List<DeveloperReport> developerReports)
        {
            _developerReports = developerReports;
        }
        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0D;
            foreach (var devReport in _developerReports)
            {
                totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
            }
            return totalSalaries;
        }

        public double CalculateTotalSalariesModified()
        {
            double totalSalaries = 0D;
            foreach (var devReport in _developerReports)
            {
                if (devReport.Level == "Senior developer")
                {
                    totalSalaries += devReport.HourlyRate * devReport.WorkingHours * 1.2;
                }
                else
                {
                    totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
                }
            }
            return totalSalaries;
        }
    }
}
