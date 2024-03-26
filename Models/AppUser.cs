using Microsoft.AspNetCore.Identity;

namespace RefactorBEcapstone.Models
{
    public class AppUser : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uid { get; set; }
        public string ImageUrl { get; set; }
        public List<ChristmasYear> ChristmasYear { get; set; }
        public int NumberOfYears => ChristmasYear?.Count ?? 0;
        public List<ChristmasList> ChristmasList { get; set; }
        public int NumberOfLists => ChristmasList?.Count ?? 0;
    }
}
