using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Cinema;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Cinema entity")]
    public class Cinema
    {
        [Key]
        [Comment("Cinema identifier")]
        public int Id { get; set; }

        [Comment("Cinema name")]
        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Comment("Cinema logo")]
        [MaxLength(LogoMaxLength)]
        [Required]
        public string Logo { get; set; } = string.Empty;

        [Comment("Cinema description")]
        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Comment("Movies in the cinema")]

        public IEnumerable<Movie> Movies = new List<Movie>();
    }
}
