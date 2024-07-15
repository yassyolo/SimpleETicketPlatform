using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.CustomExceptions;
using SimpleETicketPlatform.Core.Models.Actors;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Core.Models.Producers;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
	public class MoviesService : IMoviesService
	{
		private readonly IRepository repository;

		public MoviesService(IRepository repository)
		{
			this.repository = repository;
		}
		public async Task<List<AllMoviesViewModel>?> GetAllMoviesAsync()
		{
			return await repository.AllReadOnly<Movie>()
				.Include(x => x.Cinema)
				.Select(x => new AllMoviesViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					StartDate = x.StartDate.ToString("dd-MM-yyyy"),
					EndDate = x.EndDate.ToString("dd-MM-yyyy"),
					PhotoURL = x.PhotoURL,
					CinemaName = x.Cinema.Name,
					MovieCategory = x.MovieCategory.ToString(),
					Price = x.Price,
					Status = x.EndDate > DateTime.Today ? "AVAILABLE" : "NOT AVAILABLE"
				})
				.ToListAsync();
		}

		public async Task<MovieDetailsViewModel?> GetDetailsForMovie(int id)
		{
			var movie = await repository.AllReadOnly<Movie>()
				.Include(x => x.Cinema)
				.Include(x => x.Producer)
				.Select(x => new MovieDetailsViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					StartDate = x.StartDate.ToString("dd-mm-yyyy"),
					EndDate = x.EndDate.ToString("dd-mm-yyyy"),
					PhotoURL = x.PhotoURL,
					CinemaName = x.Cinema.Name,
					MovieCategory = x.MovieCategory.ToString(),
					Price = x.Price,
					Status = x.EndDate > DateTime.Today ? "AVAILABLE" : "NOT AVAILABLE",					
				})
				.FirstOrDefaultAsync();
			movie.Producer = await GetProducerForMovie(id);
			movie.Actors = await GetActorsForMovie(id);
			return movie;
		}

		private async Task<IEnumerable<ActorIndexViewModel>> GetActorsForMovie(int id)
		{
			return await repository.AllReadOnly<MovieActor>().Include(x => x.Actor).Where(x => x.MovieId == id)
				.Select(x => new ActorIndexViewModel()
				{
					Id = x.Actor.Id,
					ProfilePictureURL = x.Actor.ProfilePictureURL,
					FullName = x.Actor.FullName
				}).ToListAsync();
		}

		private async  Task<ProducerIndexViewModel> GetProducerForMovie(int id)
		{
			var producer = await repository.AllReadOnly<Movie>().Include(x => x.Producer).Where(x => x.Id == id)
				.Select(x => new ProducerIndexViewModel()
				{
					Id = x.ProducerId,
					FullName = x.Producer.FullName,
					Biography = x.Producer.Biography
				}).FirstOrDefaultAsync();
			if (producer == null)
			{
				throw new MovieDoesNotExistException("Movie does not exist!");
			}
			return producer;
		}

		public async Task<bool> MovieExistsWithId(int id)
		{
			return await repository.AllReadOnly<Movie>().AnyAsync(x => x.Id == id);
		}

		public async Task<NewMovieDropdownsViewModel> GetNewMovieDropdowns()
		{
			var dropdown = new NewMovieDropdownsViewModel()
			{
				Actors = await repository.AllReadOnly<Actor>().OrderBy(x => x.FullName).ToListAsync(),
			    Cinemas = await repository.AllReadOnly<Cinema>().OrderBy(x => x.Name).ToListAsync(),
			    Producers = await repository.AllReadOnly<Producer>().OrderBy(x => x.FullName).ToListAsync()
		    };
			return dropdown;
		}

		public async Task<FilteredMoviesViewModel> FilterMoviesAsync(string searchTerm)
		{
			var moviesQuery = repository.AllReadOnly<Movie>();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				var normalizedSearchTerm = searchTerm.ToLower();
				moviesQuery = moviesQuery.Where(x =>
	             x.Producer.FullName.ToLower().Contains(normalizedSearchTerm)
	             || x.Cinema.Name.ToLower().Contains(normalizedSearchTerm)
	             || x.MovieActors.Any(ma => ma.Actor.FullName.ToLower().Contains(normalizedSearchTerm))
	             || x.Name.ToLower().Contains(normalizedSearchTerm));
			}

			var moviesToShow = await moviesQuery.Select(x => new AllMoviesViewModel()
			{
				Id = x.Id,
				Name = x.Name,
				StartDate = x.StartDate.ToString("dd-MM-yyyy"),  
				EndDate = x.EndDate.ToString("dd-MM-yyyy"),      
				PhotoURL = x.PhotoURL,
				CinemaName = x.Cinema.Name,
				MovieCategory = x.MovieCategory.ToString(),
				Price = x.Price,
				Status = x.EndDate > DateTime.Today ? "AVAILABLE" : "NOT AVAILABLE"
			}).ToListAsync();

			return new FilteredMoviesViewModel()
			{
				MoviesMatched = moviesToShow.Count,  
				Movies = moviesToShow
			};
		}

		public async Task AddNewMovieAsync(MovieFormViewModel model)
		{
			var movie = new Movie()
			{
				Name = model.Name,
				Description = model.Description,
				PhotoURL = model.PhotoURL,
				Price = model.Price,
				ProducerId = model.ProducerId,
				CinemaId = model.CinemaId,
				MovieCategory = model.MovieCategory
			};
			await repository.AddAsync<Movie>(movie);
			await repository.SaveChangesAsync();
			foreach (var actorId in model.ActorIds)
			{
				var movieActor = new MovieActor()
				{
					ActorId = actorId,
					MovieId = movie.Id
				};
				await repository.AddAsync<MovieActor>(movieActor);
				await repository.SaveChangesAsync();
			}
		}
	}
}

