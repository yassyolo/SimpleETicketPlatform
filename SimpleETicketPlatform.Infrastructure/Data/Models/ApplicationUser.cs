using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Application user entity")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("Application user full name")]
        public string FullName { get; set; } = string.Empty;
    }
}
