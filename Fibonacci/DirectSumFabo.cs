using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    public class DirectSumFabo : IFibonacci
    {
        #region IFibonacci Members

        public int GetFibonacci(int n)
        {
            int n1 = 1;
            int n2 = 1;
            int sum = 0;
            if (0>=n && n <= 2)
            {
                sum = 1;
            }
            else
            {
                for (int i = 3; i <= n; i++)
                {
                    sum = n1 + n2;
                    n1 = n2;
                    n2 = sum;
                }
            }
            return sum;
        }

        #endregion
    }
}
