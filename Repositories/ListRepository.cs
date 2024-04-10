using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RefactorBEcapstone.Contexts;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace RefactorBEcapstone.Repositories
{
    public class ListRepository : GenericRepository<ChristmasList>
    {
        public ListRepository(RefactorDbContext context) : base(context)
        {

        }
    }
}