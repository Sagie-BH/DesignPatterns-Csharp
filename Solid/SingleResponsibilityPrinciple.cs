using System;
using System.Collections.Generic;
using System.Text;

namespace SRP
{
    // A class should have just one reason to change.
    public class SingleResponsibilityPrinciple
    {
        public class TooManyResponsibilitiesEmployee
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void getTimeSheetReport()
            {
                //...Do Somthing 
            }
        }


        public class SingleResponsibilitEmployee
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class TimeSheetProvider
        {
            public void printEmployeeTimeSheet() { }
        }
    }
}
