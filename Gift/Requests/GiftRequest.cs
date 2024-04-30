namespace RefactorBEcapstone.Gift.Requests
{
    public class GiftRequest
    {
        public string GiftName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public string OrderedFrom { get; set; }
    }
}
