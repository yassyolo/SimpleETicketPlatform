using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Core.Models.Constants.MessageConstants;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Account;

namespace SimpleETicketPlatform.Core.Models.Account
{
    public class RegisterViewModel 
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = EmailErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = LengthErrorMessage)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = PasswordMatchErrorMessage )]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
