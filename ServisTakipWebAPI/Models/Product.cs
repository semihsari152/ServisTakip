using ServisTakipWebAPI.Models.Request;
using System.ComponentModel.DataAnnotations;

namespace ServisTakipWebAPI.Models
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public int ProductSerialNumber { get; set; }
        public string? ProductAccessories { get; set; }

        public ICollection<FaultTrack>? FaultTrack { get; set; }

    }
}