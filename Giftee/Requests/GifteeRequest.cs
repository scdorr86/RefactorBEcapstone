using RefactorBEcapstone.Models;

namespace RefactorBEcapstone.Giftee.Requests
{
    public class GifteeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public List<ChristmasList> ChristmasLists { get; set; }
        // public int NumOfLists => ChristmasLists?.Count ?? 0;
        public string UserId { get; set; }
    }
}
