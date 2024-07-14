using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Core.Models.Movies
{
    public class NewMovieDropdownsViewModel
	{
		public IEnumerable<Actor> Actors { get; set; } = new List<Actor>();
		public IEnumerable<Producer> Producers { get; set; } = new List<Producer>();
		public IEnumerable<Cinema> Cinemas { get; set; } = new List<Cinema>();
	}
}
