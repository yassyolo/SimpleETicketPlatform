using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.CustomExceptions;
using SimpleETicketPlatform.Core.Models.Actors;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IRepository repository;

        public ActorsService(IRepository repository)
        {
            this.repository = repository;
        }

		public async Task<bool> ActorExistsByIdAsync(int id)
		{
            return await repository.AllReadOnly<Actor>().AnyAsync(x => x.Id == id);
		}

		public async Task AddNewActorAsync(ActorFormViewModel model)
		{
            var actor = new Actor()
            {
                Biography = model.Biography,
                FullName = model.FullName,
                ProfilePictureURL = model.ProfilePictureURL
            };
            await repository.AddAsync(actor);
            await repository.SaveChangesAsync();
		}

		public async Task DeleteActorAsync(int id)
		{
            var actor = await repository.All<Actor>().Where(x => x.Id == id).FirstOrDefaultAsync();
            await repository.DeleteAsync(actor);
		}

		public async Task EditActorAsync(int id, ActorFormViewModel model)
		{
            var actor = await repository.All<Actor>().Where(x => x.Id == id).FirstOrDefaultAsync();
            actor.FullName = model.FullName;
            actor.Biography = model.Biography;
            actor.ProfilePictureURL = model.ProfilePictureURL;
            await repository.SaveChangesAsync();
		}

		public async Task<ActorIndexViewModel?> GetActorForDeleteAsync(int id)
		{
			return await repository.AllReadOnly<Actor>().Where(x => x.Id == id)
				.Select(x => new ActorIndexViewModel()
				{
					Id = x.Id,
					FullName = x.FullName,
				})
				.FirstOrDefaultAsync();
		}

		public async Task<ActorFormViewModel?> GetActorForEditAsync(int id)
		{
            return await repository.AllReadOnly<Actor>().Where(x => x.Id == id)
                .Select(x => new ActorFormViewModel()
                {
                    Id = x.Id,
                    ProfilePictureURL = x.ProfilePictureURL,
                    FullName = x.FullName,
                    Biography = x.Biography
                })
                .FirstOrDefaultAsync();
		}

		public async Task<FilteredActorsViewModel> GetAllActorsAsync(string searchTerm)
        {
            var actors =  repository.AllReadOnly<Actor>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var normalizedSearchTerm = searchTerm.ToLower();
                actors = actors.Where(x => x.FullName.Contains(normalizedSearchTerm));
            }
            var actorsToShow =  await actors
                .Select(x => new ActorIndexViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Biography = x.Biography,
                    ProfilePictureURL = x.ProfilePictureURL
                }).ToListAsync();
            return new FilteredActorsViewModel()
            {
                Actors = actorsToShow,
                ActorsMatched = actorsToShow.Count()
            };
        }

		public async Task<ActorDetailsViewModel?> GetDetailsForActorAsync(int id)
		{
            var actor = await repository.AllReadOnly<Actor>().
                Where(x => x.Id == id).
                Select(x => new ActorDetailsViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Biography = x.Biography,
                    ProfilePictureURL = x.ProfilePictureURL,
                    Movies = x.MovieActors.Select( x=> new MovieIndexViewModel()
                    {
                        Id = x.MovieId,
                        Name = x.Movie.Name,
                        Category = x.Movie.MovieCategory.ToString()
                    })
                }).FirstOrDefaultAsync();
           
            return actor;
		}

		
	}
}
