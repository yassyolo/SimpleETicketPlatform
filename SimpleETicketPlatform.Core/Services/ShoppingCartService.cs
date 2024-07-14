using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
	{
		private readonly IRepository repository;

		public ShoppingCartService(IRepository repository)
		{
			this.repository = repository;
		}
	}
}
