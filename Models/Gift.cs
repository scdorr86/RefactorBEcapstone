using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.Models
{
    public class Gift : Auditable
    {
        public int Id { get; set; }
        public string GiftName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<ChristmasList> ChristmasLists { get; set; }
        public string OrderedFrom { get; set; }
    }
}
