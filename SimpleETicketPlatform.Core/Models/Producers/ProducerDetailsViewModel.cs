using SimpleETicketPlatform.Core.Models.Movies;

namespace SimpleETicketPlatform.Core.Models.Producers
{
    public class ProducerDetailsViewModel
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Biography { get; set; } = string.Empty;
		public string ProfilePictureURL { get; set; } = string.Empty;

		public IEnumerable<MovieIndexViewModel> Movies = new List<MovieIndexViewModel>();
	}
}
