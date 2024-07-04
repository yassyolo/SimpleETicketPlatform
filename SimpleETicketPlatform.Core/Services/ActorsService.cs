using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Actors;
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

        public async Task<List<ActorIndexViewModel?>> GetAllActorsAsync()
        {
            return await repository.AllReadOnly<Actor>()
                .Select(x => new ActorIndexViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Biography = x.Biography,
                    ProfilePictureURL = x.ProfilePictureURL
                }).ToListAsync();
        }
    }
}
