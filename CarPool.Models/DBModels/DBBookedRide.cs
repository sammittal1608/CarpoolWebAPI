using System.ComponentModel.DataAnnotations;
namespace CarPool.Data.DBModels
{
    public class DBBookedRide
    {
        [Key]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
