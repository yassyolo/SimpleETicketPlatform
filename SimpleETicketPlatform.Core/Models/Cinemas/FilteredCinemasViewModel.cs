using SimpleETicketPlatform.Core.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Models.Cinemas
{
    public class FilteredCinemasViewModel
    {
        public IEnumerable<CinemaIndexViewModel> Cinemas { get; set; } = new List<CinemaIndexViewModel>();
        public string SearchTerm { get; set; } = string.Empty;
        public int CinemasMatched { get; set; }
    }
}
