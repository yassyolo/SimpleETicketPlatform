using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Cinemas;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
    public class CinemasService : ICinemasService
    {
		private readonly IRepository repository;

		public CinemasService(IRepository repository)
		{
			this.repository = repository;
		}

		public async Task AddCinemaAsync(CinemaFormViewModel model)
		{
			var cinema = new Cinema()
			{
				Name = model.Name,
				Description = model.Description,
				Logo = model.Logo
			};
			await repository.AddAsync(cinema);
			await repository.SaveChangesAsync();
		}

		public async Task<bool> CinemaExistsByIdAsync(int id)
		{
			return await repository.AllReadOnly<Cinema>().AnyAsync(x => x.Id == id);
		}

		public async Task DeleteCinemaAsync(int id)
		{
			var cinema = await repository.GetByIdAsync<Cinema>(id);
			await repository.DeleteAsync<Cinema>(cinema);
		}

		public async Task EditCinemaAsync(int id, CinemaFormViewModel model)
		{
			var cinema = await repository.GetByIdAsync<Cinema>(id);
			cinema.Logo = model.Logo;
			cinema.Name = model.Name;
			cinema.Description = model.Description;

			await repository.SaveChangesAsync();
		}

		public async Task<FilteredCinemasViewModel?> GetAllCinemasAsync(string searchTerm)
		{
			var cinemas = repository.AllReadOnly<Cinema>();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				var normalizedSearchTerm = searchTerm.ToLower();
				cinemas = cinemas.Where(x => x.Name.Contains(normalizedSearchTerm));
			}
			var cinemasToShow = await cinemas.
				Select(x => new CinemaIndexViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Logo = x.Logo
				}).ToListAsync();
			return new FilteredCinemasViewModel()
			{
				Cinemas = cinemasToShow,
				CinemasMatched = cinemasToShow.Count()
			};
		}

		public async Task<CinemaIndexViewModel?> GetCinemaForDeleteAsync(int id)
		{
			return await repository.All<Cinema>().Where(x => x.Id == id).
				Select(x => new CinemaIndexViewModel()
				{
					Id = x.Id,
					Name = x.Name,
				}).FirstOrDefaultAsync();
		}

		public async Task<CinemaFormViewModel?> GetCinemaForEditAsync(int id)
		{
			return await repository.All<Cinema>().
				Select(x => new CinemaFormViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Logo = x.Logo,
				}).FirstOrDefaultAsync();
		}

		public async Task<CinemaDetailsViewModel?> GetDetailsForCinemaAsync(int id)
		{
			var cinema = await  repository.All<Cinema>().
				Select(x => new CinemaDetailsViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Logo = x.Logo,
					MoviesCount = GetMoviesCountForCinema(id),
				}).FirstOrDefaultAsync();
			cinema.Movies = await GetMoviesForCinemaAsync(id);
			return cinema;
        }

        private async Task<IEnumerable<MovieIndexViewModel>> GetMoviesForCinemaAsync(int id)
        {
			return await repository.AllReadOnly<Movie>().Where(x => x.CinemaId == id && x.EndDate <= DateTime.Now).
				Select(x => new MovieIndexViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Category = x.MovieCategory.ToString()
				}).ToListAsync();
        }

        private int GetMoviesCountForCinema(int id)
		{
			return  repository.AllReadOnly<Movie>().Where(x => x.CinemaId == id).Count();
		}
	}
}
