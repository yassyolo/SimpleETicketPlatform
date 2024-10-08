﻿using SimpleETicketPlatform.Core.Models.Cinemas;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface ICinemasService
	{
		Task AddCinemaAsync(CinemaFormViewModel model);
		Task<bool> CinemaExistsByIdAsync(int id);
		Task DeleteCinemaAsync(int id);
		Task EditCinemaAsync(int id, CinemaFormViewModel model);
        Task<FilteredCinemasViewModel?> GetAllCinemasAsync(string searchTerm);
		Task<CinemaIndexViewModel?> GetCinemaForDeleteAsync(int id);
		Task<CinemaFormViewModel?> GetCinemaForEditAsync(int id);
        Task<IEnumerable<CinemaIndexViewModel>> GetCinemaNamesAsync();
        Task<CinemaDetailsViewModel?> GetDetailsForCinemaAsync(int id);
	}
}
