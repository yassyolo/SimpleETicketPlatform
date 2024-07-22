
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
        Task<MovieFormViewModel>? GetMovieForEditAsync(int id);
        Task EditMovieAsync(int id, MovieFormViewModel model);
        Task<MovieIndexViewModel?> GetMovieForDeleteAsync(int id);
        Task DeleteMovieAsync(int id);
    }
}
