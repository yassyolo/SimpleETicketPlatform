using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Movie actor entity")]
    public class MovieActor
    {
        [Comment("Movie identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [Comment("Movie")]
        public Movie Movie { get; set; } = null!;

        [Comment("Actor identifier")]
        public int ActorId { get; set; }

        [ForeignKey(nameof(ActorId))]
        [Comment("Actor")]
        public Actor Actor { get; set; } = null!;
    }
}
