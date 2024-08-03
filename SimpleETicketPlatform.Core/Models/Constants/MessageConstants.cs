namespace SimpleETicketPlatform.Core.Models.Constants
{
    public static class MessageConstants
	{
		public const string LengthErrorMessage = "The field {0} must be between {2} and {1} characters long.";
		public const string RequiredErrorMessage = "The field {0} is required.";
        public const string EmailErrorMessage = "Email address is not valid.";
        public const string PasswordMatchErrorMessage = "Passwords do not match.";
    }
}
