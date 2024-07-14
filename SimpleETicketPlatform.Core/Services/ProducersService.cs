using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Movies;
using SimpleETicketPlatform.Core.Models.Producers;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
    public class ProducersService : IProducersService
    {
		private readonly IRepository repository;

		public ProducersService(IRepository repository)
		{
			this.repository = repository;
		}

		public async Task<List<ProducerIndexViewModel>?> GetAllProducersAsync()
		{
			return await repository.AllReadOnly<Producer>().
				Select(x => new ProducerIndexViewModel()
				{
					Id = x.Id,
					FullName = x.FullName,
					Biography = x.Biography,
					ProfilePictureURL = x.ProfilePictureURL
				}).ToListAsync();
		}

		public async Task<ProducerDetailsViewModel?> GetProducerDetailsAsync(int id)
		{
			var producer = await repository.AllReadOnly<Producer>().
				Select(x => new ProducerDetailsViewModel()
				{
					Id = x.Id,
					FullName = x.FullName,
					Biography = x.Biography,
					ProfilePictureURL = x.ProfilePictureURL,
					Movies = GetMoviesForProducer(id)
				}).FirstOrDefaultAsync();
			return producer;
		}

		private IEnumerable<MovieIndexViewModel> GetMoviesForProducer(int id)
		{
			return repository.AllReadOnly<Movie>().Where(x => x.ProducerId == id).
				Select(x => new MovieIndexViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Category = x.MovieCategory.ToString()
				}).ToList();
		}

		public async Task<bool> ProducerExistsByIdAsync(int id)
		{
			return await repository.AllReadOnly<Producer>().AnyAsync(x => x.Id == id);
		}

		public async Task AddProducerAsync(ProducerFormViewModel model)
		{
			var producer = new Producer()
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
			return await repository.AllReadOnly<Producer>().Where(x => x.Id == id)
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
			var producer = await repository.GetByIdAsync<Producer>(id);
			producer.ProfilePictureURL = model.ProfilePictureURL;
			producer.FullName = model.FullName;
			producer.Biography = model.Biography;

			await repository.SaveChangesAsync();
		}

		public async Task DeleteProducerAsync(int id)
		{
			var producer = await repository.GetByIdAsync<Producer>(id);

			await repository.DeleteAsync<Producer>(producer);
		}
	}
}
