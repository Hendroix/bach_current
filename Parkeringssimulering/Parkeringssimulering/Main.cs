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

        /// <summary>
        /// The s random
        /// </summary>
        public static Random s_Random = new Random();
        public static Random c_Random = new Random();
        /// <summary>
        /// The random array
        /// </summary>
        public static int[] randomArray = new int[1000000];
        public static double[] randomArray2 = new double[1000000];
        public static int[] randomArray3 = new int[1000000];
        public static int randomPointer = 1;
        public static int randomPointer2 = 1;
        public static int randomPointer3 = 1;
        /// <summary>
        /// The maximum cars
        /// </summary>
        public static int maximumCars, arrivingCars, madeCar, finishParkedCars, maxParkingspots, freeSpaces, takenSpaces, totalAmountOfCars;
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
        /// <summary>
        /// The counldt find parking
        /// </summary>
        private static int counldtFindParking;
        /// <summary>
        /// The random
        /// </summary>
        public static Random random;
        /// <summary>
        /// The current sim time
        /// </summary>
        public static int currentSimTime, finalSimTime;

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

            
            //Criterias for the simulation
            madeCar = 0;
            int incommingCars = 1200;
            //starts @ 0th time intervall
            currentSimTime = 1;
            //we have 1080 time intervalls, intervall tick every 10 sec, for 3 hours. 10 * 6 = 1 min * 60 = 1 hour * 3 = 3 Hour. 6 * 60 * 3 = 1080 intervalls.
            finalSimTime = 1080;
            generateRandomNumbers();
            while (currentSimTime <= finalSimTime)
            {
                int sleep = 1000;
                int currentlyMade = 0;

                //Intervall round 1
                if (currentSimTime <= 30)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 88)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(2.93f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 2
                 if (currentSimTime <= 90 && currentSimTime > 30)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 136)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.8f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 3
                 if (currentSimTime <= 114 && currentSimTime > 90)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 150)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.58f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 4
                 if (currentSimTime <= 180 && currentSimTime > 114)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 292)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(2.15f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 5
                 if (currentSimTime <= 234 && currentSimTime > 180)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 304)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.22f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 6
                 if (currentSimTime <= 270 && currentSimTime > 234)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 385)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(2.25f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 7
                 if (currentSimTime <= 312 && currentSimTime > 270)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 442)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(1.36f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 8
                 if (currentSimTime <= 336 && currentSimTime > 312)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 480)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(1.58f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 9
                 if (currentSimTime <= 390 && currentSimTime > 336)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 852)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(6.89f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 10
                 if (currentSimTime <= 450 && currentSimTime > 390)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 894)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.7f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 11
                 if (currentSimTime <= 540 && currentSimTime > 450)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 1021)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(1.41f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 12
                 if (currentSimTime <= 630 && currentSimTime > 540)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 1037)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.18f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 13
                 if (currentSimTime <= 786 && currentSimTime > 630)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 1068)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.20f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 14
                if (currentSimTime <= 900 && currentSimTime > 786)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 1080)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.11f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }

                //Intervall round 15
                if (currentSimTime <= 1080 && currentSimTime > 900)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 1096)
                        {
                            Console.WriteLine("Round: " + currentSimTime);
                            int carsToBeMade = getArrivingCarsRandom(0.09f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(sleep);
                        }
                    }
                }
                currentSimTime++;
            }
            takenSpaces = 0;
            freeSpaces = 0;



            foreach (Parkingspot p in parkingspotArray)
            {
                Console.WriteLine(p.name + ": " + p.takenSpaces + "/" + p.totalParkingSpaces);
                takenSpaces += p.takenSpaces;
                freeSpaces += p.getFreeSpaces();
            }

            Console.WriteLine("Totalt antall parkeringsplasser:          " + maxParkingspots);
            Console.WriteLine("Totalt antall ledige parkeringsplasser:   " + (freeSpaces));
            Console.WriteLine("Totalt antall opptatte parkeringsplasser: " + takenSpaces);
            Console.WriteLine("Biler som ikke fant parkeringsplass:      " + counldtFindParking);


            Console.ReadKey();

        }

        /// <summary>
        /// Creates and give purpose to the cars.
        /// </summary>
        /// <param name="wantedAmountOfCars">The wanted amount of cars.</param>
        /// <param name="alreadyMadeCars">The already made cars.</param>
        /// <param name="listOfParkingsSpots">The list of parkings spots.</param>
        public static void createAndGivePurposeToCars(int wantedAmountOfCars, int alreadyMadeCars, ParkingQueue[] listOfParkingsSpots)
        {
            while (wantedAmountOfCars > alreadyMadeCars)
            {
                makeCar(randomArray[randomPointer], getQueue(listOfParkingsSpots));
                alreadyMadeCars++;
                totalAmountOfCars++;
            }
        }
        /// <summary>
        /// Generates the random numbers.
        /// </summary>
        static void generateRandomNumbers()
        {
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = getRandomNumber();
            }
            for (int i = 0; i < randomArray2.Length; i++)
            {
                randomArray2[i] = getRandomNumberChance();
            }
            for (int i = 0; i < randomArray3.Length; i++)
            {
                randomArray3[i] = getRandomNumberParking();
            }

        }
        /// <summary>
        /// Gets the random number.
        /// </summary>
        /// <returns></returns>
        static int getRandomNumber()
        {
            int newRandom = s_Random.Next(0, 100);
            return newRandom;
        }
        static int getRandomNumberParking()
        {
            int newRandom = s_Random.Next(0, 3);
            return newRandom;
        }
        static double getRandomNumberChance()
        {
            double newRandom = c_Random.Next(0, 100);
            return newRandom;
        }
        /// <summary>
        /// Makes the car.
        /// </summary>
        /// <param name="chance">The chance.</param>
        /// <param name="queuespot">The queuespot.</param>
        private static void makeCar(int chance, ParkingQueue queuespot)
        {
            int parkingChance = chance;
            
            if (parkingChance <= 9 && inspiria.Free())
            {
                inspiria.addTakenSpaces();
                Car car = new Car(randomPointer, inspiria, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: "  + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 12 && inspiriaBak.Free())
            {
                inspiriaBak.addTakenSpaces();
                Car car = new Car(randomPointer, inspiriaBak, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 27 && superland.Free())
            {
                superland.addTakenSpaces();
                Car car = new Car(randomPointer, superland, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 42 && quality.Free())
            {
                quality.addTakenSpaces();
                Car car = new Car(randomPointer, quality, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 57 && kiwi.Free())
            {
                kiwi.addTakenSpaces();
                Car car = new Car(randomPointer, kiwi, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 69 && politi.Free())
            {
                politi.addTakenSpaces();
                Car car = new Car(randomPointer, politi, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 73 && caverion.Free())
            {
                caverion.addTakenSpaces();
                Car car = new Car(randomPointer, caverion, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 76 && k5.Free())
            {
                k5.addTakenSpaces();
                Car car = new Car(randomPointer, k5, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 84 && tuneSenter.Free())
            {
                tuneSenter.addTakenSpaces();
                Car car = new Car(randomPointer, tuneSenter, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 92 && adeccoAndIf.Free())
            {
                adeccoAndIf.addTakenSpaces();
                Car car = new Car(randomPointer, adeccoAndIf, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 100 && fagforbundet.Free())
            {
                fagforbundet.addTakenSpaces();
                Car car = new Car(randomPointer, fagforbundet, queuespot);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else
            {
                if (inspiria.Free())
                {
                    inspiria.addTakenSpaces();
                    Car car = new Car(randomPointer, inspiria, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (inspiriaBak.Free())
                {
                    inspiriaBak.addTakenSpaces();
                    Car car = new Car(randomPointer, inspiriaBak, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (superland.Free())
                {
                    superland.addTakenSpaces();
                    Car car = new Car(randomPointer, superland, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (quality.Free())
                {
                    quality.addTakenSpaces();
                    Car car = new Car(randomPointer, quality, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (kiwi.Free())
                {
                    kiwi.addTakenSpaces();
                    Car car = new Car(randomPointer, kiwi, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (politi.Free())
                {
                    politi.addTakenSpaces();
                    Car car = new Car(randomPointer, politi, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (caverion.Free())
                {
                    caverion.addTakenSpaces();
                    Car car = new Car(randomPointer, caverion, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (k5.Free())
                {
                    k5.addTakenSpaces();
                    Car car = new Car(randomPointer, k5, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (tuneSenter.Free())
                {
                    tuneSenter.addTakenSpaces();
                    Car car = new Car(randomPointer, tuneSenter, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (adeccoAndIf.Free())
                {
                    adeccoAndIf.addTakenSpaces();
                    Car car = new Car(randomPointer, adeccoAndIf, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (fagforbundet.Free())
                {
                    fagforbundet.addTakenSpaces();
                    Car car = new Car(randomPointer, fagforbundet, queuespot);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else
                {
                    counldtFindParking++;
                    randomPointer++;
                }
            }
        }
        /// <summary>
        /// Places the in queue.
        /// </summary>
        /// <param name="queuespot">The queuespot.</param>
        /// <param name="car">The car.</param>
        private static void placeInQueue(ParkingQueue queuespot, Car car)
        {
            queuespot.carsInQueue.Enqueue(car);
        }
        /// <summary>
        /// Gets the queue.
        /// </summary>
        /// <param name="parkingQueueArray">The parking queue array.</param>
        /// <returns></returns>
        private static ParkingQueue getQueue(ParkingQueue[] parkingQueueArray)
        {
            int chance = randomArray3[randomPointer3];
            randomPointer3++;
            ParkingQueue queuespot = parkingQueueArray[chance];
            return queuespot;
            
        }
        private static int getArrivingCarsRandom(double chance)
        {
            arrivingCars = 0;
            double c;
            bool hit = true;
            while (hit)
            {
                c = (randomArray2[randomPointer2] / 100);
                //Console.WriteLine("C: " + c + " <" + " Chance: " + chance);
                if (chance > 1.0f)
                {
                    arrivingCars++;
                    chance = (chance * 0.55f);
                }
                else if (c < chance && chance < 1.0f)
                {
                    arrivingCars++;
                    chance = (chance * 0.55f);
                    randomPointer2++;
                }
                else
                {
                    hit = false;
                }
                randomPointer2++;
            }
            return arrivingCars;
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