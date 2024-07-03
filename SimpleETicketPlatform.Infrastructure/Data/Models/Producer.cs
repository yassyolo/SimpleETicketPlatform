using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Producer;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Producer entity")]
    public class Producer
    {
        [Key]
        [Comment("Producer identifier")]
        public int Id { get; set; }

        [Comment("Producer full name")]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = string.Empty;

        [Comment("Producer biography")]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; } = string.Empty;

        [Comment("Producer profile picture URL")]
        [MaxLength(ProfilePictureURLMaxLength)]
        public string ProfilePictureURL { get; set; } = string.Empty;

        [Comment("Producer movies")]
        public IEnumerable<Movie> Movies = new List<Movie>();
    }
}
