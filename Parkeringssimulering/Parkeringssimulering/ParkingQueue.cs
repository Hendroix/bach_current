using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    public class ParkingQueue
    {
        public String name;
        public Queue carsInQueue = new Queue();
        public ArrayList relatedRoads = new ArrayList();
        public ArrayList relatedParkingSpots = new ArrayList();

        public ParkingQueue(string name, Queue carsInQueue, ArrayList relatedRoads, ArrayList parkingSpots)
        {
            this.name = name;
            this.carsInQueue = carsInQueue;
            this.relatedRoads = relatedRoads;
            this.relatedParkingSpots = parkingSpots;
        }
    }
}
