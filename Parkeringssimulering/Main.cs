using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    public class main
    {

        static void Main(string[] args)
        {
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

            ParkingQueue tuneVeien = new ParkingQueue("Tuneveien", tuneVeienQueue, kiwi);
            ParkingQueue grålumVeien = new ParkingQueue("Grålumveien", grålumVeienQueue, politi);
            ParkingQueue e6 = new ParkingQueue("E6", e6Queue, quality);
            ParkingQueue sykehusVeien = new ParkingQueue("Sykehusveien", sykehusVeienQueue, k5);

            Car car1 = new Car(1, kiwi, tuneVeien, DateTime.Now, DateTime.Now, tuneVeienQueue.Count);
            Car car2 = new Car(2, politi, grålumVeien, DateTime.Now, DateTime.Now, grålumVeienQueue.Count);
            Car car3 = new Car(3, quality, e6, DateTime.Now, DateTime.Now, e6Queue.Count);

            tuneVeienQueue.Enqueue(car1);
            grålumVeienQueue.Enqueue(car2);
            e6Queue.Enqueue(car3);

            Console.WriteLine(tuneVeienQueue.Count);
            Console.WriteLine(grålumVeienQueue.Count);
            Console.WriteLine(e6Queue.Count);

            Console.ReadKey();

        }
    }
}
