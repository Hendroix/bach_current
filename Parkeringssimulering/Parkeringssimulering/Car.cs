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
        public Parkingspot Destination;
        /// <summary>
        /// The arrival from
        /// </summary>
        public ParkingQueue arrivalFrom;
        /// <summary>
        /// The time of arrival
        /// </summary>
        public int timeOfQueuing;
        /// <summary>
        /// The time of parking
        /// </summary>
        public int timeOfParking;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="arrivalFrom">The arrival from.</param>
        public Car(int id, Parkingspot destination, ParkingQueue arrivalFrom)
        {
            this.id = id;
            Destination = destination;
            this.arrivalFrom = arrivalFrom;
            this.timeOfQueuing = 0;
        }
        /// <summary>
        /// Gets the time of parking.
        /// </summary>
        /// <returns></returns>
        public int getTimeOfParking()
        {
            return timeOfParking;
        }
        /// <summary>
        /// Adds the waiting time.
        /// </summary>
        /// <param name="time">The time.</param>
        public void addWaitingTime(int time)
        {
            this.timeOfParking += time;
        }

    }
}
