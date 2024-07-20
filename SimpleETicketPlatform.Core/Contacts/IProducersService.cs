
using SimpleETicketPlatform.Core.Models.Producers;

namespace SimpleETicketPlatform.Core.Contacts
{
	public interface IProducersService
	{
		Task AddProducerAsync(ProducerFormViewModel model);
		Task DeleteProducerAsync(int id);
		Task EditProducerAsync(int id, ProducerFormViewModel model);
		Task<FilteredProducersViewModel> GetAllProducersAsync(string serachTerm);
		Task<ProducerDetailsViewModel?> GetProducerDetailsAsync(int id);
		Task<ProducerFormViewModel?> GetProducerForEditAsync(int id);
		Task<bool> ProducerExistsByIdAsync(int id);
	}
}
