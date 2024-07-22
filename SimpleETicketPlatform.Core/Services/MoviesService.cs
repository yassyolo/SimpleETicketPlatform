using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.CustomExceptions;
using SimpleETicketPlatform.Core.Models.Actors;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Core.Models.Producers;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Migrations;
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
					MovieCategory = x.MovieCategory.Name.ToString(),
					Price = x.Price,
					Status = x.EndDate > DateTime.Today ? "AVAILABLE" : "NOT AVAILABLE"
				})
				.ToListAsync();
		}

		public async Task<MovieDetailsViewModel?> GetDetailsForMovie(int id)
		{
			var movie = await repository.AllReadOnly<Movie>()
				.Where(x => x.Id == id)
				.Include(x => x.Cinema)
				.Include(x => x.Producer)
				.Select(x => new MovieDetailsViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					StartDate = x.StartDate.ToString("dd-MM-yyyy"),
					EndDate = x.EndDate.ToString("dd-MM-yyyy"),
					PhotoURL = x.PhotoURL,
					CinemaName = x.Cinema.Name,
					MovieCategory = x.MovieCategory.Name.ToString(),
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
			    Producers = await repository.AllReadOnly<Producer>().OrderBy(x => x.FullName).ToListAsync(),
				Categories = await repository.AllReadOnly<MovieCategory>().OrderBy(x => x.Name).ToListAsync()
		    };
			return dropdown;
		}

		public async Task<FilteredMoviesViewModel> FilterMoviesAsync(string searchTerm)
		{
			var moviesQuery = repository.AllReadOnly<Movie>();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				var normalizedSearchTerm = searchTerm.ToLower();
				moviesQuery = moviesQuery.Where(x => x.Cinema.Name.ToLower().Contains(normalizedSearchTerm)
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
				MovieCategory = x.MovieCategory.Name.ToString(),
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
				MovieCategoryId = model.MovieCategoryId,
				StartDate = model.StartDate,
				EndDate = model.EndDate
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

        public async Task<MovieFormViewModel>? GetMovieForEditAsync(int id)
        {
			var movie = await repository.AllReadOnly<Movie>().Where(x => x.Id == id)
				.Select(x => new MovieFormViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					StartDate = x.StartDate,
					EndDate = x.EndDate,
					PhotoURL = x.PhotoURL,
					Price = x.Price,
					CinemaId = x.CinemaId,
					ProducerId = x.ProducerId,
					MovieCategoryId = x.MovieCategoryId,
					Description = x.Description
				}).FirstOrDefaultAsync();
			movie.ActorIds = await repository.AllReadOnly<MovieActor>().Include(x => x.Actor).Select(x => x.ActorId).ToListAsync();
			return movie;

        }

        public async Task EditMovieAsync(int id, MovieFormViewModel model)
        {
			var movie = await repository.All<Movie>().Where(x => x.Id == id).FirstOrDefaultAsync();

			movie.Id = model.Id;
			movie.Name = model.Name;
			movie.Description = model.Description;
			movie.Price = model.Price;
			movie.StartDate = model.StartDate;
			movie.EndDate = model.EndDate;
			movie.CinemaId = model.CinemaId;
			movie.ProducerId = model.ProducerId;
			movie.MovieCategoryId = model.MovieCategoryId;
			movie.PhotoURL = model.PhotoURL;
	
			foreach (var actorId in model.ActorIds)
			{
				var actor = await repository.All<MovieActor>().Where(x => x.ActorId == id).FirstOrDefaultAsync();
				if (actor == null)
				{
					var actorToAdd = new MovieActor()
					{
						ActorId = actorId,
						MovieId = id
					};
					await repository.AddAsync<MovieActor>(actorToAdd);
				}
				else
				{
					actor.ActorId = actorId;
				}
			}
            await repository.SaveChangesAsync();
        }

        public async Task<MovieIndexViewModel?> GetMovieForDeleteAsync(int id)
        {
			return await repository.AllReadOnly<Movie>().Where(x => x.Id == id)
				.Select(x => new MovieIndexViewModel()
				{
					Id = x.Id,
					Name = x.Name
				})
				.FirstOrDefaultAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await repository.All<Movie>().Where(x => x.Id == id).FirstOrDefaultAsync();
			var movieActors = await repository.All<MovieActor>().Where(x => x.MovieId == id).ToListAsync();

			foreach (var movieActor in movieActors)
			{
				if (movieActor == null)
				{
					throw new ActorDoesNotExistException("Actor does not exist!");
				}
				await repository.DeleteAsync<MovieActor>(movieActor);
			}
            await repository.DeleteAsync<Movie>(movie);
        }
    }
}

