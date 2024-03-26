namespace RefactorBEcapstone.Models
{
    public class Giftee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ChristmasList> ChristmasLists { get; set; }
        public int NumOfLists => ChristmasLists?.Count ?? 0;
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
