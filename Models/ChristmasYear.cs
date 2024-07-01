using RefactorBEcapstone.List.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.Models
{
    public class ChristmasYear
    {
        public int Id { get; set; }
        public string ListYear { get; set; }
        public decimal YearBudget { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<ListResponse> ChristmasLists { get; set; }
        public decimal ListsTotal => ChristmasLists?.Sum(l => l.ListTotal) ?? 0;
        public decimal BudgetVar => YearBudget - ListsTotal;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
    }
}
