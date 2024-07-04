using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Models.Actors
{
    public class ActorIndexViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public string ProfilePictureURL { get; set; } = string.Empty;

        public IEnumerable<MovieActor> MovieActors = new List<MovieActor>();
    }
}
