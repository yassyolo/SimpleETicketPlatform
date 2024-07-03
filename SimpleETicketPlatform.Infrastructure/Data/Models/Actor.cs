using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Actor;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Actor entity")]
    public class Actor
    {
        [Key]
        [Comment("Actor identifier")]
        public int Id { get; set; }

        [Comment("Actor full name")]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = string.Empty;

        [Comment("Actor biography")]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; } = string.Empty;

        [Comment("Actor profile picture URL")]
        [MaxLength(ProfilePictureURLMaxLength)]
        public string ProfilePictureURL { get; set; } = string.Empty;

        [Comment("Movies of the actor")]

        public IEnumerable<MovieActor> MovieActors = new List<MovieActor>();
    }
}
