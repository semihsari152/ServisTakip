namespace ServisTakipWebAPI.Models.Response
{
    public class ProductResponseModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public int ProductSerialNumber { get; set; }
        public string? ProductAccessories { get; set; }

        public List<FaultTrack>? FaultTracks { get; set; }
    }
}