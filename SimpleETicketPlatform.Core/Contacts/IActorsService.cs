
using SimpleETicketPlatform.Core.Models.Actors;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IActorsService
    {
		Task<bool> ActorExistsByIdAsync(int id);
		Task AddNewActorAsync(ActorFormViewModel model);
		Task DeleteActorAsync(int id);
		Task EditActorAsync(int id, ActorFormViewModel model);
		Task<ActorFormViewModel?> GetActorForEditAsync(int id);
		Task<FilteredActorsViewModel> GetAllActorsAsync(string searchTerm);
		Task<ActorDetailsViewModel?> GetDetailsForActorAsync(int id);
	}
}
