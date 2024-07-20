using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Models.Cart
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal SubTotal { get; set; }
    }
}
