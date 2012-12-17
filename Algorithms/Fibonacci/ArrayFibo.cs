using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    public class ArrayFibo : IFibonacci
    {
        #region IFabonacci Members

        public int GetFibonacci(int n)
        {
            int i;
            int[] fib = new int[n + 1];
            fib[0]=0;
            fib[1]=1;
            for (i = 2; i < n + 1; i++)
                fib[i] = fib[i - 1] + fib[i - 2];

            return fib[n];
        }

        #endregion
    }
}
