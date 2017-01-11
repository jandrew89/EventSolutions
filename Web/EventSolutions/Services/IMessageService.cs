using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Services
{
    public interface IMessageService
    {
        System.Threading.Tasks.Task SendEmailAsync(string email, string subject, string message);
        System.Threading.Tasks.Task SendSmsAsync(string number, string message);
    }
}
