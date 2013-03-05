using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net
{
    public abstract class Animal
    {
    }

    public class Dog : Animal
    {
    }

    public class Test
    {
        //public static void Main()
        //{
        //    Dog aDog = new Dog();
        //    Animal aAnimal = aDog;

        //    List<Dog> dogs = new List<Dog>();

        //    // Following conversion will fail with
        //    // VariantExample.cs(22,36): error CS0029: Cannot implicitly convert type
        //    // 'System.Collections.Generic.List<VariantExample.Dog>' to
        //    // 'System.Collections.Generic.List<VariantExample.Animal>'
        //    // List<Animal> animals = dogs;

        //    // But we could convert a List through following way
        //    List<Animal> animals = dogs.Select(d => (Animal)d).ToList();
        //}
    }
}
