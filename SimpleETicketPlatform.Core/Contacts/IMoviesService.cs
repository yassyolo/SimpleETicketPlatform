
using SimpleETicketPlatform.Core.Models.Movies;

namespace SimpleETicketPlatform.Core.Contacts
{
	public interface IMoviesService
	{
		Task<List<AllMoviesViewModel>?> GetAllMoviesAsync();
		Task<MovieDetailsViewModel?> GetDetailsForMovie(int id);
		Task<bool> MovieExistsWithId(int id);
		Task<NewMovieDropdownsViewModel> GetNewMovieDropdowns();
		Task<FilteredMoviesViewModel> FilterMoviesAsync(string searchTerm);
		Task AddNewMovieAsync(MovieFormViewModel model);
	}
}
