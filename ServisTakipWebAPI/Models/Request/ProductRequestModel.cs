﻿namespace ServisTakipWebAPI.Models.Request
{
    public class ProductRequestModel
    {
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public int ProductSerialNumber { get; set; }
        public string? ProductAccessories { get; set; }
    }
}