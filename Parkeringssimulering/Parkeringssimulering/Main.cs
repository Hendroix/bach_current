using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    /// <summary>
    /// the Main main
    /// </summary>
    public class main
    {

        public static Random s_Random = new Random();
        public static int[] randomArray = new int[10000];
        /// <summary>
        /// The maximum cars 
        /// </summary>
        public static int maximumCars, arrivingCars, madeCar, finishParkedCars, maxParkingspots, freeSpaces, takenSpaces;
        /// <summary>
        /// The related parking spots tune veien north
        /// </summary>
        public static List<Parkingspot> relatedParkingSpotsTuneVeienNorth, relatedParkingSpotsTuneVeienSouth, relatedParkingSpotsGralumVeienNorth, relatedParkingSpotsGralumVeienSouth, relatedParkingSpotsE6South, relatedParkingSpotsSykehusVeienNorth, relatedParkingSpotsSykehusVeienSouth = new List<Parkingspot>();
        /// <summary>
        /// Array containing related road to their related roads.
        /// </summary>
        public static List<Queue> relatedRoadsTuneVeienNorth, relatedRoadsTuneVeienSouth, relatedRoadsGralumVeienNorth, relatedRoadsGralumVeienSouth, relatedRoadsE6South, relatedRoadsSykehusVeienNorth, relatedRoadsSykehusVeienSouth = new List<Queue>();
        /// <summary>
        /// The total parkingspots avaliable for all parkingspots.
        /// </summary>
        public static Parkingspot inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet;
        private static int counldtFindParking;
        public static Random random;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //defining the amount of cars that the simulation should manage.
            maximumCars = 1200;
            arrivingCars = 0;
            madeCar = 0;
            finishParkedCars = 830;

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
            inspiria = new Parkingspot("Inspiria", 125, 0);
            inspiriaBak = new Parkingspot("Inspiria Bak", 40, 0);
            superland = new Parkingspot("Superland", 200, 0);
            quality = new Parkingspot("Quality Hotell", 205, 0);
            kiwi = new Parkingspot("Kiwi", 210, 0);
            politi = new Parkingspot("Politihuset", 170, 0);
            caverion = new Parkingspot("Caverion", 45, 0);
            k5 = new Parkingspot("K5", 40, 0);
            tuneSenter = new Parkingspot("Tune Senter", 115, 0);
            adeccoAndIf = new Parkingspot("Adecco and If", 110, 0);
            fagforbundet = new Parkingspot("Fagforbundet", 110, 0);


            //Parking queues...
            ParkingQueue e6South = new ParkingQueue("E6", e6Queue, relatedRoadsE6South, relatedParkingSpotsE6South);
            ParkingQueue tuneVeienNorth = new ParkingQueue("Tuneveien", tuneVeienQueueNorth, relatedRoadsTuneVeienNorth, relatedParkingSpotsTuneVeienNorth);
            ParkingQueue tuneVeienSouth = new ParkingQueue("Tuneveien", tuneVeienQueueSouth, relatedRoadsTuneVeienSouth, relatedParkingSpotsTuneVeienSouth);
            ParkingQueue gralumVeienNorth = new ParkingQueue("Grålumveien", grålumVeienQueueNorth, relatedRoadsGralumVeienNorth, relatedParkingSpotsGralumVeienNorth);
            ParkingQueue gralumVeienSouth = new ParkingQueue("Grålumveien", grålumVeienQueueSouth, relatedRoadsGralumVeienSouth, relatedParkingSpotsGralumVeienSouth);
            ParkingQueue sykehusVeienNorth = new ParkingQueue("Sykehusveien", sykehusVeienQueueNorth, relatedRoadsSykehusVeienNorth, relatedParkingSpotsSykehusVeienNorth);
            ParkingQueue sykehusVeienSouth = new ParkingQueue("Sykehusveien", sykehusVeienQueueSouth, relatedRoadsSykehusVeienSouth, relatedParkingSpotsSykehusVeienSouth);

            Parkingspot[] parkingspotArray = { inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet };
            ParkingQueue[] parkingQueueArray = { e6South, tuneVeienNorth, gralumVeienNorth, sykehusVeienSouth };


            foreach (Parkingspot p in parkingspotArray)
            {
                maxParkingspots += p.getTotalParkingSpaces();
                freeSpaces += p.getFreeSpaces();
                takenSpaces += p.getTakenSpaces();
            }
            Console.WriteLine("Totalt antall parkeringsplasser:          " + maxParkingspots);
            Console.WriteLine("Totalt antall ledige parkeringsplasser:   " + freeSpaces);
            Console.WriteLine("Totalt antall opptatte parkeringsplasser: " + takenSpaces);

            madeCar = 0;
            int incommingCars = 1200;
            CalculateDestination(incommingCars, madeCar, parkingQueueArray);


            takenSpaces = 0;

            foreach (Parkingspot p in parkingspotArray)
            {
                Console.WriteLine(p.name + ": " + p.takenSpaces + "/" + p.totalParkingSpaces);
                takenSpaces += p.takenSpaces;
            }
            Console.WriteLine("Totalt antall parkeringsplasser:          " + maxParkingspots);
            Console.WriteLine("Totalt antall ledige parkeringsplasser:   " + (freeSpaces - takenSpaces));
            Console.WriteLine("Totalt antall opptatte parkeringsplasser: " + takenSpaces);


            Console.ReadKey();

        }
        public static void CalculateDestination(int traficAmount, int traficCounter, ParkingQueue[] parkingQueue)
        {
            generateRandomNumbers();
            Console.WriteLine("Calculating Desinations");
            while (traficAmount > madeCar)
            {
                
                makeCar(randomArray[madeCar], getQueue(parkingQueue));
            }
        }
        static void generateRandomNumbers()
        {
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = getRandomNumber();
            }
        }
        static int getRandomNumber()
        {
            int newRandom = s_Random.Next(0, 100);
            return newRandom;
        }
        private static void makeCar(int chance, ParkingQueue queuespot)
        {
            int parkingChance = chance;
            
            if (parkingChance <= 9 && inspiria.Free())
            {
                inspiria.addTakenSpaces();

                Car car = new Car(madeCar, inspiria, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: "  + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 12 && inspiriaBak.Free())
            {
                inspiriaBak.addTakenSpaces();
                Car car = new Car(madeCar, inspiriaBak, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 27 && superland.Free())
            {
                superland.addTakenSpaces();
                Car car = new Car(madeCar, superland, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 42 && quality.Free())
            {
                quality.addTakenSpaces();
                Car car = new Car(madeCar, quality, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 57 && kiwi.Free())
            {
                kiwi.addTakenSpaces();
                Car car = new Car(madeCar, kiwi, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 69 && politi.Free())
            {
                politi.addTakenSpaces();
                Car car = new Car(madeCar, politi, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 73 && caverion.Free())
            {
                caverion.addTakenSpaces();
                Car car = new Car(madeCar, caverion, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 76 && k5.Free())
            {
                k5.addTakenSpaces();
                Car car = new Car(madeCar, k5, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 84 && tuneSenter.Free())
            {
                tuneSenter.addTakenSpaces();
                Car car = new Car(madeCar, tuneSenter, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 92 && adeccoAndIf.Free())
            {
                adeccoAndIf.addTakenSpaces();
                Car car = new Car(madeCar, adeccoAndIf, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else if (parkingChance <= 100 && fagforbundet.Free())
            {
                fagforbundet.addTakenSpaces();
                Car car = new Car(madeCar, fagforbundet, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                madeCar++;
            }
            else
            {
                if (inspiria.Free())
                {
                    inspiria.addTakenSpaces();
                    Car car = new Car(madeCar, inspiria, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (inspiriaBak.Free())
                {
                    inspiriaBak.addTakenSpaces();
                    Car car = new Car(madeCar, inspiriaBak, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (superland.Free())
                {
                    superland.addTakenSpaces();
                    Car car = new Car(madeCar, superland, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (quality.Free())
                {
                    quality.addTakenSpaces();
                    Car car = new Car(madeCar, quality, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (kiwi.Free())
                {
                    kiwi.addTakenSpaces();
                    Car car = new Car(madeCar, kiwi, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (politi.Free())
                {
                    politi.addTakenSpaces();
                    Car car = new Car(madeCar, politi, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (caverion.Free())
                {
                    caverion.addTakenSpaces();
                    Car car = new Car(madeCar, caverion, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (k5.Free())
                {
                    k5.addTakenSpaces();
                    Car car = new Car(madeCar, k5, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (tuneSenter.Free())
                {
                    tuneSenter.addTakenSpaces();
                    Car car = new Car(madeCar, tuneSenter, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (adeccoAndIf.Free())
                {
                    adeccoAndIf.addTakenSpaces();
                    Car car = new Car(madeCar, adeccoAndIf, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else if (fagforbundet.Free())
                {
                    fagforbundet.addTakenSpaces();
                    Car car = new Car(madeCar, fagforbundet, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    madeCar++;
                }
                else
                {
                    counldtFindParking++;
                    madeCar++;
                }
            }
        }

        private static void placeInQueue(ParkingQueue queuespot, Car car) {
            queuespot.carsInQueue.Enqueue(car);
        }
        private static ParkingQueue getQueue(ParkingQueue[] parkingQueueArray)
        {
            random = new Random();
            int chance = random.Next(0, 3);
            ParkingQueue queuespot = parkingQueueArray[chance];
            return queuespot;

        }

    }
    //ArrayLists to connect Relations, setting.
    //Related parkingspots first in PRIORITIZED ORDER
    //Tune veien North and South

    /*
    relatedParkingSpotsTuneVeienNorth.Add(kiwi);
    relatedParkingSpotsTuneVeienSouth.Add(kiwi);

    //Gralumveien North and South
    relatedParkingSpotsGralumVeienNorth.Add(politi);
    relatedParkingSpotsGralumVeienNorth.Add(tuneSenter);
    relatedParkingSpotsGralumVeienNorth.Add(adeccoAndIf);
    relatedParkingSpotsGralumVeienNorth.Add(fagforbundet);
    relatedParkingSpotsGralumVeienSouth.Add(politi);
    relatedParkingSpotsGralumVeienSouth.Add(tuneSenter);
    relatedParkingSpotsGralumVeienSouth.Add(adeccoAndIf);
    relatedParkingSpotsGralumVeienSouth.Add(fagforbundet);

    //E6 South
    relatedParkingSpotsE6South.Add(null);

    //Sykehusveien North
    relatedParkingSpotsSykehusVeienNorth.Add(k5);
    relatedParkingSpotsSykehusVeienNorth.Add(politi);
    relatedParkingSpotsSykehusVeienNorth.Add(quality);
    relatedParkingSpotsSykehusVeienNorth.Add(inspiria);
    relatedParkingSpotsSykehusVeienNorth.Add(superland);
    relatedParkingSpotsSykehusVeienNorth.Add(tuneSenter);
    relatedParkingSpotsSykehusVeienNorth.Add(adeccoAndIf);
    relatedParkingSpotsSykehusVeienNorth.Add(inspiriaBak);
    relatedParkingSpotsSykehusVeienNorth.Add(fagforbundet);

    //Sykehusveien South
    relatedParkingSpotsSykehusVeienNorth.Add(k5);
    relatedParkingSpotsSykehusVeienNorth.Add(politi);
    relatedParkingSpotsSykehusVeienNorth.Add(quality);
    relatedParkingSpotsSykehusVeienNorth.Add(inspiria);
    relatedParkingSpotsSykehusVeienNorth.Add(superland);
    relatedParkingSpotsSykehusVeienNorth.Add(tuneSenter);
    relatedParkingSpotsSykehusVeienNorth.Add(adeccoAndIf);
    relatedParkingSpotsSykehusVeienNorth.Add(inspiriaBak);
    relatedParkingSpotsSykehusVeienNorth.Add(fagforbundet);

    //Other Queues
    //TuneVeienNorth
    relatedRoadsTuneVeienNorth.Add(tuneVeienQueueSouth);
    relatedRoadsTuneVeienNorth.Add(grålumVeienQueueSouth);
    relatedRoadsTuneVeienNorth.Add(sykehusVeienQueueNorth);
    //TuneVeienSouth
    relatedRoadsTuneVeienSouth.Add(tuneVeienQueueNorth);
    //GralumveienNorth
    relatedRoadsGralumVeienNorth.Add(tuneVeienQueueSouth);
    relatedRoadsGralumVeienNorth.Add(grålumVeienQueueSouth);
    relatedRoadsGralumVeienNorth.Add(sykehusVeienQueueNorth);
    //GralumVeienSouth
    relatedRoadsGralumVeienSouth.Add(grålumVeienQueueNorth);
    //E6South
    relatedRoadsE6South.Add(tuneVeienQueueSouth);
    relatedRoadsE6South.Add(grålumVeienQueueSouth);
    relatedRoadsE6South.Add(sykehusVeienQueueNorth);
    //SykehusVeienNorth
    relatedRoadsSykehusVeienNorth.Add(sykehusVeienQueueSouth);
    //SykehusVeienSouth
    relatedRoadsSykehusVeienSouth.Add(tuneVeienQueueSouth);
    relatedRoadsSykehusVeienSouth.Add(grålumVeienQueueSouth);
    relatedRoadsSykehusVeienSouth.Add(sykehusVeienQueueNorth);
    */
}