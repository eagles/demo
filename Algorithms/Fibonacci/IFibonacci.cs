using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    /// <summary>
    /// Interface for fibonacci algorithm
    /// </summary>
    public interface IFibonacci
    {
        /// <summary>
        /// Get the first n fibonacci number's value.
        /// </summary>
        /// <param name="n">The sequence number</param>
        /// <returns>The specific number fibonacci value</returns>
        int GetFibonacci(int n);
    }
}
