namespace SimpleETicketPlatform.Core.CustomExceptions
{
    public class ActorDoesNotExistException : Exception
	{
        public ActorDoesNotExistException(string message)
            :base(message)
        {
                
        }
    }
}
