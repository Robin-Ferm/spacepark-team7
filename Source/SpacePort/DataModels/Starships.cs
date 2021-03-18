using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort.DataModels
{
    class Starships
    {
        public int Count { get; set; }
        public List<Starship> Results { get; set; }
        public string Next { get; set; }
    }
    class Starship
    {
        public string Name { get; set; }
        public string Model { get; set; }
    }
}
