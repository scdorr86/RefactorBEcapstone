using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.List.Requests
{
    public class CreateListRequest
    {
        public string ListName { get; set; }
        public int GifteeId { get; set; }
        public int ChristmasYearId { get; set; }
        public string UserId { get; set; }
    }
}