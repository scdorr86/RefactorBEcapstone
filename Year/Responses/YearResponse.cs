﻿using RefactorBEcapstone.List.Responses;
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
        public string UserId { get; set; }

        public decimal ListsTotal {  get; set; }
        public decimal BudgetVar {  get; set; }
        public List<ListResponse> ChristmasLists { get; set; }
    }
}
