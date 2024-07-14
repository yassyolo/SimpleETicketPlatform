using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Cinema;
using static SimpleETicketPlatform.Core.Models.Constants.MessageConstants;

namespace SimpleETicketPlatform.Core.Models.Cinemas
{
    public class CinemaFormViewModel
	{
		public int Id { get; set; }

		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Description { get; set; } = string.Empty;

		[StringLength(LogoMaxLength, MinimumLength = LogoMinLength, ErrorMessage = LengthErrorMessage)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Logo { get; set; } = string.Empty;
	}
}
