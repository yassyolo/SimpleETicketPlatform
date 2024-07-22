using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Core.Models.Producers;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants;


namespace SimpleETicketPlatform.Core.Services
{
    public class ProducersService : IProducersService
    {
		private readonly IRepository repository;

		public ProducersService(IRepository repository)
		{
			this.repository = repository;
		}

		public async Task<FilteredProducersViewModel> GetAllProducersAsync(string searchTerm)
		{
			var producers = repository.AllReadOnly<Infrastructure.Data.Models.Producer>();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				var normalizedSearchTerm = searchTerm.ToLower();
				producers = producers.Where(x => x.FullName.Contains(normalizedSearchTerm));
			}
			var producersToShow =  await producers.
				Select(x => new ProducerIndexViewModel()
				{
					Id = x.Id,
					FullName = x.FullName,
					Biography = x.Biography,
					ProfilePictureURL = x.ProfilePictureURL
				}).ToListAsync();
			return new FilteredProducersViewModel()
			{
				ProducersMatched = producersToShow.Count(),
				Producers = producersToShow
			};
		}

		public async Task<ProducerDetailsViewModel?> GetProducerDetailsAsync(int id)
		{
			var producer = await repository.AllReadOnly<Infrastructure.Data.Models.Producer>().
				Select(x => new ProducerDetailsViewModel()
				{
					Id = x.Id,
					FullName = x.FullName,
					Biography = x.Biography,
                    ProfilePictureURL = x.ProfilePictureURL
				}).FirstOrDefaultAsync();
			producer.Movies = await GetMoviesForProducer(id);

            return producer;
		}

		private async Task< IEnumerable<MovieIndexViewModel>> GetMoviesForProducer(int id)
		{
			return await repository.AllReadOnly<Infrastructure.Data.Models.Movie>().Where(x => x.ProducerId == id).
				Select(x => new MovieIndexViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Category = x.MovieCategory.Name.ToString()
				}).ToListAsync();
		}

		public async Task<bool> ProducerExistsByIdAsync(int id)
		{
			return await repository.AllReadOnly<Infrastructure.Data.Models.Producer>().AnyAsync(x => x.Id == id);
		}

		public async Task AddProducerAsync(ProducerFormViewModel model)
		{
			var producer = new Infrastructure.Data.Models.Producer()
			{
				FullName = model.FullName,
				Biography = model.Biography,
				ProfilePictureURL = model.ProfilePictureURL
			};
			await repository.AddAsync(producer);
			await repository.SaveChangesAsync();
		}

		public async Task<ProducerFormViewModel?> GetProducerForEditAsync(int id)
		{
			return await repository.AllReadOnly<Infrastructure.Data.Models.Producer>().Where(x => x.Id == id)
				.Select(x => new ProducerFormViewModel()
				{
					Id = x.Id,
					Biography = x.Biography,
					FullName = x.FullName,
					ProfilePictureURL = x.ProfilePictureURL
				}).FirstOrDefaultAsync();
		}

		public async Task EditProducerAsync(int id, ProducerFormViewModel model)
		{
			var producer = await repository.GetByIdAsync<Infrastructure.Data.Models.Producer>(id);
			producer.ProfilePictureURL = model.ProfilePictureURL;
			producer.FullName = model.FullName;
			producer.Biography = model.Biography;

			await repository.SaveChangesAsync();
		}

		public async Task DeleteProducerAsync(int id)
		{
			var producer = await repository.GetByIdAsync<Infrastructure.Data.Models.Producer>(id);

			await repository.DeleteAsync<Infrastructure.Data.Models.Producer>(producer);
		}

        public async Task<ProducerIndexViewModel?> GetProducerForDeleteAsync(int id)
        {
			return await repository.AllReadOnly<Infrastructure.Data.Models.Producer>().Where(x => x.Id == id)
				.Select(x => new ProducerIndexViewModel()
				{
					Id = x.Id,
					FullName = x.FullName
				}).FirstOrDefaultAsync();
        }
    }
}
