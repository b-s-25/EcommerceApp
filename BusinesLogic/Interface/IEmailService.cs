using DomainLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Interface
{
    public interface IEmailService
    {
        //Task SendTestEmail(UserEmail userEmail);
        Task SendEmailForForgotPassword(UserEmail userEmail);
    }
}
