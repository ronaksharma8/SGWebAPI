using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Core
{
    public class Exception11HK : SGException
    {
        public override string UserFriendlyMessage => base.UserFriendlyMessage;
        public Exception11HK()
        {
        }

        public Exception11HK(string userMessage)
            : base(userMessage)
        {
        }
    }
}
