using SimpleETicketPlatform.Core.Models.Actors;
using SimpleETicketPlatform.Core.Models.Cinemas;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Core.Models.Producers;

namespace SimpleETicketPlatform.Core.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<AllMoviesViewModel> Movies = new List<AllMoviesViewModel>();

        public IEnumerable<ProducersNameViewModel> Producers = new List<ProducersNameViewModel>();

        public IEnumerable<ActorNamesViewModel> Actors = new List<ActorNamesViewModel>();

        public IEnumerable<CinemaIndexViewModel> Cinemas = new List<CinemaIndexViewModel>();

    }
}
