using System;
using System.Collections.Generic;
using System.Linq;

namespace VariantExample
{
    public abstract class Animal
    {
    }
    
    public class Dog : Animal
    {
    }
    
    public interface IMyList<in T> 
    {
        //T GetElement();
        void ChangeT(T t);
    }
    
    public class MyList<T> : IMyList<T>
    {
        //public T GetElement()
        //{
        //    return default(T);
        //}
        
        public void ChangeT(T t)
        {
            // Change T
        }
    }
    
    public class Test
    {
        public static void Main()
        {
            Dog aDog = new Dog();
            Animal aAnimal = aDog;
            
            List<Dog> dogs = new List<Dog>();
            
            // Following conversion will fail with
            // VariantExample.cs(22,36): error CS0029: Cannot implicitly convert type
            // 'System.Collections.Generic.List<VariantExample.Dog>' to
            // 'System.Collections.Generic.List<VariantExample.Animal>'
            // List<Animal> animals = dogs;
            
            // But we could convert a List through following way
            List<Animal> animals = dogs.Select(d => (Animal)d).ToList(); 
            
            IEnumerable<Dog> someDogs = new List<Dog>();
            IEnumerable<Animal> someAnimals = someDogs; 
            
            Action<Animal> actionAnimal = new Action<Animal>(a => { /*让动物叫*/ });
            Action<Dog> actionDog = actionAnimal;
            
            IMyList<Animal> myAnimals = new MyList<Animal>();
            IMyList<Dog> myDogs = myAnimals;
        }

    }
}