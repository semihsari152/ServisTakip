﻿namespace ServisTakipWebAPI.Models.Response
{
    public class FaultTrackResponseModel
    {
        public int FaultTrackingID { get; set; }
        public string? FaultDefinition { get; set; }
        public string? FaultWorkerName { get; set; }
        public string? FaultDocumentNumber { get; set; }
        public DateTime FaultCreateDate { get; set; }
        public DateTime FaultUpdateDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string? FaultDescription { get; set; }
        public string? FaultStage { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}