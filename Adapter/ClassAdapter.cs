using Adapter.businessLogic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class ClassAdapter : SendGridClient, IUserNotificationService
    {
        public ClassAdapter(SendGridClientOptions options) : base(options)
        {

        }

        public Task NotifyUser(string userId, string message)
        {
            return SendEmailAsync(new SendGridMessage());
        }
    }
}
