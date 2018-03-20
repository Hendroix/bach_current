using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    /// <summary>
    /// 
    /// </summary>
    public class Parkingspot
    {
        /// <summary>
        /// The name
        /// </summary>
        public String name;
        /// <summary>
        /// The total parking spaces
        /// </summary>
        public int totalParkingSpaces;
        /// <summary>
        /// The taken spaces
        /// </summary>
        public int takenSpaces;
        /// <summary>
        /// The free spaces
        /// </summary>
        public int freeSpaces;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parkingspot"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="totalParkingSpaces">The total parking spaces.</param>
        /// <param name="freeSpaces">The free spaces.</param>
        /// <param name="takenSpaces">The taken spaces.</param>
        public Parkingspot(string name, int totalParkingSpaces, int takenSpaces)
        {
            this.name = name;
            this.totalParkingSpaces = totalParkingSpaces;
            this.takenSpaces = takenSpaces;
            freeSpaces = totalParkingSpaces - takenSpaces;
        }
    }
}
