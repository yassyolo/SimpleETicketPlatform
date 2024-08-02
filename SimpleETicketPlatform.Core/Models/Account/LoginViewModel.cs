using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Core.Models.Constants.MessageConstants;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Account;

namespace SimpleETicketPlatform.Core.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = EmailErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,ErrorMessage =LengthErrorMessage)]
        public string Password { get; set; } = string.Empty;
    }
}
