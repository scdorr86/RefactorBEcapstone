using RefactorBEcapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.Year.Responses
{
    public class YearResponse
    {
        public int Id { get; set; }
        public string ListYear { get; set; }
        public decimal YearBudget { get; set; }
        public int UserId { get; set; }

        public decimal ListsTotal {  get; set; }
        public decimal BudgetVar {  get; set; }
    }
}
