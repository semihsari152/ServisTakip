using System.ComponentModel.DataAnnotations;

namespace ServisTakipWebAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerCounty { get; set; }

    }
}
