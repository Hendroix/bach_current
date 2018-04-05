﻿using System;
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
        public static int Kiwi, Inspiria, InspiriaBak, Superland, Quality, Politi, Caverion, K5, TuneSenter, AdeccoAndIf, Fagforbundet;

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

            //Grålumveien North
            Queue grålumVeienQueueNorth = new Queue();
            Queue grålumVeienQueueNorth_1 = new Queue();

            //Parkingspots that are avaliable to park on. There are some descrepencies here because we need more parkingspots to meet the 1200 cars that are arriving in this simulation.
            inspiria = new Parkingspot("Inspiria", 150, 0);
            inspiriaBak = new Parkingspot("Inspiria Bak", 40, 0);
            superland = new Parkingspot("Superland", 175, 0);
            quality = new Parkingspot("Quality Hotell", 205, 0);
            kiwi = new Parkingspot("Kiwi", 210, 0);
            politi = new Parkingspot("Politihuset", 170, 0);
            caverion = new Parkingspot("Caverion", 45, 0);
            k5 = new Parkingspot("K5", 40, 0);
            tuneSenter = new Parkingspot("Tune Senter", 115, 0);
            adeccoAndIf = new Parkingspot("Adecco and If", 110, 0);
            fagforbundet = new Parkingspot("Fagforbundet", 110, 0);


            //Parking queues...
            //E6
            ParkingQueue e6South = new ParkingQueue("E6", e6Queue, 29);

            //Tuneveien North
            ParkingQueue tuneVeienNorth = new ParkingQueue("TuneveienNorth", tuneVeienQueueNorth, 29);
            ParkingQueue tuneVeienNorth_1 = new ParkingQueue("TuneveienNorth_1", tuneVeienQueueNorth_1, 29);
            //Tuneveien South
            ParkingQueue tuneVeienSouth = new ParkingQueue("TuneveienSouth", tuneVeienQueueSouth, 29);

            //Grålumveien North
            ParkingQueue gralumVeienNorth = new ParkingQueue("GrålumveienNorth", grålumVeienQueueNorth, 29);
            ParkingQueue gralumVeienNorth_1 = new ParkingQueue("GrålumveienNorth_1", grålumVeienQueueNorth_1, 29);

            //Sykehusveien North
            ParkingQueue sykehusVeienNorth = new ParkingQueue("SykehusveienNorth", sykehusVeienQueueNorth, 37);
            ParkingQueue sykehusVeienNorth_1 = new ParkingQueue("SykehusveienNorth_1", sykehusVeienQueueNorth_1, 14);
            ParkingQueue sykehusVeienNorth_2 = new ParkingQueue("SykehusveienNorth_2", sykehusVeienQueueNorth_2, 29);
            ParkingQueue sykehusVeienNorth_3 = new ParkingQueue("SykehusveienNorth_3", sykehusVeienQueueNorth_3, 29);
            ParkingQueue sykehusVeienNorth_4 = new ParkingQueue("SykehusveienNorth_4", sykehusVeienQueueNorth_4, 29);
            //Sykehusveien South
            ParkingQueue sykehusVeienSouth = new ParkingQueue("SykehusveienSouth", sykehusVeienQueueSouth, 29);
            ParkingQueue sykehusVeienSouth_1 = new ParkingQueue("SykehusveienSouth_1", sykehusVeienQueueSouth_1, 29);
            ParkingQueue sykehusVeienSouth_2 = new ParkingQueue("SykehusveienSouth_2", sykehusVeienQueueSouth_2, 29);
            ParkingQueue sykehusVeienSouth_3 = new ParkingQueue("SykehusveienSouth_3", sykehusVeienQueueSouth_3, 17);
            ParkingQueue sykehusVeienSouth_4 = new ParkingQueue("SykehusveienSouth_4", sykehusVeienQueueSouth_4, 37);


            Parkingspot[] parkingspotArray = { inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet };
            ParkingQueue[] parkingQueueArrayArrivingCars = { e6South, tuneVeienNorth, gralumVeienNorth, sykehusVeienSouth };
            ParkingQueue[] parkingQueueArrayCheck = { e6South, tuneVeienNorth, tuneVeienNorth_1, tuneVeienSouth, gralumVeienNorth, gralumVeienNorth_1,
                sykehusVeienNorth, sykehusVeienNorth_1, sykehusVeienNorth_2, sykehusVeienNorth_3, sykehusVeienNorth_4, sykehusVeienSouth, sykehusVeienSouth_1, sykehusVeienSouth_2,
                sykehusVeienSouth_3, sykehusVeienSouth_4 };

            printTotalParkingInfo(parkingspotArray);

            //Defines the starting criterias
            currentSimTime = 0;
            finalSimTime = 1080;
            delaySleepTime = 100;
            currentlyMade = 0;
            //Un comment this for a shit tun of cars to arrive
            totalAmountOfCars = -300;
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
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
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(delaySleepTime);
                        }
                    }
                }


                foreach (ParkingQueue pq in parkingQueueArrayCheck)
                {
                    //Fra E6
                    if (pq.name == e6South.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi/Tuneveien
                            if (ps.name == kiwi.name && tuneVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra E6 til " + tuneVeienSouth.name);
                            }
                            //all annen trafikk fra E6 skal til sykehusveien
                            else if(sykehusVeienNorth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra E6 til " + sykehusVeienNorth.name);
                            }
                        }
                    }
                    //Fra Tuneveien Sør
                    if (pq.name == tuneVeienSouth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi/Tuneveien
                            if (ps.name == kiwi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            else if (ps.name == kiwi.name && !ps.Free())
                            {
                                c.setDestination(quality);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            else if (tuneVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra TuneveienSør til " + tuneVeienNorth_1.name);
                            }
                        }
                    }
                    //Fra TuneveienNord
                    if (pq.name == tuneVeienNorth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi
                            if (ps.name == kiwi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            else if (ps.name == kiwi.name && !ps.Free())
                            {
                                c.setDestination(quality);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            else if (tuneVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra TuneveienNord til " + tuneVeienNorth_1.name);
                            }
                        }
                    }
                    //Fra TuneveienNord_1
                    if (pq.name == tuneVeienNorth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til SykehusveienNord
                            if (sykehusVeienNorth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + pq.name + " til " + sykehusVeienNorth.name);
                            }
                        }
                    }
                    //Fra grålumveien
                    if (pq.name == gralumVeienNorth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til grålumveienNord_1
                            if (gralumVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                gralumVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + gralumVeienNorth.name + " til " + gralumVeienNorth_1.name);
                            }
                        }
                    }
                    //Fra grålumveienNord_1
                    if (pq.name == gralumVeienNorth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi
                            if (ps.name == kiwi.name && tuneVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Til sykehusveien
                            else if (sykehusVeienNorth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + gralumVeienNorth_1.name + " til " + sykehusVeienNorth.name);
                            }
                        }
                    }
                    //Fra sykehusveienNord
                    if (pq.name == sykehusVeienNorth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Politihuset
                            if (ps.name == politi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om politiet er fullt
                            else if (ps.name == politi.name && !ps.Free())
                            {
                                c.setDestination(tuneSenter);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Quality
                            else if (ps.name == quality.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Quality er fullt
                            else if (ps.name == quality.name && !ps.Free())
                            {
                                c.setDestination(superland);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Superland
                            else if (ps.name == superland.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Superland er fult
                            else if (ps.name == superland.name && !ps.Free())
                            {
                                c.setDestination(inspiria);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination.name + "Men er fult, parkerer på " + c.Destination.name + " isteden.");
                            }
                            //Til If og Adecco
                            else if (ps.name == adeccoAndIf.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om if og Adecco er fullt
                            else if (ps.name == adeccoAndIf.name && !ps.Free())
                            {
                                c.setDestination(politi);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Tunesenteret
                            else if (ps.name == tuneSenter.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Tunesenteret er fullt
                            else if (ps.name == tuneSenter.name && !ps.Free())
                            {
                                c.setDestination(fagforbundet);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Fagforbundet
                            else if (ps.name == fagforbundet.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Fagforbundet er fullt
                            else if (ps.name == fagforbundet.name && !ps.Free())
                            {
                                c.setDestination(kiwi);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Send videre til SykehusveienNorth_1
                            else if (sykehusVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienNorth.name + " til " + sykehusVeienNorth_1.name);
                            }
                        }
                    }
                    //Fra sykehusveienNord_1
                    if (pq.name == sykehusVeienNorth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            pq.carsInQueue.Dequeue();
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria
                            if (ps.name == inspiria.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om inspiria er fullt
                            else if (ps.name == inspiria.name && !ps.Free())
                            {
                                c.setDestination(inspiriaBak);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Send videre til sykehusVeienNorth_2
                            else if (sykehusVeienNorth_2.checkIfFree() == true)
                            {
                                sykehusVeienNorth_2.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienNorth_1.name + " til " + sykehusVeienNorth_2.name);
                            }
                        }
                    }
                    //Fra SykehusveienNorth_2
                    if (pq.name == sykehusVeienNorth_2.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til sykehusveienNorth_3
                            if (sykehusVeienNorth_3.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_3.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienNorth_2.name + " til " + sykehusVeienNorth_3.name);
                            }
                        }
                    }
                    //Fra sykehusveienNord_3
                    if (pq.name == sykehusVeienNorth_3.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            pq.carsInQueue.Dequeue();
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria bak
                            if (ps.name == inspiriaBak.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om inspiria bak er fullt
                            else if (ps.name == inspiriaBak.name && !ps.Free())
                            {
                                c.setDestination(k5);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Caverion
                            else if (ps.name == caverion.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Caverion er fullt
                            else if (ps.name == caverion.name && !ps.Free())
                            {
                                c.setDestination(adeccoAndIf);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til k5
                            else if (ps.name == k5.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om k5 er fullt
                            else if (ps.name == k5.name && !ps.Free())
                            {
                                c.setDestination(caverion);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Send videre til sykehusveienNorth_4
                            else if (sykehusVeienNorth_4.checkIfFree() == true)
                            {
                                sykehusVeienNorth_4.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienNorth_3.name + " til " + sykehusVeienNorth_4.name);
                            }
                        }
                    }
                    //Fra sykehusveienNord_4
                    if (pq.name == sykehusVeienNorth_3.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            pq.carsInQueue.Dequeue();
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            if (sykehusVeienSouth.checkIfFree() == true)
                            {
                                sykehusVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienNorth_4.name + " til " + sykehusVeienSouth.name);
                            }
                        }
                    }
                    //Fra sykehusveienSør
                    if (pq.name == sykehusVeienSouth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            pq.carsInQueue.Dequeue();
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria bak
                            if (ps.name == inspiriaBak.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om inspiria bak er fullt
                            else if (ps.name == inspiriaBak.name && !ps.Free())
                            {
                                c.setDestination(k5);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Caverion
                            else if (ps.name == caverion.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om caverion er fullt
                            else if (ps.name == caverion.name && !ps.Free())
                            {
                                c.setDestination(adeccoAndIf);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til k5
                            else if (ps.name == k5.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om k5 er fullt
                            else if (ps.name == inspiriaBak.name && !ps.Free())
                            {
                                c.setDestination(caverion);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Send videre til sykehusveienSouth_1
                            else if (sykehusVeienSouth_1.checkIfFree() == true)
                            {
                                sykehusVeienSouth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienSouth.name + " til " + sykehusVeienSouth_1.name);
                            }
                        }
                    }
                    //Fra sykehusveienSør1
                    if (pq.name == sykehusVeienSouth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            pq.carsInQueue.Dequeue();
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            if (sykehusVeienSouth_2.checkIfFree() == true)
                            {
                                sykehusVeienSouth_2.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienSouth_1.name + " til " + sykehusVeienSouth_2.name);
                            }

                        }
                    }
                    //Fra sykehusveienSær_2
                    if (pq.name == sykehusVeienSouth_2.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            pq.carsInQueue.Dequeue();
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria
                            if (ps.name == inspiria.name && ps.Free())
                            {
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om inspiria er fullt
                            else if (ps.name == inspiria.name && !ps.Free())
                            {
                                c.setDestination(quality);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Send videre til sykehusveienSouth_3
                            else if (sykehusVeienSouth_3.checkIfFree() == true)
                            {
                                sykehusVeienSouth_3.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienSouth_2.name + " til " + sykehusVeienSouth_3.name);
                            }
                        }
                    }
                    //Fra sykehusveienSouth_3
                    if (pq.name == sykehusVeienSouth_3.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Politihuset
                            if (ps.name == politi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om politiet er fullt
                            else if (ps.name == politi.name && !ps.Free())
                            {
                                c.setDestination(tuneSenter);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Quality
                            else if (ps.name == quality.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Quality er fullt
                            else if (ps.name == quality.name && !ps.Free())
                            {
                                c.setDestination(superland);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Superland
                            else if (ps.name == superland.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Superland er fult
                            else if (ps.name == superland.name && !ps.Free())
                            {
                                c.setDestination(inspiria);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination.name + "Men er fult, parkerer på " + c.Destination.name + " isteden.");
                            }
                            //Til If og Adecco
                            else if (ps.name == adeccoAndIf.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om if og Adecco er fullt
                            else if (ps.name == adeccoAndIf.name && !ps.Free())
                            {
                                c.setDestination(politi);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Tunesenteret
                            else if (ps.name == tuneSenter.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Tunesenteret er fullt
                            else if (ps.name == tuneSenter.name && !ps.Free())
                            {
                                c.setDestination(fagforbundet);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Til Fagforbundet
                            else if (ps.name == fagforbundet.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                Console.WriteLine("Bil " + c.id + " Har parkert på " + ps.name + ", her er det " + ps.getTakenSpaces() + "/" + ps.totalParkingSpaces);
                            }
                            //Om Fagforbundet er fullt
                            else if (ps.name == fagforbundet.name && !ps.Free())
                            {
                                c.setDestination(kiwi);
                                Console.WriteLine(c.id + " Skal til ->" + c.originalDestination + "Men er fult, parkerer på " + c.Destination + " isteden.");
                            }
                            //Send videre til sykehusveienSouth_4
                            else if (sykehusVeienSouth_4.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_4.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra " + sykehusVeienNorth_3.name + " til " + sykehusVeienNorth_4.name);
                            }
                        }
                    }
                    //Fra sykehusveienSør_4
                    if (pq.name == sykehusVeienSouth_4.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi/Tuneveien
                            if (ps.name == kiwi.name && tuneVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                Console.WriteLine("Bil " + c.id + " Flyttet seg fra E6 til " + tuneVeienSouth.name);
                            }
                        }
                    }

                }

                //End of while simulation loop
                currentSimTime++;
            }
            //Simulation ended
            printTotalParkingInfo(parkingspotArray);
            printRemainingCarsInQueue(parkingQueueArrayCheck);

            Console.ReadKey();

        }
        /// <summary>
        /// Creates and give purpose to the cars.
        /// </summary>
        /// <param name="wantedAmountOfCars">The wanted amount of cars.</param>
        /// <param name="alreadyMadeCars">The already made cars.</param>
        /// <param name="listOfParkingsSpots">The list of parkings spots.</param>
        public static void createAndGivePurposeToCars(int wantedAmountOfCars, int alreadyMadeCars, ParkingQueue[] listOfParkingsQueues)
        {
            while (wantedAmountOfCars > alreadyMadeCars)
            {
                makeCar(randomArray[randomPointer], getQueue(listOfParkingsQueues));
                alreadyMadeCars++;
                totalAmountOfCars++;
            }
        }
        /// <summary>
        /// Generates the random numbers.
        /// </summary>
        static void generateRandomNumbers()
        {
            System.Threading.Thread.Sleep(100);
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = (int)getRandomNumber("int", 0,100);
            }
            System.Threading.Thread.Sleep(100);
            for (int i = 0; i < randomArray2.Length; i++)
            {
                randomArray2[i] = getRandomNumber("double", 0, 100);
            }
            System.Threading.Thread.Sleep(100);
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
                Inspiria++;
            }
            else if (parkingChance <= 12 && inspiriaBak.Free())
            {
                Car car = new Car(randomPointer, inspiriaBak, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                InspiriaBak++;
            }
            else if (parkingChance <= 27 && superland.Free())
            {
                Car car = new Car(randomPointer, superland, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                Superland++;
            }
            else if (parkingChance <= 42 && quality.Free())
            {
                Car car = new Car(randomPointer, quality, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                Quality++;
            }
            else if (parkingChance <= 57 && kiwi.Free())
            {
                Car car = new Car(randomPointer, kiwi, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                Kiwi++;
            }
            else if (parkingChance <= 69 && politi.Free())
            {
                Car car = new Car(randomPointer, politi, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                Politi++;
            }
            else if (parkingChance <= 73 && caverion.Free())
            {
                Car car = new Car(randomPointer, caverion, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                Caverion++;
            }
            else if (parkingChance <= 76 && k5.Free())
            {
                Car car = new Car(randomPointer, k5, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                K5++;
            }
            else if (parkingChance <= 84 && tuneSenter.Free())
            {
                Car car = new Car(randomPointer, tuneSenter, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                TuneSenter++;
            }
            else if (parkingChance <= 92 && adeccoAndIf.Free())
            {
                Car car = new Car(randomPointer, adeccoAndIf, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                AdeccoAndIf++;
            }
            else if (parkingChance <= 100 && fagforbundet.Free())
            {
                Car car = new Car(randomPointer, fagforbundet, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                randomPointer++;
                Fagforbundet++;
            }
            else
            {
                if (inspiria.Free())
                {
                    Car car = new Car(randomPointer, inspiria, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Inspiria++;
                }
                else if (inspiriaBak.Free())
                {
                    Car car = new Car(randomPointer, inspiriaBak, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    InspiriaBak++;
                }
                else if (superland.Free())
                {
                    Car car = new Car(randomPointer, superland, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Superland++;
                }
                else if (quality.Free())
                {
                    Car car = new Car(randomPointer, quality, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + queuespot.carsInQueue.Count + " " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Quality++;
                }
                else if (kiwi.Free())
                {
                    Car car = new Car(randomPointer, kiwi, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Kiwi++;
                }
                else if (politi.Free())
                {
                    Car car = new Car(randomPointer, politi, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Politi++;
                }
                else if (caverion.Free())
                {
                    Car car = new Car(randomPointer, caverion, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Caverion++;
                }
                else if (k5.Free())
                {
                    Car car = new Car(randomPointer, k5, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    K5++;
                }
                else if (tuneSenter.Free())
                {
                    Car car = new Car(randomPointer, tuneSenter, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    TuneSenter++;
                }
                else if (adeccoAndIf.Free())
                {
                    Car car = new Car(randomPointer, adeccoAndIf, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    AdeccoAndIf++;
                }
                else if (fagforbundet.Free())
                {
                    Car car = new Car(randomPointer, fagforbundet, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    Console.WriteLine(queuespot.name + ": " + "Car: " + car.id + " " + car.Destination.name);
                    randomPointer++;
                    Fagforbundet++;
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
            double luckyShot = 0.9f;
            while (hit)
            {
                c = (randomArray2[randomPointer2] / 100);
                //Console.WriteLine("C: " + c + " <" + " Chance: " + chance);
                if (chance > 1.0f)
                {
                    arrivingCars++;
                    chance = (chance * luckyShot);
                }
                else if (c < chance && chance <= 1.0f)
                {
                    arrivingCars++;
                    chance = (chance * luckyShot);
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
                if (p.listOfCars.Count > p.totalParkingSpaces)
                {
                    Console.WriteLine(p.name + ": " + p.listOfCars.Count + "/" + p.totalParkingSpaces + " TO MANY CARS");
                }
                else
                {
                    Console.WriteLine(p.name + ": " + p.listOfCars.Count + "/" + p.totalParkingSpaces);
                }
                maxParkingspots += p.getTotalParkingSpaces();
                takenSpaces += p.getTakenSpaces();
            }
            Console.WriteLine();
            Console.WriteLine("Total oversikt:");
            Console.WriteLine("Totalt antall parkeringsplasser:          " + maxParkingspots);
            Console.WriteLine("Totalt antall opptatte parkeringsplasser: " + takenSpaces);
            Console.WriteLine("Totalt antall ledige parkeringsplasser:   " + (maxParkingspots - takenSpaces));
            Console.WriteLine("Total cars made: " + totalAmountOfCars);
            Console.WriteLine();
        }
        static void printRemainingCarsInQueue(ParkingQueue[] pq)
        {
            foreach (ParkingQueue queue in pq)
            {
                Console.WriteLine(queue.name + "  Biler i min kø: " + queue.carsInQueue.Count);
                if (queue.carsInQueue.Count > 0)
                {
                    foreach (Car c in queue.carsInQueue)
                    {
                        Console.WriteLine("Car: " + c.id + " Destination: " + c.Destination.name);
                    }
                }
            }

        }
    }
}