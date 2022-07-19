using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Core
{
    public class Exception388HK : SGException
    {
        public override string UserFriendlyMessage => base.UserFriendlyMessage;
        public Exception388HK()
        {
        }

        public Exception388HK(string userMessage)
            : base(userMessage)
        {
        }
    }
}
