using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.Models
{
    public class ChristmasList
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public int ChristmasYearId { get; set; }
        public ChristmasYear ChristmasYear { get; set; }
        public int GifteeId { get; set; }
        public Giftee Giftee { get; set; }
        public List<Gift> Gifts { get; set; }
        public decimal ListTotal => Gifts?.Sum(g => g.Price) ?? 0;
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
