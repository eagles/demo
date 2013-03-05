using System;

// http://www.codeproject.com/Articles/504572/A-Beginners-Tutorial-on-Basics-of-Delegates-Anonym

namespace BatteryDelegate
{
    public class BatteryLevel
    {
        int currentBatteryLevel;
        
        // This is the delgate type, this will specify the name of the delegate
        // and the function signature of the function that this delgaete can call
        public delegate void BatteryLevelBroadcaster(int batteryLevel);
        
        // This is the instance of out delegate type which will hold
        // list of functions to call too
        public BatteryLevelBroadcaster batteryLevelBroadcaster;
        
        public int CurrentBatteryLevel
        {
            get
            {
                return currentBatteryLevel;
            }
            set
            {
                 // Some process will call this setter to set the battery level
                currentBatteryLevel = value;
                
                //lets check whther someone has registered for listening or not
                if (batteryLevelBroadcaster != null)
                {
                    // Lets call all the functions with new battery level value
                    batteryLevelBroadcaster(currentBatteryLevel);
                }
            }
        }
        
        public static void BatteryLevelIndicator(int newValue)
        {
            Console.WriteLine("New battery level is: {0}", newValue);
        }
        
        public static void Main(string[] args)
        {
            // lets say we have a module that notifies the user with low battery
            // here we are emulating it.
            BatteryLevel batteryLevel = new BatteryLevel();
            
            // Delegate
            // Lets subscribe to the battery level delegate to know the current level
            // batteryLevel.batteryLevelBroadcaster += new BatteryLevel.BatteryLevelBroadcaster(BatteryLevelIndicator);
            
            // Anonymous Function
            // Here we have another module that is listening to the
            // battery level change but this time lets implement this using the
            // anonymous function
            //batteryLevel.batteryLevelBroadcaster += delegate(int newValue) 
            //                                        { 
            //                                            Console.WriteLine("(ANOMYMOUS)New battery level is: {0}", newValue);
            //                                        };
            
            // Lambda Expression
            // And finally there is the third approach where we can use Lambda expression
            // to subsribe to the delegates
            batteryLevel.batteryLevelBroadcaster += (newValue) => Console.WriteLine("(Lambda Expresson)New battery levle is: {0}", newValue);
            // ABOVE LINE WILL WORK ONLY IN VS2008 and above
            
            // Now let us simualte the hardware function that will set the battery level
            batteryLevel.CurrentBatteryLevel = 35;
            batteryLevel.CurrentBatteryLevel = 30;
            batteryLevel.CurrentBatteryLevel = 25;
            batteryLevel.CurrentBatteryLevel = 20;
            batteryLevel.CurrentBatteryLevel = 15;
            
            // Once the above code is run, for each updation we should get the
            // message written in our delgegate function
        }
    }
    
    /*
    To implement delegates and its handlers there are mainly 4 steps involved:
    1. Declaring the delegate
    2. Creating the delegate
    3. Hooking the delegate with handler functions
    4. Invoking the delegates
    */
    
    // [Access Modifier] delegate [Return type] [DELEGATE_NAME]([Function arguments]);
}

