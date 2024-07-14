using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Actor;
using static SimpleETicketPlatform.Core.Models.Constants.MessageConstants;


namespace SimpleETicketPlatform.Core.Models.Actors
{
    public class ActorFormViewModel
	{
		public int Id { get; set; }

		[StringLength(FullNameMaxLength, MinimumLength =FullNameMinLength, ErrorMessage = LengthErrorMessage)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string FullName { get; set; } = string.Empty;

		[StringLength(BiographyMaxLength, MinimumLength =BiographyMinLength, ErrorMessage = LengthErrorMessage)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Biography { get; set; } = string.Empty;

		[StringLength(ProfilePictureURLMaxLength, MinimumLength =ProfilePictureURLMinLength, ErrorMessage = LengthErrorMessage)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string ProfilePictureURL { get; set; } = string.Empty;
	}
}
