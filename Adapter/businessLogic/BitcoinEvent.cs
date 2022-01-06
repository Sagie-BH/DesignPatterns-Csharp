using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.businessLogic
{
    public class BitcoinEvent
    {
        private readonly IUserNotificationService userNF;

        public BitcoinEvent(IUserNotificationService userNF)
        {
            this.userNF = userNF;
        }

        public Task Execute()
        {
            // other work here
            return userNF.NotifyUser("", "");
        }
    }
}
