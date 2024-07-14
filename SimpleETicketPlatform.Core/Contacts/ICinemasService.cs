
using SimpleETicketPlatform.Core.Models.Cinemas;

namespace SimpleETicketPlatform.Core.Contacts
{
	public interface ICinemasService
	{
		Task AddCinemaAsync(CinemaFormViewModel model);
		Task<bool> CinemaExistsByIdAsync(int id);
		Task DeleteCinemaAsync(int id);
		Task EditCinemaAsync(int id, CinemaFormViewModel model);
		Task<List<CinemaIndexViewModel>?> GetAllCinemasAsync();
		Task<CinemaFormViewModel?> GetCinemaForEditAsync(int id);
		Task<CinemaDetailsViewModel?> GetDetailsForCinemaAsync(int id);
	}
}
