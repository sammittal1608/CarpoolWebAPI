namespace CarPool.Data
{
    public class MatchingRideResponse
    {
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
        public string CustomerId { get; set; }
        public int AvailableSeats { get; set; }
        public float Price { get; set; }
    }
}
