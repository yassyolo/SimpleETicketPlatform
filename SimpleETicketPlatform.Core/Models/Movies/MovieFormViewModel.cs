using System.ComponentModel.DataAnnotations;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.Movie;
using static SimpleETicketPlatform.Core.Models.Constants.MessageConstants;

namespace SimpleETicketPlatform.Core.Models.Movies
{
    public class MovieFormViewModel
	{
		public int Id { get; set; }

		[MaxLength(NameMaxLength)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[MaxLength(DescriptionMaxLength)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Description { get; set; } = string.Empty;

		[Range(typeof(decimal), PriceMinValue, PriceMaxValue, ConvertValueInInvariantCulture = false)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public decimal Price { get; set; }

		[MaxLength(PhotoURLMaxLength)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string PhotoURL { get; set; } = string.Empty;

		[DataType(DataType.Date)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public DateTime StartDate { get; set; }

		[DataType(DataType.Date)]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public DateTime EndDate { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int MovieCategoryId { get; set; } 

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int CinemaId { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int ProducerId { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public IEnumerable<int> ActorIds = new List<int>();
	}
}
