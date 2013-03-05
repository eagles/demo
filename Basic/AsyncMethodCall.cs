using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Example.ProcessTest
{
    /*
     * 当一个事件被触发时，订阅该事件的方法将在触发该事件的线程中执行。也就是说，订阅该事件的方法在触发事件的线程中同步执行。
     * 由此，存在一个问题：如果订阅事件的方法执行时间很长，触发事件的线程被阻塞，长时间等待方法执行完毕。这样，不仅影响后续
     * 订阅事件方法的执行，也影响主线程及时响应用户的其他请求。如何处理这个问题呢？讲到此，我想您已经想到了，那就是异步事件调用。
     * 怎样实现异步事件调用呢？如果您对事件比较了解的话，您应该知道事件的本质其实是一种MulticastDelegate（多播委托）。
     * MulticastDelegate类提供了一个GetInvocationList方法，该方法返回此多播委托的委托调用数组。利用该方法就能实现我们的异步事件调用功能。
     */
　　
    public class AsyncMethodCall
    {
        // Define an event 
        public static event EventHandler<EventArgs> OnEvent;
        
        // Method 1
        public void Method1(object sender, EventArgs e)
        {
            Console.WriteLine("The thread name calling Method 1 is {0}",
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }
        
        // Method2
        public void Method2(object sender, EventArgs e)
        {
            Console.WriteLine("The thread name calling Method 2 is {0}",
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }
        
        static void Main(string[] args)
        {
            AsyncMethodCall test = new AsyncMethodCall();
            
            // Show the main thread id
            Console.WriteLine("The main thread is: {0}", Thread.CurrentThread.ManagedThreadId);
            // Register Method1 and Method2 into event
            OnEvent += new EventHandler<EventArgs>(test.Method1);
            OnEvent += new EventHandler<EventArgs>(test.Method2);
            
            // Call event handler methods asynchronize
            
            //Get the multicase delegates of event
            Delegate[] delegAry = OnEvent.GetInvocationList();
            
            //loop the delegates list
            foreach(EventHandler<EventArgs> deleg in delegAry)
            {
                deleg.BeginInvoke(null, EventArgs.Empty, null, null);
            }
            
            OnEvent -= new EventHandler<EventArgs>(test.Method1);
            OnEvent -= new EventHandler<EventArgs>(test.Method2);
            
            Console.ReadKey();
        }
    }
}