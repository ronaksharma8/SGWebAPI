using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Core
{
    public class Exception5HK : SGException
    {
        public override string UserFriendlyMessage => base.UserFriendlyMessage;
        public Exception5HK()
        {
        }

        public Exception5HK(string userMessage)
            : base(userMessage)
        {
        }

    }
}
