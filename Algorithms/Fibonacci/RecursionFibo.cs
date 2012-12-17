using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    /// <summary>
    /// Use recursion to get fabonacci sequence number
    /// </summary>
    public class RecursionFibo: IFibonacci
    {
        #region IFibonacci Members

        public int GetFibonacci(int n)
        {
            if (n <= 0)
                return 0;
            if (n > 0 && n <= 2)
                return 1;
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        #endregion
    }
}
