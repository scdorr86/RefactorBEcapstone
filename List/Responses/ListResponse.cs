using RefactorBEcapstone.Gift.Responses;
using RefactorBEcapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.List.Responses
{
    public class ListResponse
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<GiftResponse> Gifts { get; set; }
        public int GifteeId { get; set; }
        public int ChristmasYearId { get; set; }
        public string UserId { get; set; }
        public decimal ListTotal { get; set; }
 
    }
}
