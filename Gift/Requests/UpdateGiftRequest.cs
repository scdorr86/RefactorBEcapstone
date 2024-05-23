namespace RefactorBEcapstone.Gift.Requests
{
    public class UpdateGiftRequest
    {
        public string GiftName { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string OrderedFrom { get; set; }
    }
}
