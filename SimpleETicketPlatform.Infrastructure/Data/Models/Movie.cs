using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Movie;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Movie entity")]
    public class Movie
    {
        [Key]
        [Comment("Movie identifier")]
        public int Id { get; set; }

        [Comment("Movie name")]
        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Comment("Movie description")]
        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Comment("Movie price")]
        [Range(typeof(decimal), PriceMinValue,PriceMaxValue, ConvertValueInInvariantCulture = false)]
        [Required]
        public decimal Price { get; set; }

        [Comment("Movie photo URL")]
        [MaxLength(PhotoURLMaxLength)]
        [Required]
        public string PhotoURL { get; set; } = string.Empty;

        [Comment("Movie start date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [Comment("Movie end date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        [Comment("Movie category")]
        [Required]
        public MovieCategory MovieCategory { get; set; }

        [Comment("Movie actors")]
        public IEnumerable<MovieActor> MovieActors = new List<MovieActor>();

        [Comment("Movie cinema identifier")]
        public int CinemaId { get; set; }

        [ForeignKey(nameof(CinemaId))]
        [Comment("Cinema")]
        public Cinema Cinema { get; set; } = null!;

        [Comment("Movie producer identifier")]
        public int ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        [Comment("Producer")]
        public Producer Producer { get; set; } = null!;
    }
}
