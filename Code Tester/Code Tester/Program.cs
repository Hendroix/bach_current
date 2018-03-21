using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Tester
{
    public class Program
    {
        public static float Inspiria, InspiriaBak, Superland, QualityHotell, Kiwi, Politihuset, Caverion, K5, TuneSenter, AdeccoOgIf, Fagforbundet;

        public static float totalParkingInspiria, totalParkingInspiriaBak, totalParkingSuperland, totalParkingQuality, totalParkingKiwi, totalParkingPoliti, totalParkingCaverion, totalParkingK5, totalParkingTuneSenter, totalParkingAdeccoAndIf, totalParkingFagforbundet;

        public static Random s_Random = new Random();

        public static int parkingChance, parkedCars, maxParkingSpots, counldtFindParking;
        public static int[] randomArray = new int[10000];

        public static void CalculateDestination()
        {
            generateRandomNumbers();

            while (maxParkingSpots > parkedCars)
            {
                makeAndParkCar(randomArray[parkedCars]);
            }
        }

        private static void makeAndParkCar(int chance)
        {
            parkingChance = chance;
            if (parkingChance <= 9 && Inspiria < totalParkingInspiria)
            {
                Inspiria++;
                parkedCars++;
            }
            else if (parkingChance <= 12 && InspiriaBak < totalParkingInspiriaBak)
            {
                InspiriaBak++;
                parkedCars++;
            }
            else if (parkingChance <= 27 && Superland < totalParkingSuperland)
            {
                Superland++;
                parkedCars++;
            }
            else if (parkingChance <= 42 && QualityHotell < totalParkingQuality)
            {
                QualityHotell++;
                parkedCars++;
            }
            else if (parkingChance <= 57 && Kiwi < totalParkingKiwi)
            {
                Kiwi++;
                parkedCars++;
            }
            else if (parkingChance <= 69 && Politihuset < totalParkingPoliti)
            {
                Politihuset++;
                parkedCars++;
            }
            else if (parkingChance <= 73 && Caverion < totalParkingCaverion)
            {
                Caverion++;
                parkedCars++;
            }
            else if (parkingChance <= 76 && K5 < totalParkingK5)
            {
                K5++;
                parkedCars++;
            }
            else if (parkingChance <= 84 && TuneSenter < totalParkingTuneSenter)
            {
                TuneSenter++;
                parkedCars++;
            }
            else if (parkingChance <= 92 && AdeccoOgIf < totalParkingAdeccoAndIf)
            {
                AdeccoOgIf++;
                parkedCars++;
            }
            else if (parkingChance <= 100 && Fagforbundet < totalParkingFagforbundet)
            {
                Fagforbundet++;
                parkedCars++;
            }
            else
            {
                if (Inspiria < totalParkingInspiria)
                {
                    Inspiria++;
                    parkedCars++;
                }
                else if (InspiriaBak < totalParkingInspiriaBak)
                {
                    InspiriaBak++;
                    parkedCars++;
                }
                else if (Superland < totalParkingSuperland)
                {
                    Superland++;
                    parkedCars++;
                }
                else if (QualityHotell < totalParkingQuality)
                {
                    QualityHotell++;
                    parkedCars++;
                }
                else if (Kiwi < totalParkingKiwi)
                {
                    Kiwi++;
                    parkedCars++;
                }
                else if (Politihuset < totalParkingPoliti)
                {
                    Politihuset++;
                    parkedCars++;
                }
                else if (Caverion < totalParkingCaverion)
                {
                    Caverion++;
                    parkedCars++;

                }
                else if (K5 < totalParkingK5)
                {
                    K5++;
                    parkedCars++;
                }
                else if (TuneSenter < totalParkingTuneSenter)
                {
                    TuneSenter++;
                    parkedCars++;
                }
                else if (AdeccoOgIf < totalParkingAdeccoAndIf)
                {
                    AdeccoOgIf++;
                    parkedCars++;
                }
                else if (Fagforbundet < totalParkingFagforbundet)
                {
                    Fagforbundet++;
                    parkedCars++;
                }
                else
                {
                    counldtFindParking++;
                }
            }
        }

        public static void PrintStats()
        {
            Console.WriteLine("Inspiria: " + Inspiria + "/" + totalParkingInspiria + " (" + (Inspiria / totalParkingInspiria * 100).ToString("N1") + "%)");
            Console.WriteLine("Inspiria Bak: " + InspiriaBak + "/" + totalParkingInspiriaBak + " (" + (InspiriaBak / totalParkingInspiriaBak * 100).ToString("N1") + "%)");
            Console.WriteLine("Superland: " + Superland + "/" + totalParkingSuperland + " (" + (Superland / totalParkingSuperland * 100).ToString("N1") + "%)");
            Console.WriteLine("Quality Hotell: " + QualityHotell + "/" + totalParkingQuality + " (" + (QualityHotell / totalParkingQuality * 100).ToString("N1") + "%)");
            Console.WriteLine("Kiwi: " + Kiwi + "/" + totalParkingKiwi + " (" + (Kiwi / totalParkingKiwi * 100).ToString("N1") + "%)");
            Console.WriteLine("Politi Huset: " + Politihuset + "/" + totalParkingPoliti + " (" + (Politihuset / totalParkingPoliti * 100).ToString("N1") + "%)");
            Console.WriteLine("Caverion: " + Caverion + "/" + totalParkingCaverion + " (" + (Caverion / totalParkingCaverion * 100).ToString("N1") + "%)");
            Console.WriteLine("K5: " + K5 + "/" + totalParkingK5 + " (" + (K5 / totalParkingK5 * 100).ToString("N1") + "%)");
            Console.WriteLine("Tune Senter: " + TuneSenter + "/" + totalParkingTuneSenter + " (" + (TuneSenter / totalParkingTuneSenter * 100).ToString("N1") + "%)");
            Console.WriteLine("Adecco: " + AdeccoOgIf + "/" + totalParkingAdeccoAndIf + " (" + (AdeccoOgIf / totalParkingAdeccoAndIf * 100).ToString("N1") + "%)");
            Console.WriteLine("Fagforbundet: " + Fagforbundet + "/" + totalParkingFagforbundet + " (" + (Fagforbundet / totalParkingFagforbundet * 100).ToString("N1") + "%)");
            Console.WriteLine("Fant ikke parkering: " + counldtFindParking);
            Console.WriteLine("total antall biler: " + parkedCars);
        }
        static void Main(string[] args)
        {
            totalParkingInspiria = 125;
            totalParkingInspiriaBak = 40;
            totalParkingSuperland = 200;
            totalParkingQuality = 205;
            totalParkingKiwi = 210;
            totalParkingPoliti = 170;
            totalParkingCaverion = 45;
            totalParkingK5 = 40;
            totalParkingTuneSenter = 115;
            totalParkingAdeccoAndIf = 110;
            totalParkingFagforbundet = 110;
            parkedCars = 0;
            counldtFindParking = 0;
            maxParkingSpots = 1370;
            CalculateDestination();

            PrintStats();
            Console.ReadKey();
        }
        static bool checkParkedCars()
        {
            if (parkedCars >= 1370)
            {
                return true;

            }
            return false;
        }
        static int getRandomNumber()
        {
            int newRandom = s_Random.Next(0, 100);
            return newRandom;
        }
        static void generateRandomNumbers()
        {
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = getRandomNumber();
            }
        }

    }
}

