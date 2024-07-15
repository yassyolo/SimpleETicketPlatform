using SimpleETicketPlatform.Core.Models.Movies;

namespace SimpleETicketPlatform.Core.Models.Cinemas
{
    public class CinemaDetailsViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Logo { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int MoviesCount { get; set; }
		public IEnumerable<MovieIndexViewModel> Movies { get; set; } = new List<MovieIndexViewModel>();
	}
}
