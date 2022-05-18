namespace AlquitaTuCarro.Models
{
    public class CarRent
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public float AmountPerDay { get; set; }
        public int TotalDays {  get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }

    }
}
