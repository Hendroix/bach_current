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
        public static Random random;
        public static Random s_Random = new Random();

        public static int[] randomArray = new int[1000000], randomArray3 = new int[1000000];
        public static double[] randomArray2 = new double[1000000];
        public static int randomPointer = 1, randomPointer2 = 1, randomPointer3 = 1;

        public static Parkingspot inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet;

        public static int arrivingCars, maxParkingspots, freeSpaces, takenSpaces, totalAmountOfCars, currentSimTime, finalSimTime, counldtFindParking, delaySleepTime, currentlyMade;

        static void Main(string[] args)
        {

            //Trafic queues.
            //E6
            Queue e6Queue = new Queue();
            
            //Sykehusveien North
            Queue sykehusVeienQueueNorth = new Queue();
            Queue sykehusVeienQueueNorth_1 = new Queue();
            Queue sykehusVeienQueueNorth_2 = new Queue();
            Queue sykehusVeienQueueNorth_3 = new Queue();
            Queue sykehusVeienQueueNorth_4 = new Queue();
            //Sykehusveien South
            Queue sykehusVeienQueueSouth = new Queue();
            Queue sykehusVeienQueueSouth_1 = new Queue();
            Queue sykehusVeienQueueSouth_2 = new Queue();
            Queue sykehusVeienQueueSouth_3= new Queue();
            Queue sykehusVeienQueueSouth_4 = new Queue();

            //Tuneveien North
            Queue tuneVeienQueueNorth = new Queue();
            Queue tuneVeienQueueNorth_1 = new Queue();
            //Tuneveien South
            Queue tuneVeienQueueSouth = new Queue();
            Queue tuneVeienQueueSouth_1= new Queue();

            //Grålumveien North
            Queue grålumVeienQueueNorth = new Queue();
            Queue grålumVeienQueueNorth_1 = new Queue();
            //Grålumveien South
            Queue grålumVeienQueueSouth = new Queue();
            Queue grålumVeienQueueSouth_1 = new Queue();


            //Parkingspots that are avaliable to park on. There are some descrepencies here because we need more parkingspots to meet the 1200 cars that are arriving in this simulation.
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
            ParkingQueue e6South = new ParkingQueue("E6", e6Queue);
            ParkingQueue tuneVeienNorth = new ParkingQueue("TuneveienNorth", tuneVeienQueueNorth);
            ParkingQueue tuneVeienSouth = new ParkingQueue("TuneveienSouth", tuneVeienQueueSouth);
            ParkingQueue gralumVeienNorth = new ParkingQueue("GrålumveienNorth", grålumVeienQueueNorth);
            ParkingQueue gralumVeienSouth = new ParkingQueue("GrålumveienSouth", grålumVeienQueueSouth);
            ParkingQueue sykehusVeienNorth = new ParkingQueue("SykehusveienNorth", sykehusVeienQueueNorth);
            ParkingQueue sykehusVeienSouth = new ParkingQueue("SykehusveienSouth", sykehusVeienQueueSouth);
            
            Parkingspot[] parkingspotArray = { inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet };
            ParkingQueue[] parkingQueueArray = { e6South, tuneVeienNorth, gralumVeienNorth, sykehusVeienSouth };

            printTotalParkingInfo(parkingspotArray);

            //Defines the starting criterias
            currentSimTime = 1;
            finalSimTime = 1080;
            delaySleepTime = 10;
            currentlyMade = 0;

            generateRandomNumbers();
            //Start of While simulation loop
            while (currentSimTime <= finalSimTime)
            {

                //Intervall round 1
                if (currentSimTime <= 30)
                {
                    if (currentlyMade == 0)
                    {
                        if (totalAmountOfCars < 88)
                        {
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(2.93f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.8f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.58f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(2.15f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.22f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(2.25f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(1.36f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(1.58f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(6.89f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.7f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(1.41f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.18f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.20f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.11f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
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
                            Console.WriteLine("Round: " + currentSimTime + " Time: " + calculateTimeFromIntervals(currentSimTime));
                            int carsToBeMade = getArrivingCarsRandom(0.09f);
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArray);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
                        }
                    }
                }


                foreach (ParkingQueue pq in parkingQueueArray)
                {
                    if (pq.carsInQueue.Count > 0)
                    {
                        if (pq.name == "E6")
                        {
                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if (ps.name == "Kiwi")
                                {
                                    tuneVeienQueueSouth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra E6 til TuneveienSør");
                                }
                                if (ps.name == "Politihuset")
                                {
                                    grålumVeienQueueSouth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra E6 til GrålumveienSør");
                                }
                                else
                                {
                                    sykehusVeienQueueNorth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra E6 til SykehusveienNord");
                                }
                            }
                        }
                        if (pq.name == "SykehusveienNorth")
                        {
                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if (ps.name == "Inspiria")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på inspiria");
                                }
                                if (ps.name == "Quality")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Quality");
                                }
                                if(ps.name == "Inspiria Bak")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på inspiria bak");
                                }
                                if(ps.name == "Superland")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Superland");
                                }
                                if(ps.name == "Caverion")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Caverion");
                                }
                                if(ps.name == "K5")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på K5");
                                }
                                if(ps.name == "Adecco and If")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Adecco/If");
                                }
                                else
                                {
                                    sykehusVeienQueueSouth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra sykehusVeienNord til SykehusveienSør");
                                }

                            }

                        }
                        if (pq.name == "SykehusveienSouth")
                        {
                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if (ps.name == "Inspiria")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på inspiria");
                                }
                                if (ps.name == "Quality")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Quality");
                                }
                                if (ps.name == "Inspiria Bak")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på inspiria bak");
                                }
                                if (ps.name == "Superland")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Superland");
                                }
                                if (ps.name == "Caverion")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Caverion");
                                }
                                if (ps.name == "K5")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på K5");
                                }
                                if (ps.name == "Adecco and If")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Adecco/If");
                                }
                                if (ps.name == "Kiwi")
                                {
                                    tuneVeienQueueNorth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra sykehusVeiensør til TuneveienNord");
                                }
                                else
                                {
                                    grålumVeienQueueSouth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra sykehusVeiensør til GrålumVeienSør");
                                }

                            }
                        }
                        if (pq.name == "GrålumveienSouth")
                        {
                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if (ps.name == "Politihuset")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Politihuset");
                                }
                                if (ps.name == "Fagforbundet")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på fagforbundet");
                                }
                                if (ps.name == "Tune Senter")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Tune Senter");
                                }
                                else
                                {
                                    grålumVeienQueueNorth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra GrålumVeienSør til GrålumVeienNord");
                                }

                            }
                        }
                        if (pq.name == "GrålumveienNorth")
                        {
                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if (ps.name == "Politihuset")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Politihuset");
                                }
                                if (ps.name == "Fagforbundet")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på fagforbundet");
                                }
                                if (ps.name == "Tune Senter")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Tune Senter");
                                }
                                if (ps.name == "Kiwi")
                                {
                                    tuneVeienQueueSouth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra GrålumVeienNord til TuneveienSør");
                                }

                                else
                                {
                                    sykehusVeienQueueNorth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra GrålumVeienNord til SykehusveienNord");
                                }
                            }
                        }
                        if (pq.name == "TuneveienSouth")
                        {

                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if(ps.name == "Kiwi")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Kiwi");
                                }
                                else
                                {
                                    tuneVeienQueueNorth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra TuneveienSør til TuneveienNord");
                                }
                            }
                        }
                        if (pq.name == "TuneveienNorth")
                        {
                            Car c = (Car)pq.carsInQueue.Peek();
                            int cCreationTime = c.getTimeOfCreation();
                            if (cCreationTime < currentSimTime)
                            {
                                pq.carsInQueue.Dequeue();
                                c.setTimeofParking(currentSimTime);
                                Parkingspot ps = c.Destination;
                                if (ps.name == "Kiwi")
                                {
                                    ps.listOfCars.Add(c);
                                    Console.WriteLine("Bil " + c.id + "Har Parkert på Kiwi");
                                }
                                if(ps.name == "Politihuset" || ps.name == "Fagforbundet" || ps.name == "Tune Senter")
                                {
                                    grålumVeienQueueSouth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra tuneVeienSør til TuneveienSør");
                                }
                                else
                                {
                                    sykehusVeienQueueNorth.Enqueue(c);
                                    Console.WriteLine("Bil " + c.id + " Flyttet seg fra TuneveienNord til SykehusveienNord");
                                }
                            }
                        }
                    }

                }

                //End of while simulation loop
                currentSimTime++;
            }
            //Simulation ended
            printTotalParkingInfo(parkingspotArray);
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
                randomArray[i] = (int)getRandomNumber("int", 0,100);
            }
            for (int i = 0; i < randomArray2.Length; i++)
            {
                randomArray2[i] = getRandomNumber("double", 0, 100);
            }
            for (int i = 0; i < randomArray3.Length; i++)
            {
                randomArray3[i] = (int)getRandomNumber("int", 0,3);
            }

        }
        /// <summary>
        /// Gets the random number.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        static double getRandomNumber(string type, int min, int max)
        {
            if (type == "int")
            {
                int newRandom = s_Random.Next(min, max);
                return newRandom;

            }
            else
            {
                double newRandom = s_Random.Next(min, max);
                return newRandom;
            }
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
                Car car = new Car(randomPointer, inspiria, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: "  + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 12 && inspiriaBak.Free())
            {
                Car car = new Car(randomPointer, inspiriaBak, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 27 && superland.Free())
            {
                Car car = new Car(randomPointer, superland, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 42 && quality.Free())
            {
                Car car = new Car(randomPointer, quality, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 57 && kiwi.Free())
            {
                Car car = new Car(randomPointer, kiwi, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 69 && politi.Free())
            {
                Car car = new Car(randomPointer, politi, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 73 && caverion.Free())
            {
                Car car = new Car(randomPointer, caverion, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 76 && k5.Free())
            {
                Car car = new Car(randomPointer, k5, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 84 && tuneSenter.Free())
            {
                Car car = new Car(randomPointer, tuneSenter, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 92 && adeccoAndIf.Free())
            {
                Car car = new Car(randomPointer, adeccoAndIf, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else if (parkingChance <= 100 && fagforbundet.Free())
            {
                Car car = new Car(randomPointer, fagforbundet, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
            }
            else
            {
                if (inspiria.Free())
                {
                    Car car = new Car(randomPointer, inspiria, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (inspiriaBak.Free())
                {
                    Car car = new Car(randomPointer, inspiriaBak, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (superland.Free())
                {
                    Car car = new Car(randomPointer, superland, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (quality.Free())
                {
                    Car car = new Car(randomPointer, quality, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (kiwi.Free())
                {
                    Car car = new Car(randomPointer, kiwi, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (politi.Free())
                {
                    Car car = new Car(randomPointer, politi, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (caverion.Free())
                {
                    Car car = new Car(randomPointer, caverion, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (k5.Free())
                {
                    Car car = new Car(randomPointer, k5, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (tuneSenter.Free())
                {
                    Car car = new Car(randomPointer, tuneSenter, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (adeccoAndIf.Free())
                {
                    Car car = new Car(randomPointer, adeccoAndIf, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                }
                else if (fagforbundet.Free())
                {
                    Car car = new Car(randomPointer, fagforbundet, queuespot, currentSimTime);
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
        /// <summary>
        /// Gets the arriving cars random.
        /// </summary>
        /// <param name="chance">The chance.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Calculates the time from intervals.
        /// </summary>
        /// <param name="currentSimTime">The current sim time.</param>
        /// <returns></returns>
        private static string calculateTimeFromIntervals(int currentSimTime)
        {
            string timeString = "";
            int tmpTime = currentSimTime;
            if (currentSimTime < 360)
            {
                timeString += "07:";
                tmpTime = tmpTime / 6;
                if (tmpTime < 10)
                {
                    timeString += "0" + tmpTime;
                }
                else
                {
                    timeString += tmpTime;
                }
            }
            if (currentSimTime < 720 && currentSimTime >= 360)
            {
                timeString += "08:";
                tmpTime = (tmpTime - 360) / 6;
                if (tmpTime < 10)
                {
                    timeString += "0" + tmpTime;
                }
                else
                {
                    timeString += tmpTime;
                }

            }
            if (currentSimTime < 1080 && currentSimTime >= 720)
            {
                timeString += "09:";
                tmpTime = (tmpTime - 720) / 6;
                if (tmpTime < 10)
                {
                    timeString += "0" + tmpTime;
                }
                else
                {
                    timeString += tmpTime;
                }

            }
            if (currentSimTime == 1080)
            {
                timeString += "10:00";
            }
            return timeString;
        }
        /// <summary>
        /// Prints information about all the parkingspots you feed the method.
        /// </summary>
        /// <param name="array">The array of parkingspot you want stats printed from.</param>
        static void printTotalParkingInfo(Parkingspot[] array)
        {
            //Clearing the varaible before every print
            maxParkingspots = 0;
            takenSpaces = 0;
            freeSpaces = 0;

            Console.WriteLine();
            Console.WriteLine("Parkeringsplass oversikt:");
            foreach (Parkingspot p in array)
            {
                Console.WriteLine(p.name + ": " + p.listOfCars.Count + "/" + p.totalParkingSpaces);
                maxParkingspots += p.getTotalParkingSpaces();
                takenSpaces += p.getTakenSpaces();
            }
            Console.WriteLine();
            Console.WriteLine("Total oversikt:");
            Console.WriteLine("Totalt antall parkeringsplasser:          " + maxParkingspots);
            Console.WriteLine("Totalt antall opptatte parkeringsplasser: " + takenSpaces);
            Console.WriteLine("Totalt antall ledige parkeringsplasser:   " + (maxParkingspots - takenSpaces));
            Console.WriteLine();
        }
    }
}