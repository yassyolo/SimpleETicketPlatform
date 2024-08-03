using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Account;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Application user entity")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("Application user full name")]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = string.Empty;
    }
}
