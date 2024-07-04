
using SimpleETicketPlatform.Core.Models.Actors;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IActorsService
    {
        Task<List<ActorIndexViewModel?>> GetAllActorsAsync();
    }
}
