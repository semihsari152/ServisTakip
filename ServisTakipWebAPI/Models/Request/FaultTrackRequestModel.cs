﻿namespace ServisTakipWebAPI.Models.Request
{
    public class FaultTrackRequestModel
    {
        public string? FaultDefinition { get; set; }
        public string? FaultWorkerName { get; set; }
        public string? FaultDocumentNumber { get; set; }
        public DateTime FaultCreateDate { get; set; }
        public DateTime FaultUpdateDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string? FaultDescription { get; set; }
        public string? FaultStage { get; set; }

        public int ProductID { get; set; }
    }
}