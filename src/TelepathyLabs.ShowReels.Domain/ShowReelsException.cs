namespace TelepathyLabs.ShowReels.Domain
{
    public class ShowReelsException: Exception
    {
        public ShowReelsException()
        {
        }

        public ShowReelsException(string message)
            : base(message)
        {
        }

        public ShowReelsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

