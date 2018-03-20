using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    public class Parkeringspot
    {
        public String name;
        public int totalParkingSpaces;
        public int takenSpaces;
        public int freeSpaces;

        public Parkeringspot(string name, int totalParkingSpaces, int freeSpaces, int takenSpaces)
        {
            this.name = name;
            this.totalParkingSpaces = totalParkingSpaces;
            this.takenSpaces = takenSpaces;
            this.freeSpaces = totalParkingSpaces - takenSpaces;
        }
    }
}
