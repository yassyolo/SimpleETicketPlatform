using SimpleETicketPlatform.Core.Models.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Models.Producers
{
    public class FilteredProducersViewModel
    {
        public IEnumerable<ProducerIndexViewModel> Producers { get; set; } = new List<ProducerIndexViewModel>();
        public string SearchTerm { get; set; } = string.Empty;
        public int ProducersMatched { get; set; }
    }
}
