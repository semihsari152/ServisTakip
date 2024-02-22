using System.ComponentModel.DataAnnotations;

namespace ServisTakipWebAPI.Models
{
    public class FaultTrack
    {
        [Key]
        public int FaultTrackingID { get; set; }
        public string? FaultDefinition { get; set; } //Arıza Tanımı
        public string? FaultWorkerName { get; set; }
        public string? FaultDocumentNumber { get; set; }
        public DateTime FaultCreateDate { get; set; }
        public DateTime FaultUpdateDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; } //Tahmini teslim tarihi
        public string? FaultDescription { get; set; }
        public int FaultStage { get; set; } // Arıza Hangi aşamada 0 1 2 3 4 5

        public virtual Product? Product { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<ProductMovement>? ProductMovements { get; set; }

    }
}