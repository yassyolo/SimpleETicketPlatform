using SimpleETicketPlatform.Core.Models.Actors;
using SimpleETicketPlatform.Core.Models.Producers;

namespace SimpleETicketPlatform.Core.Models.Movies
{
    public class MovieDetailsViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string PhotoURL { get; set; } = string.Empty;
		public string StartDate { get; set; } = string.Empty;
		public string EndDate { get; set; } = string.Empty;
		public string MovieCategory { get; set; } = string.Empty;
		public string CinemaName { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
		public ProducerIndexViewModel Producer { get; set; } = null!;

        public IEnumerable<ActorIndexViewModel> Actors = new List<ActorIndexViewModel>();
 	}
}
