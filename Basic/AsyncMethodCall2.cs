using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Example.ProcessTest
{
    public class AsyncMethodCall2
    {
        // 异步调用执行完成同步信号
        static AutoResetEvent ev = new AutoResetEvent(false);
        
        // Define a simple add delegate
        public delegate int Deleg(int a, int b);
        
        public static int WriteSum(int a, int b)
        {
            Console.WriteLine("The ID of thread executing WriteSum is: {0}， Sum = {1}",
                Thread.CurrentThread.ManagedThreadId, (a + b));
            return a + b;
        }
        
        static void SumDone(IAsyncResult async)
        {
            //等待1秒，模拟线程正在执行其他工作
            Thread.Sleep(1000);

            //async中包装了异步方法执行的结果
            //从操作结果async中还原委托
            Deleg proc = ((AsyncResult)async).AsyncDelegate as Deleg;
            //获取异步方法的执行结果
            int sum = proc.EndInvoke(async);

            //显示结果
            Console.WriteLine("执行SumDone的线程ID为：{0}，Sum = {1}", Thread.CurrentThread.ManagedThreadId, sum);

            //使用AsnycState属性获取主线程中传入的同步信号
            //释放同步信号表示异步调用已完成
            ((AutoResetEvent)async.AsyncState).Set();
        }
        
        static void Main(string[] args)
        {
            //创建一个委托
            Deleg proc = new Deleg(WriteSum);

            //采用异步方式调用委托
            //指定SumDone为异步操作完成后的回调函数
            //指定ev为object参数，用于同步回调函数与主线程间操作
            IAsyncResult async = proc.BeginInvoke(10, 20, SumDone, ev);
            Console.WriteLine("主线程ID号为：{0}，异步操作已开始执行，正等待操作完成。", Thread.CurrentThread.ManagedThreadId);
            
            //等待异步操作完成
            ev.WaitOne();
            Console.WriteLine("异步操作已完成！");

            System.Console.ReadKey();
        }
    }
}