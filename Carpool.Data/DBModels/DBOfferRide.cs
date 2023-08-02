using System.ComponentModel.DataAnnotations;
namespace CarPool.Data.DBModels
{
    public class DBOfferRide
    {
        [Key]
        public string OwnerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string RideValidFrom { get; set; }
        public string RideValidTill { get; set; }
        public int AvailableSeats { get; set; }
        public List<IntermediaryStop> IntermediaryStops { get; set; }
        public float Price { get; set; }
        public bool IsRideBooked { get; set; }
        public string CustomerId { get; set; }
    }
}
