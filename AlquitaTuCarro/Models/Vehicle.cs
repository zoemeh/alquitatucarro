namespace AlquitaTuCarro.Models
{
    public class Vehicle
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public string ChasisSerial { get; set; }
        public string MotorSerial { get; set; }
        public string LicensePlate { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleBrandId { get;  set; }
        public int FuelTypeId { get; set; }
        public bool IsActive { get; set; }


    }
}
