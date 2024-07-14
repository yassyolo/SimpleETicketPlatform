namespace SimpleETicketPlatform.Core.CustomExceptions
{
    public class MovieDoesNotExistException : Exception
	{
        public MovieDoesNotExistException(string message) : base(message)
        {
            
        }
    }
}
