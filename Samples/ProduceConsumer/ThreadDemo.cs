/* ***********************************************
 * Author :  EASON
 * Email  :  wuyi@outlook.com
 * Function: 
 * history:  created by EASON 8/14/2013 10:47:32 PM
 * ***********************************************/

namespace ProduceConsumer
{
    using System;
    using System.Threading;

    public class ThreadDemo
    {
        public int QueueLength;

        public ThreadDemo()
        {
            QueueLength = 0;
        }

        public void Produce(TaskDemo ware)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Consume), ware);
            QueueLength++;
        }

        public void Consume(Object obj)
        {
            Console.WriteLine("Thread {0} consume {1}", Thread.CurrentThread.GetHashCode(), ((TaskDemo)obj).Id);
            Thread.Sleep(100);
            QueueLength--;
        }

        public  static  void Main(string[] args)
        {
            var demo = new ThreadDemo();
            for(var i = 0; i < 100; i++)
            {
                demo.Produce(new TaskDemo(i));
            }
            Console.WriteLine("Thread {0}", Thread.CurrentThread.GetHashCode());
            while(demo.QueueLength != 0)
            {
                Thread.Sleep(1000);
            }
            Console.Read();
        }
    }
}