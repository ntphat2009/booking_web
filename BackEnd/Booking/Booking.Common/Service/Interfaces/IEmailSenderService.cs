using Booking.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Common.Service.Interfaces
{
    public interface IEmailSenderService
    {
        bool SendEmail(Messages message);
    }
}
