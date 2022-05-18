namespace AlquitaTuCarro.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cedula { get; set; }
        public string CreditCardNumber { get; set; }
        public int CreditLimit { get; set; }  
        public string PersonType { get; set; }
        public bool IsActive { get; set; }

    }
}
