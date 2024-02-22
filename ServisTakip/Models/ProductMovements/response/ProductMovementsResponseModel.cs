namespace ServisTakip.Models.ProductMovements.response
{
    public class ProductMovementsResponseModel
    {
        public int MovementID { get; set; }
        public DateTime MovementDate { get; set; }
        public string? MovementDescription { get; set; }

        public int FaultTrackID { get; set; }
    }
}
