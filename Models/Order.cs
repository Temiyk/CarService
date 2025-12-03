using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa4.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public DateTime AcceptionDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public string Status { get; set; } = "Создан";
        public decimal Price { get; set; }
        public Client Client { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
