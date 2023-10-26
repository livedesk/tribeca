using clients_api;
using clients_api.Controllers;
using clients_api.Models;
using System.Reflection;

namespace clients_test
{
    public class DataTest
    {
        private InMemoryStore _inMemoryStore = new InMemoryStore();

        public DataTest()
        {
            LoadTestData();
        }

        [Fact]
        public void GetEmployee()
        {
            string name = "Sam Kemp";
            Employee? employee = _inMemoryStore.GetEmployee(name);

            Assert.NotNull(employee);

            Assert.True(employee.EmployeeName == name);
        }

        [Fact]
        public void GetClient()
        {
            string name = "Client A";

            Client? client = _inMemoryStore.GetClient(name);

            Assert.NotNull(client);

            Assert.True(client.ClientName == name);
        }

        [Fact]
        public void TranslateToDevMagic()
        {
            string word = "Duck";

            Assert.True(word.ConvertToDevMagic() == "uckday");
        }

        [Fact]
        public void TranslateToEnglish()
        {
            string word = "uckday";

            Assert.True(word.ConvertToEnglish() == "duck");
        }


        private void LoadTestData()
        {
            // Create and populate Client A
            Client clientA = new Client
            {
                ClientName = "Client A",
                Offices = new List<Office>
                {
                    new Office { OfficeAddress = "123 Street" },
                    new Office { OfficeAddress = "66 Road" },
                    new Office { OfficeAddress = "11 Spooner Road", IsHeadOffice = true}
                },
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Sam Fisher", Bio = "I love snowboarding and dogs",DateOfBirth = new  DateTime(2001, 2, 11) },
                    new Employee { EmployeeName = "John Fisher", Bio = "I live in a yellow submarine",DateOfBirth = new  DateTime(1992, 1, 14)  },
                    new Employee { EmployeeName = "Peter Fisher", Bio = "Flowers are great!", DateOfBirth = new  DateTime(1995, 8, 11) },
                }
            };

            // Create and populate Client B
            Client clientB = new Client
            {
                ClientName = "Client B",
                Offices = new List<Office>
                {
                    new Office { OfficeAddress = "123 Flight Street" },
                    new Office { OfficeAddress = "64 Zoo Lane", IsHeadOffice = true },
                    new Office { OfficeAddress = "22 Round Tree Road" }
                },
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Sam Kemp", Bio = "Fish are friends, not food.", DateOfBirth = new DateTime(1992, 1, 14) },
                    new Employee { EmployeeName = "John Kemp", Bio = "I live in a blue submarine.", DateOfBirth = new DateTime(1980, 3, 16) },
                    new Employee { EmployeeName = "Peter Kemp", Bio = "Coffee is the best!", DateOfBirth = new DateTime(1997, 8, 14) }
                }
            };

            // Create and populate Client C
            Client clientC = new Client
            {
                ClientName = "Client C",
                Offices = new List<Office>
                {
                    new Office { OfficeAddress = "33 Mile Street", IsHeadOffice = true },
                    new Office { OfficeAddress = "66 Road" },
                    new Office { OfficeAddress = "44 Sprinkle Road" }
                },
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "John Doe", Bio = "I hate robots!", DateOfBirth = new DateTime(1982, 4, 16) },
                    new Employee { EmployeeName = "Jane Doe", Bio = "Life is like a house of cards", DateOfBirth = new DateTime(1991, 9, 19) },
                    new Employee { EmployeeName = "Peter Doe", Bio = "Birds fly around my head!", DateOfBirth = new DateTime(1995, 7, 22) }
                }
            };

            _inMemoryStore.AddClient(clientA);
            _inMemoryStore.AddClient(clientB);
            _inMemoryStore.AddClient(clientC);
        }


    }
}