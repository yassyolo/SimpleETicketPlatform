namespace SimpleETicketPlatform.Core.Models.Movies
{
    public class FilteredMoviesViewModel
    { 
        public string SearchTerm { get; set; } = string.Empty;
        public int MoviesMatched { get; set; }
        public IEnumerable<AllMoviesViewModel> Movies { get; set; } = new List<AllMoviesViewModel>();
    }
}
