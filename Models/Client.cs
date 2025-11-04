using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa4.Models
{
    internal class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email {get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
