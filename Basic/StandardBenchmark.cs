using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LambdaExample
{
    public class StandardBenchmark
    {
        const int LENGTH = 100000;
        static double[] A;
        static double[] B;
        
        static void Init()
        {
            var r = new Random();
            A = new double[LENGTH];
            B = new double[LENGTH];
            
            for (var i = 0; i < LENGTH; i++)
            {
                A[i] = r.NextDouble();
                B[i] = r.NextDouble();
            }
        }
        
        static long LambdaBenchmark()
        {
            Func<double> Perform = () =>
            {
                var sum = 0.0;
                
                for (var i = 0; i < LENGTH; i++)
                {
                    sum += A[i] + B[i];
                }
                return sum;
            };
            
            var iterations = new double[100];
            var timing = new Stopwatch();
            timing.Start();
            
            for (var j = 0; j < iterations.Length; j++)
            {
                iterations[j] = Perform();
            }
            
            timing.Stop();
            Console.WriteLine("Time for Lambda-Benchmark: \t {0}ms", timing.ElapsedMilliseconds);
            return timing.ElapsedMilliseconds;
        }
        
        static long NormalBenchmark()
        {
            var iterations = new double[100];
            var timing = new Stopwatch();
            timing.Start();
            
            for (var j = 0; j < iterations.Length; j++)
            {
                iterations[j] = NormalPerform();
            }
            
            timing.Stop();
            Console.WriteLine("Time for Normal-Benchmark: \t {0}ms", timing.ElapsedMilliseconds);
            return timing.ElapsedMilliseconds;
        }
        
        static double NormalPerform()
        {
            var sum = 0.0;
            
            for (var i = 0; i < LENGTH; i++)
            {
                sum += A[i] * B[i];
            }
            return sum;
        }
        
        static void Main()
        {
            Init();
            LambdaBenchmark();
            NormalBenchmark();
        }
    }
}