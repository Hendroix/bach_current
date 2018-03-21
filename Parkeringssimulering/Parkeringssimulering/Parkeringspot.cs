using System;
using System.Collections;
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
        /// The list of cars
        /// </summary>
        public ArrayList listOfCars = new ArrayList();

        /// <summary>
        /// Initializes a new instance of the <see cref="Parkingspot" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="totalParkingSpaces">The total parking spaces.</param>
        /// <param name="takenSpaces">The taken spaces.</param>
        public Parkingspot(string name, int totalParkingSpaces, int takenSpaces)
        {
            this.name = name;
            this.totalParkingSpaces = totalParkingSpaces;
            this.takenSpaces = takenSpaces;
            freeSpaces = totalParkingSpaces - takenSpaces;
        }
        /// <summary>
        /// Gets the taken spaces.
        /// </summary>
        /// <returns></returns>
        public int getTakenSpaces()
        {
            return takenSpaces;
        }
        /// <summary>
        /// Adds the taken spaces.
        /// </summary>
        public void addTakenSpaces()
        {
            if (freeSpaces > 0)
            this.takenSpaces++;
        }
        /// <summary>
        /// Gets the free spaces.
        /// </summary>
        /// <returns></returns>
        public int getFreeSpaces()
        {
            return freeSpaces;
        }
        public int getTotalParkingSpaces()
        {
            return totalParkingSpaces;
        }
        public bool Free()
        {
            if (freeSpaces > 0)
                return true;
            else
                return false;
        }
    }
}
