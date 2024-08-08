namespace SimpleETicketPlatform.Core.Models.Cinemas
{
    public class FilteredCinemasViewModel
    {
        public IEnumerable<CinemaIndexViewModel> Cinemas { get; set; } = new List<CinemaIndexViewModel>();
        public string SearchTerm { get; set; } = string.Empty;
        public int CinemasMatched { get; set; }
    }
}
