namespace CarPool.Data
{
    public class BookedRide
    {
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
        public float Price { get; set; }
        public int SeatsBooked { get; set; }
    }
}
