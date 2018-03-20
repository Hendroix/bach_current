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
    public class main
    {
        /// <summary>
        /// The maximum cars
        /// </summary>
        public static int maximumCars, arrivingCars;
        /// <summary>
        /// The related parking spots tune veien north
        /// </summary>
        public static ArrayList relatedParkingSpotsTuneVeienNorth, relatedParkingSpotsTuneVeienSouth, relatedParkingSpotsGralumVeienNorth, relatedParkingSpotsGralumVeienSouth, relatedParkingSpotsE6South, relatedParkingSpotsSykehusVeienNorth, relatedParkingSpotsSykehusVeienSouth = new ArrayList();
        /// <summary>
        /// The related roads tune veien north
        /// </summary>
        public static ArrayList relatedRoadsTuneVeienNorth, relatedRoadsTuneVeienSouth, relatedRoadsGralumVeienNorth, relatedRoadsGralumVeienSouth, relatedRoadsE6South, relatedRoadsSykehusVeienNorth, relatedRoadsSykehusVeienSouth = new ArrayList();

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            maximumCars = 1200;
            arrivingCars = 0;


            Queue tuneVeienQueue = new Queue();
            Queue grålumVeienQueue = new Queue();
            Queue e6Queue = new Queue();
            Queue sykehusVeienQueue = new Queue();

            Parkeringspot inspiria = new Parkeringspot("Inspiria", 125, 125, 0);
            Parkeringspot superland = new Parkeringspot("Superland", 150, 150, 0);
            Parkeringspot quality = new Parkeringspot("Quality Hotell", 115, 115, 0);
            Parkeringspot kiwi = new Parkeringspot("Kiwi", 110, 110, 0);
            Parkeringspot politi = new Parkeringspot("Politihuset", 85, 85, 0);
            Parkeringspot caverion = new Parkeringspot("Caverion", 30, 30, 0);
            Parkeringspot k5 = new Parkeringspot("K5", 55, 55, 0);

            ParkingQueue e6South = new ParkingQueue("E6", e6Queue, relatedRoadsE6South, relatedParkingSpotsE6South);
            ParkingQueue tuneVeienNorth = new ParkingQueue("Tuneveien", tuneVeienQueue, relatedRoadsTuneVeienNorth, relatedParkingSpotsTuneVeienNorth);
            ParkingQueue tuneVeienSouth = new ParkingQueue("Tuneveien", tuneVeienQueue, relatedRoadsTuneVeienSouth, relatedParkingSpotsTuneVeienSouth);
            ParkingQueue gralumVeienNorth = new ParkingQueue("Grålumveien", grålumVeienQueue, relatedRoadsGralumVeienNorth, relatedParkingSpotsGralumVeienNorth);
            ParkingQueue gralumVeienSouth = new ParkingQueue("Grålumveien", grålumVeienQueue, relatedRoadsGralumVeienSouth, relatedParkingSpotsGralumVeienSouth);
            ParkingQueue sykehusVeienNorth = new ParkingQueue("Sykehusveien", sykehusVeienQueue, relatedRoadsSykehusVeienNorth, relatedParkingSpotsSykehusVeienNorth);
            ParkingQueue sykehusVeienSouth = new ParkingQueue("Sykehusveien", sykehusVeienQueue, relatedRoadsSykehusVeienSouth, relatedParkingSpotsSykehusVeienSouth);



            while (arrivingCars <= maximumCars)
            {
                //Car car = new Car(arrivingCars, );
            }
        }

        /// <summary>
        /// Makes a new car.
        /// </summary>
        static void makeNewCar()
        {

        }
    }
}