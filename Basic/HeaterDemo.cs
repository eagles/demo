using System;

namespace Example.ProCSharp.Delegates
{
    public class Heater 
    {
        private int temperature;
        public void BoilWater() 
        {
            for (int i = 1; i <= 100; i++) 
            {
                temperature = i;
                if (temperature > 95 && BoilEvent != null) 
                {
                    //执行委托，无需知道要执行哪些方法
                    BoilEvent(temperature);
                }
            }
        }
        public delegate void BoilHandle(int param);
        public event BoilHandle BoilEvent;   //封装了委托
    }

    public class Alarm 
    {
        public void MakeAlert(int param) 
        {
            Console.WriteLine("Alarm: The temprature of water is over {0} Degree.", param);
        }
    }

    public class Display
    {
        public void ShowMsg(int param)
        {
            Console.WriteLine("Display:The water is boiled, current temprature is {0} degree.", param);
        }
    }

    public class entryMain
    {
        public static void Main()
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.BoilEvent += alarm.MakeAlert;
            heater.BoilEvent += new Display().ShowMsg;
            heater.BoilWater();
        }
    }
}