using System;

namespace ShopDesktop.Models
{
    public class Repair
    {
        public Guid Id { get; set; }
        public string ClientNumber { get; set; }
        public float Cost { get; set; }
        public string VehicleNumber { get; set; }
        public string RepairTypeName { get; set; }
        public float Mileage { get; set; }
        public Guid RepairType { get; set; }
    }
}