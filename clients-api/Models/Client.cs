namespace clients_api.Models
{
    public class Client
    {
        public string ClientName { get; set; }
        public List<Office> Offices { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
