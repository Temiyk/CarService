using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa4.Models
{
    internal class Vehicle
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string LicensePlate { get; set; }
        public int Mileage { get; set; }

        public Client Client { get; set; }
    }
}
