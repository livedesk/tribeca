namespace clients_api.Models
{
    public class InMemoryStore
    {
        public readonly List<Client> _clients = new List<Client>();
        public void AddClient(Client client)
        {
            _clients.Add(client);
        }
        public Client? GetClient(string clientName) { 
            
            Client? client = _clients.FirstOrDefault(x => x.ClientName == clientName);

            if (client != null)
            {
                // order offices so Head Office to be at the top of the list
                var orderedOffices = from office in client.Offices
                                     orderby office.IsHeadOffice descending
                                     select office;

                client.Offices = orderedOffices.ToList();
            }

            return client;
        }

        public Employee? GetEmployee(string employeeName)
        {
            Employee? emp = _clients.SelectMany(client => client.Employees)
                           .FirstOrDefault(x => x.EmployeeName == employeeName);
            return emp;
        }
    }
}
