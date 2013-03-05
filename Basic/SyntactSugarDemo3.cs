using System;
using System.Threading;

namespace Example.SyntactSugar
{
    internal sealed class AClass
    {
        public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
        {
            Int32[] squares = new Int32[numToDo];
            AutoResetEvent done = new AutoResetEvent(false);

            for (int i = 0; i < squares.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    obj => {
                        Int32 num = (Int32)obj;

                        //该任务通常比较耗时
                        squares[num] = num * num;

                        // 如果是最后一个任务，就让主线程继续运行
                        if (Interlocked.Decrement(ref numToDo) == 0)
                        {
                            done.Set();
                        }
                    },
                i);
            }

            //等待所有线程结束运行
            done.WaitOne();

            //显示结果
            for (int n = 0; n < squares.Length; n++)
            {
                Console.WriteLine("Index {0}, Square {1}", n, squares[n]);
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            AClass.UsingLocalVariablesInTheCallbackCode(100);
        }
    }
}