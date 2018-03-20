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
        public Parkeringspot goesToPark;

        public ParkingQueue(string name, Queue carsInQueue, Parkeringspot goesToPark)
        {
            this.name = name;
            this.carsInQueue = carsInQueue;
            this.goesToPark = goesToPark;
        }
    }
}
