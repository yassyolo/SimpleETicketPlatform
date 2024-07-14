namespace SimpleETicketPlatform.Core.Models.Actors
{
    public class FilteredActorsViewModel
    {
        public IEnumerable<ActorIndexViewModel> Actors { get; set; } = new List<ActorIndexViewModel>();
        public string SearchTerm { get; set; } = string.Empty;
        public int ActorsMatched { get; set; }
    }
}
