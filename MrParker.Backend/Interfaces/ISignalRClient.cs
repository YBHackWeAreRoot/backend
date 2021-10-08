using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.Interfaces
{
    public interface ISignalRClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