/*
public static void CalculateDestination()
        {

            perCent = s_Random.Next(0, 20);
            // for 3% og ned
            if (perCent <= 3 && perCent > 0)
            {
                if (K5 < totalParkingK5)
                    K5++;

                else
                {
                    CalculateDestination();
                }
            }
            // For 4 %
            else if (perCent >= 4 && perCent < 7)
            {
                perCent = s_Random.Next(0, 3);
                if (perCent == 1)
                {
                    if (InspiriaBak < totalParkingInspiriaBak)
                        InspiriaBak++;


                    else
                    {
                        CalculateDestination();
                    }
                }
                else
                {
                    if (Caverion < totalParkingCaverion)
                        Caverion++;

                    else
                    {
                        CalculateDestination();
                    }
                }

            }
            //Mellom 5% og 7%
            else if (perCent >= 7 && perCent < 9)
            {
                if (Inspiria < totalParkingInspiria)
                    Inspiria++;

                else
                {
                    CalculateDestination();
                }
            }
            //For 9%
            else if (perCent == 9)
            {
                perCent = s_Random.Next(0, 100);
                lostCars++;
                if (perCent < 33)
                {
                    if (TuneSenter < totalParkingTuneSenter)
                        TuneSenter++;

                    else
                    {
                        CalculateDestination();
                    }
                }
                else if(perCent > 33 && perCent <=66)
                {
                    if (AdeccoOgIf < totalParkingAdeccoAndIf)
                        AdeccoOgIf++;

                    else
                    {
                        CalculateDestination();
                    }
                }
                else
                {
                    if (Fagforbundet < totalParkingFagforbundet)
                        Fagforbundet++;

                    else
                    {
                        CalculateDestination();
                    }
                }

            }
            //For 10%
            else if (perCent >= 10 && perCent < 11)
            {
                if (Kiwi < totalParkingKiwi)
                    Kiwi++;

                else
                {
                    CalculateDestination();
                }
            }
            //Mellom 11 og 15%
            else if (perCent > 10 && perCent <= 15)
            {
                perCent = s_Random.Next(0, 2);
                if (perCent == 1)
                {
                    if (Superland < totalParkingSuperland)
                        Superland++;

                    else
                    {
                        CalculateDestination();
                    }
                }
                else
                {
                    if (QualityHotell < totalParkingQuality)
                        QualityHotell++;

                    else
                    {
                        CalculateDestination();
                    }
                }
            }
            //for 16%
            else if (perCent > 15)
            {
                if (Politihuset < totalParkingPoliti)
                    Politihuset++;

                else
                {
                    CalculateDestination();
                }
            }

        }
*/
