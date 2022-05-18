namespace AlquitaTuCarro.Models
{
    public class CarInspection
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public bool IsDented { get; set; }
        public int FuelLevel { get; set; }
        public bool HasSpareTire { get; set; }
        public bool HasCat { get; set; }
        public bool IsGlassBorken { get; set; }
        // INCOMPLETE
    }
}
