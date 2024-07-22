using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Movie category entity")]
    public class MovieCategory
    {
        [Key]
        [Comment("Movie category identifier")]
        public int Id { get; set; }

        [Comment("Movie category name")]
        public string Name { get; set; } = string.Empty;
        /*Action = 1,
        Fantasy, 
        Drama,
        Romance,
        Cartoon,
        Comedy,
        Thriller*/
    }
}
