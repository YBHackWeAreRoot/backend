using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.Bookings
{
    public enum BookingStatus
    {
        Reserved = 0,
        CheckedIn = 1,
        CheckedOut = 2,
        Canceled = 3,
        CanceledBySystem = 4
    }
}
