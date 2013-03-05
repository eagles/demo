using System;

namespace Example.ProCSharp.Delegates
{
    //定义委托
    public delegate int MathHandle(int a, int b);

    public class Test
    {
        //定义事件
        public event MathHandle MathEvent;

        public int Add(int a, int b)
        {
            return a + b;
        }

        public void Operation(int a, int b)
        {
            Console.WriteLine(this.MathEvent(a, b));
        }
    }
    
    public class entryMain
    {
        public static void Main()
        {
            Test test = new Test();

            test.MathEvent += new MathHandle(test.Add);
            test.Operation(1, 2);
        }
    }
}