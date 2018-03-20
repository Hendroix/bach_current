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
        /// Array containing related road to their related roads.
        /// </summary>
        public static ArrayList relatedRoadsTuneVeienNorth, relatedRoadsTuneVeienSouth, relatedRoadsGralumVeienNorth, relatedRoadsGralumVeienSouth, relatedRoadsE6South, relatedRoadsSykehusVeienNorth, relatedRoadsSykehusVeienSouth = new ArrayList();

        /// <summary>
        /// The total parkingspots avaliable for all parkingspots.
        /// </summary>
        public static int totalParkingInspiria, totalParkingSuperland, totalParkingQuality, totalParkingKiwi, totalParkingPoliti, totalParkingCaverion, totalParkingK5;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //defining the amount of cars that the simulation should manage.
            maximumCars = 1200;
            arrivingCars = 0;
            //Defining the total parkingspots for each parkingzone
            totalParkingInspiria = 125;
            totalParkingSuperland = 150;
            totalParkingQuality = 115;
            totalParkingKiwi = 110;
            totalParkingPoliti = 85;
            totalParkingCaverion = 30;
            totalParkingK5 = 55;


            //Trafic queues.
            Queue e6Queue = new Queue();
            Queue tuneVeienQueueNorth = new Queue();
            Queue tuneVeienQueueSouth = new Queue();
            Queue grålumVeienQueueNorth = new Queue();
            Queue grålumVeienQueueSouth = new Queue();
            Queue sykehusVeienQueueNorth = new Queue();
            Queue sykehusVeienQueueSouth = new Queue();

            //Parkingspots that are avaliable to park on. There are some descrepencies here because we need more parkingspots to meet the 1200 cars that are arriving in this simulation.
            //Sondre are going to double check these numbers and update them to correct.
            Parkingspot inspiria = new Parkingspot("Inspiria", totalParkingInspiria, 0);
            Parkingspot superland = new Parkingspot("Superland", totalParkingSuperland, 0);
            Parkingspot quality = new Parkingspot("Quality Hotell", totalParkingQuality, 0);
            Parkingspot kiwi = new Parkingspot("Kiwi", totalParkingKiwi, 0);
            Parkingspot politi = new Parkingspot("Politihuset", totalParkingPoliti, 0);
            Parkingspot caverion = new Parkingspot("Caverion", totalParkingCaverion, 0);
            Parkingspot k5 = new Parkingspot("K5", totalParkingK5, 0);

            //ArrayLists to connect Relations, setting.
            //Related parkingspots first in PRIORITIZED ORDER
            //Tune veien North and South
            relatedParkingSpotsTuneVeienNorth.Add(kiwi);
            relatedParkingSpotsTuneVeienSouth.Add(kiwi);

            //Gralumveien North and South
            relatedParkingSpotsGralumVeienNorth.Add(politi);
            relatedParkingSpotsGralumVeienSouth.Add(politi);

            //E6 South
            relatedParkingSpotsE6South.Add(null);

            //Sykehusveien North
            relatedParkingSpotsSykehusVeienNorth.Add(k5);
            relatedParkingSpotsSykehusVeienNorth.Add(politi);
            relatedParkingSpotsSykehusVeienNorth.Add(quality);
            relatedParkingSpotsSykehusVeienNorth.Add(inspiria);

            //Sykehusveien South
            relatedParkingSpotsSykehusVeienSouth.Add(k5);
            relatedParkingSpotsSykehusVeienSouth.Add(politi);
            relatedParkingSpotsSykehusVeienSouth.Add(quality);
            relatedParkingSpotsSykehusVeienSouth.Add(inspiria);

            //Other Queues
            relatedRoadsTuneVeienNorth.Add(tuneVeienQueueSouth);
            relatedRoadsTuneVeienNorth.Add(grålumVeienQueueSouth);
            relatedRoadsTuneVeienNorth.Add(sykehusVeienQueueNorth);

            relatedRoadsTuneVeienSouth.Add(tuneVeienQueueNorth);

            relatedRoadsGralumVeienNorth.Add(tuneVeienQueueSouth);
            relatedRoadsGralumVeienNorth.Add(grålumVeienQueueSouth);
            relatedRoadsGralumVeienNorth.Add(sykehusVeienQueueNorth);


            relatedRoadsGralumVeienSouth.Add(grålumVeienQueueNorth);

            relatedRoadsE6South.Add(tuneVeienQueueSouth);
            relatedRoadsE6South.Add(grålumVeienQueueSouth);
            relatedRoadsE6South.Add(sykehusVeienQueueNorth);

            relatedRoadsSykehusVeienNorth.Add(sykehusVeienQueueSouth);

            relatedRoadsSykehusVeienSouth.Add(tuneVeienQueueSouth);
            relatedRoadsSykehusVeienSouth.Add(grålumVeienQueueSouth);
            relatedRoadsSykehusVeienSouth.Add(sykehusVeienQueueNorth);

            //Parking queues...
            ParkingQueue e6South = new ParkingQueue("E6", e6Queue, relatedRoadsE6South, relatedParkingSpotsE6South);
            ParkingQueue tuneVeienNorth = new ParkingQueue("Tuneveien", tuneVeienQueueNorth, relatedRoadsTuneVeienNorth, relatedParkingSpotsTuneVeienNorth);
            ParkingQueue tuneVeienSouth = new ParkingQueue("Tuneveien", tuneVeienQueueSouth, relatedRoadsTuneVeienSouth, relatedParkingSpotsTuneVeienSouth);
            ParkingQueue gralumVeienNorth = new ParkingQueue("Grålumveien", grålumVeienQueueNorth, relatedRoadsGralumVeienNorth, relatedParkingSpotsGralumVeienNorth);
            ParkingQueue gralumVeienSouth = new ParkingQueue("Grålumveien", grålumVeienQueueSouth, relatedRoadsGralumVeienSouth, relatedParkingSpotsGralumVeienSouth);
            ParkingQueue sykehusVeienNorth = new ParkingQueue("Sykehusveien", sykehusVeienQueueNorth, relatedRoadsSykehusVeienNorth, relatedParkingSpotsSykehusVeienNorth);
            ParkingQueue sykehusVeienSouth = new ParkingQueue("Sykehusveien", sykehusVeienQueueSouth, relatedRoadsSykehusVeienSouth, relatedParkingSpotsSykehusVeienSouth);



            while (arrivingCars <= maximumCars)
            {
                //Car car = new Car(arrivingCars, );
            }
        }

        /// <summary>
        /// Makes a new car.
        /// </summary>
        static void makeNewCar(int id, Parkingspot destination, ParkingQueue arrivalFrom)
        {
            Car car = new Car(id,destination, arrivalFrom);
        }
    }
}