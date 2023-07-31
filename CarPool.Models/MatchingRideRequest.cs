namespace CarPool.Data
{
    public class MatchingRideRequest
    {
        public string CustomerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string RideDate { get; set; }
        public string RideValidFrom { get; set; }
        public string RideValidTill { get; set; }
        public int RequiredSeats { get; set; }
    }
}
