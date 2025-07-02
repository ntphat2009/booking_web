using BookingSystem.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Common.Service.Interfaces
{
    public interface IEmailSenderService
    {
        bool SendEmail(Messages message);
    }
}
