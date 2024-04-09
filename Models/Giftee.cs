﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone.Models
{
    public class Giftee : Auditable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ChristmasList> ChristmasLists { get; set; }
        public int NumOfLists => ChristmasLists?.Count ?? 0;
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
