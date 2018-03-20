using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    public class Car
    {
        public int id;
        public Parkeringspot Destination;
        public ParkingQueue arrivalFrom;
        public DateTime timeOfArrival;
        public DateTime timeOfParking;
        public int queueSpot;

        public Car(int id, Parkeringspot destination, ParkingQueue arrivalFrom, DateTime timeOfArrival, DateTime timeOfParking)
        {
            this.id = id;
            Destination = destination;
            this.arrivalFrom = arrivalFrom;
            this.timeOfArrival = timeOfArrival;
            this.timeOfParking = timeOfParking;
        }
    }
}
