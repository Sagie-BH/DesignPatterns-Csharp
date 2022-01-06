using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SRP
{
    public class PersonService
    {
        public void EmployeeRegistration(Person person)
        {
            StaticData.People.Add(person);

            StaticData.People.ForEach(p =>
            {
                EmailService.SendEmail(p.FirstName + " " + p.LastName, p.Email, "Testing",
                     "Congratulation ! Your have successfully sent an email.");
            });
        }
    }
}
