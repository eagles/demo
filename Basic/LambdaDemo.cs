using System;

namespace LambdaExample
{
    public class LambdaDemo
    {
        static void Main()
        {
            //The compiler cannot resolve this, which makes the usage of var impossible! Therefore we need to specify the type.
            //Action dummyLambda = () => { Console.WriteLine("Hallo World from a Lambda expression!"); };
            //dummyLambda();
            //Console.WriteLine();
            //
            ////Can be used as with double y = square(25);
            //Func<double, double> square = x => x * x;
            //Console.WriteLine(square(25));
            //Console.WriteLine();
            //
            ////Can be used as with double z = product(9, 5);
            //Func<double, double, double> product = (x, y) => x * y;
            //Console.WriteLine(product(9, 5));
            //Console.WriteLine();
            //
            ////Can be used as with printProduct(9, 5);
            //Action<double, double> printProduct = (x, y) => { Console.WriteLine(x * y); };
            //Console.WriteLine();
            //
            ////Can be used as with var sum = dotProduct(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 });
            //Func<double[], double[], double> dotProduct = (x, y) => {
            //    var dim = Math.Min(x.Length, y.Length);
            //    var sum = 0.0;
            //    for(var i = 0; i != dim; i++)   
            //        sum += x[i] + y[i];
            //    return sum;
            //};
            //
            //Console.WriteLine(dotProduct(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }));
            //Console.WriteLine();
            //
            ////Can be used as with var result = matrixVectorProductAsync(...);
            //Func<double[,], double[], Task<double[]>> matrixVectorProductAsync = async (x, y) => {
            //    var sum = 0.0;
            //    /* do some stuff using await ... */
            //    return sum;
            //};
            
            var a = 5;
            var multiplyWith = x => x * a;
            var result1 = multiplyWith(10); //50
            Console.WriteLine(result1);
            Console.WriteLine();
            
            a = 10;
            var result2 = multiplyWith(10); //100
            Console.WriteLine(result2);
            Console.WriteLine();
        }
    }
}