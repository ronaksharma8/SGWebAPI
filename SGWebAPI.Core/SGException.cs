namespace SGWebAPI.Core
{
    public class SGException : ApplicationException
    {
        public virtual string UserFriendlyMessage { get; }

        public SGException()
        {
        }

        public SGException(string userMessage)
            : base(userMessage)
        {
            UserFriendlyMessage = userMessage;
        }
    }
}