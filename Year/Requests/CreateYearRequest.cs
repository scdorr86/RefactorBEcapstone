using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.Year.Requests
{
    public class CreateYearRequest
    {
        public string ListYear { get; set; }
        public decimal YearBudget { get; set; }
        public string UserId { get; set; }
    }
}
