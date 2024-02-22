using System.ComponentModel.DataAnnotations;

namespace ServisTakipWebAPI.Models
{
    public class ProductMovement
    {
        [Key]
        public int MovementID { get; set; }
        public DateTime MovementDate { get; set; }
        public string? MovementDescription { get; set; }

        public virtual FaultTrack? FaultTrack { get; set; }
    }
}
