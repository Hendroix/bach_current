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
    public class ParkingQueue
    {
        /// <summary>
        /// The name
        /// </summary>
        public String name;
        /// <summary>
        /// The cars in queue
        /// </summary>
        public Queue carsInQueue = new Queue();
        /// <summary>
        /// The related roads
        /// </summary>
        public ArrayList relatedRoads = new ArrayList();
        /// <summary>
        /// The related parking spots
        /// </summary>
        public ArrayList relatedParkingSpots = new ArrayList();

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingQueue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="carsInQueue">The cars in queue.</param>
        /// <param name="relatedRoads">The related roads.</param>
        /// <param name="parkingSpots">The parking spots.</param>
        public ParkingQueue(string name, Queue carsInQueue, ArrayList relatedRoads, ArrayList parkingSpots)
        {
            this.name = name;
            this.carsInQueue = carsInQueue;
            this.relatedRoads = relatedRoads;
            this.relatedParkingSpots = parkingSpots;
        }
    }
}
