using coursa4.Data;
using coursa4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa4.Testrer
{
    internal class DBTester
    {
        public static void TestDatabase()
        {
            try
            {
                Console.WriteLine("🔄 Testing database connection...");

                using var context = new Coursa4Context();

                // Test connection
                bool canConnect = context.Database.CanConnect();
                Console.WriteLine($"✅ Database connection: {canConnect}");

                if (canConnect)
                {
                    // Test creating client
                    var client = new Client
                    {
                        FirstName = "Иван",
                        LastName = "Петров",
                        PhoneNumber = "+79123456789",
                        Email = "ivan.petrov@example.com"
                    };

                    context.Clients.Add(client);
                    context.SaveChanges();
                    Console.WriteLine("✅ Client created successfully!");

                    // Test reading clients
                    var clientsCount = context.Clients.Count();
                    Console.WriteLine($"✅ Clients in database: {clientsCount}");

                    // Test creating vehicle
                    var vehicle = new Vehicle
                    {
                        ClientId = client.Id,
                        Brand = "Toyota",
                        Model = "Camry",
                        Year = 2020,
                        VIN = "1HGCM82633A123456",
                        LicensePlate = "A123BC",
                        Mileage = 45000
                    };

                    context.Vehicles.Add(vehicle);
                    context.SaveChanges();
                    Console.WriteLine("✅ Vehicle created successfully!");

                    // Test creating employee
                    var employee = new Employee
                    {
                        FirstName = "Алексей",
                        LastName = "Сидоров",
                        Specialization = "Механик",
                        Status = "Доступен"
                    };

                    context.Employees.Add(employee);
                    context.SaveChanges();
                    Console.WriteLine("✅ Employee created successfully!");

                    Console.WriteLine("\n🎉 All tests passed successfully!");
                    Console.WriteLine("📊 Database statistics:");
                    Console.WriteLine($"   Clients: {context.Clients.Count()}");
                    Console.WriteLine($"   Vehicles: {context.Vehicles.Count()}");
                    Console.WriteLine($"   Employees: {context.Employees.Count()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.WriteLine($"Details: {ex.InnerException?.Message}");
            }
        }
    }
}
