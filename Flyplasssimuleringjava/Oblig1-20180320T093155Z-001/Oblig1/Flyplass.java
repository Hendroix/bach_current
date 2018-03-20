package fly;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Random;

public class Flyplass {
	public static void main (String[] args) throws InterruptedException{
		
		int planesCounter = 1;										
		//defines the id off the new planes to keep a hold of them
		int arrivedPlanes = 0;										
		//int to count the value of arrivedPlanes for statistics
		int departuresPlanes = 0;									
		//int to count the value of departuredPlanes for statistics
		int rejectedPlanesCounter = 0;								
		//int to count the amount of planes that gets rejected
		Double emptyIsAirport = 0.0;								
		//a double to track if the airport i empty needs to be double to convert to percent
		ArrayList<Fly> incomingPlanes = new ArrayList<Fly>();		
		//List of planes coming to the airport
		ArrayList<Fly> goingPlanes = new ArrayList<Fly>();			
		//List of planes going from the airport.
		goingPlanes.clear();										
		//Clearing the lists so that there are no elements stuck from previous simulations
		incomingPlanes.clear();										
		//Clearing the lists so that there are no elements stuck from previous simulations
		Double departedPlanesWaitTime = 0.0;						
		//tracks the wait time for the planes that have left
		Double landingPlanesWaitTime = 0.0;							
		//Tracks the wait time for the planes the have landed
		
		System.out.println("Enter the max number of Timeintervals(Have to be in format XX): ");
		Double maxFlightTime = getNumber(true);						
		//sets a double to the amount of times we want to simulate
		System.out.println("Enter the avg amount of planes arriving at the airport(Have to be in format X.X): ");
		Double avgArrivingPlanes = getNumber(true);					
		//defines the average amount of planes coming
		System.out.println("Enter the number of planes that are leaving the airport(Have to be in format X.X): ");
		Double avgDeparturePlanes = getNumber(true);				
		//defines the average amount of planes leaving
		System.out.println("if you want the simulation to be time delayed enter the time in millisec. if not den enter 0");
		Double timeInterval = getNumber(true);						
		//sets wheiter of not you want the simulation to be time delayed
		getNumber(false);											
		//Closes the stream
		
		System.out.println("Welcome to internatinal Airport, The International. Regional flights are not allowed." + "\n");
		System.out.println("How many simulation will be run ?            : " + maxFlightTime.intValue() + " Simulations");
		System.out.println("Expected amounts of arrivals pr. Timeunit ?  : " + avgArrivingPlanes);
		System.out.println("Expected amounts of departures pr. Timeunit ?: " + avgDeparturePlanes);
		
		//The main simulation that goes trough the preset amount of time. it also prints out the statistics at the end.
		for(int currentTime = 0 ; currentTime < maxFlightTime; currentTime++){
			Thread.sleep(timeInterval.longValue());
			int currentRound = currentTime + 1;													
			//Tracks the currentRound from 1-target instead of 0-target
			int arrivingToday = getPoissonRandom(avgArrivingPlanes);							
			//gets a random number for the daily arriving planes
			int departuresToday = getPoissonRandom(avgDeparturePlanes);							
			//gets a random number for the daily departing planes
			
			System.out.println("\n" + "Timeunit " + currentRound + ": ");
			
			if(arrivingToday > 0){																
				//Checks if the arriving number is greater than 0
				if(incomingPlanes.size() <= 10){												
					//airport can only handle 10 planes in q so we have to check for this
					for(int i = 0; i < arrivingToday; i++){										
						//loop that increases the counters and makes new planes.
						arrivedPlanes++;
						makePlanesNotWar(planesCounter, currentRound, incomingPlanes);
						planesCounter++;
					} 
			}
				else if(incomingPlanes.size() > 10){											
					//if the queue is full reject the plane
					rejectedPlanesCounter++;
				}
				System.out.print("Amount incoming: " + arrivingToday  + "\n");
			}
			
			if(departuresToday > 0){															
				//if there are departures today do following
				if(goingPlanes.size() <= 10){													
					//if the queue is smaller than 10 do the following
					for(int i = 0; i < departuresToday; i++){									
						//makes a plane and increased the counters
						departuresPlanes++;
						makePlanesNotWar(planesCounter, currentRound, goingPlanes);
						planesCounter++;
				}
			}
				else if(goingPlanes.size() > 10){												
					//if the queue is full increase the rejected planes counter
					rejectedPlanesCounter++;
				}
				System.out.print("Amount departing: " + departuresToday  + "\n");
			}
			
			//if the landing queue and the departure queue is empty in a time interval increase the value of emptyIsAirport.
			if(goingPlanes.isEmpty() && incomingPlanes.isEmpty()){
				emptyIsAirport++;
				System.out.println("No planes to see here"  + "\n");
			}
			
			//if there are  no planes wanting to land increase the counter for waittime and take out a plane
			if(incomingPlanes.isEmpty() == false){												
				String incoming = "landing";
				landingPlanesWaitTime = (landingPlanesWaitTime + removePlanesFromArray(incomingPlanes, currentRound, incoming));
			}
			else if(goingPlanes.isEmpty() == false){
				String going = "departing";
				departedPlanesWaitTime = (departedPlanesWaitTime + removePlanesFromArray(goingPlanes, currentRound, going));
			}
		}
		//Doubles doing functions for tracking stats
		Double percentEmptyAirport = ((emptyIsAirport / maxFlightTime) * 100);
		Double avgWaitTimeLanding = (calcAvgWaitTime(incomingPlanes, maxFlightTime.intValue(), arrivedPlanes, landingPlanesWaitTime));
		Double avgWaitTimeDeparting = (calcAvgWaitTime(goingPlanes, maxFlightTime.intValue(), departuresPlanes, departedPlanesWaitTime));
		
		//Prints
		System.out.print("\n");
		System.out.print("\n");
		System.out.println("Simulation finished after    : " + maxFlightTime.intValue() + " Timeunits.");
		System.out.println("Total amount managed         : " + (arrivedPlanes + departuresPlanes));
		System.out.println("Landed planes                : " + arrivedPlanes);
		System.out.println("Departed planes              : " + departuresPlanes);
		System.out.println("Rejected planes              : " + rejectedPlanesCounter);
		System.out.println("Planes ready for landing     : " + incomingPlanes.size());
		System.out.println("Planes ready for departures  : " + goingPlanes.size());
		System.out.println("Percentage Empty Airport     : " + percentEmptyAirport.intValue() + " %");
		System.out.println("Avg waiting time landing     : " + avgWaitTimeLanding + " Timeunits.");
		System.out.println("Avg waiting time departure   : " + avgWaitTimeDeparting + " Timeunits.");
	}
	//the function that gets our time interval from the user. During programming set to default of 20.
	public static Double getNumber(Boolean condition){
			Double number = 0.0;
	try{
			BufferedReader buffRead = new BufferedReader(new InputStreamReader(System.in));
			if(condition == true){
				String inputTime = buffRead.readLine();
				number = Double.parseDouble(inputTime);	
			}
			else if(condition == false){
			buffRead.close();
			}
		}
	catch(NumberFormatException ex){
			System.out.println("You have to type a number!");
			//getNumber();
			//ex.printStackTrace();
		}
	catch(Exception ex){
			//getNumber();
			System.out.println("Exception EX");
			ex.printStackTrace();
		}	
	return number;
	}
	//gets a random number with a avg of the double you input
	private static int getPoissonRandom(double mean){
		Random r = new Random();
		double L = Math.exp(-mean);
		int k = 0;
		double p = 1.0;
		do{
			p = p* r.nextDouble();
			k++;
		} while(p > L);
			return k - 1; 
	}
	//makes a new plane and adds it to the array
	private static void makePlanesNotWar(int id, int timeStamp, ArrayList<Fly> arr){
		Fly fly = new Fly(id, timeStamp);
		arr.add(fly);
	}
	//removed the first plane in the array, might have to add an int to return so we can track the departing and landing planes wait times.
	private static Double removePlanesFromArray(ArrayList<Fly> arr, int Timestamp, String DepArr){
		Double timeInQueue = 0.0;
		if(Timestamp > arr.get(0).getTimeStamp()){
			System.out.println(arr.get(0).toString() + " is " + DepArr);
			timeInQueue = (double) (Timestamp - arr.get(0).getTimeStamp());
			arr.remove(0);
		}
		return timeInQueue;
	}
	//Calculates the avg wait time for the arrays containing planes. need adjusting result is not as intended
	private static Double calcAvgWaitTime(ArrayList<Fly> arr1, int currentTime, int planesCounter, Double usedWaitTime){
		Double waitTimeCounter = 0.0;
		
		for (Fly fly : arr1) {															//Goes trough the array and sums the wait times
			int addedWaitTime = currentTime - fly.getTimeStamp();
			waitTimeCounter = waitTimeCounter + addedWaitTime;
		}
		
		waitTimeCounter = waitTimeCounter + usedWaitTime;
		Double planeSizes = (double) (arr1.size() + planesCounter);
		Double doubleWaitTimeCounter = (waitTimeCounter / planeSizes);
		
		return (doubleWaitTimeCounter);
	}
}
