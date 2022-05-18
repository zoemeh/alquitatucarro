namespace AlquitaTuCarro.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cedula { get; set; }  
        public string Shift { get; set; }
        public int Comission { get; set; }
        public DateTime HiredDate { get; set; }
        public bool IsActive { get; set; }

    }
}
