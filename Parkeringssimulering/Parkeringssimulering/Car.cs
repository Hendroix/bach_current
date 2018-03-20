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
    public class Car
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int id;
        /// <summary>
        /// The destination
        /// </summary>
        public Parkeringspot Destination;
        /// <summary>
        /// The arrival from
        /// </summary>
        public ParkingQueue arrivalFrom;
        /// <summary>
        /// The time of arrival
        /// </summary>
        public DateTime timeOfArrival;
        /// <summary>
        /// The time of parking
        /// </summary>
        public DateTime timeOfParking;
        /// <summary>
        /// The queue spot
        /// </summary>
        public int queueSpot;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="arrivalFrom">The arrival from.</param>
        /// <param name="timeOfArrival">The time of arrival.</param>
        /// <param name="timeOfParking">The time of parking.</param>
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
