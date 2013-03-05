using System;
using System.Collections;

// http://www.codeproject.com/Articles/328361/Understanding-and-Implementing-Observer-Pattern-in

namespace ObserverPattern
{
    abstract class ASubject
    {
        // This is the one way we can implement it, lets call it WAY_1
        ArrayList list = new ArrayList();
        
        // This is another way we can implement observer, lets call it WAY_2
        public delegate void StatusUpdate(float price);
        public event StatusUpdate OnStatusUpdate = null;
        
        public void Attach(Shop product)
        {
            // For way 1 lets assign attach the observers with subjects
            list.Add(product);
        }
        
        public void Detach(Shop product)
        {
            // For way 1 lets assign detach the observers with subjects
            list.Remove(product);
        }
        
        public void Attach2(Shop product)
        {
            // For way 2 lets assign attach the observers with subjects
            OnStatusUpdate += new StatusUpdate(product.Update);
        }
        
        public void Detach2(Shop product)
        {
            //For way 2 lets assign detach the observers with subjects
            OnStatusUpdate -= new StatusUpdate(product.Update);
        }
        
        public void Notify(float price)
        {
            //For way 1 lets notify the observers with change
            foreach (Shop p in list)
            {
                p.Update(price);
            }
            
            //For way 2 lets notify the observers with change
            if (OnStatusUpdate != null)
            {
                OnStatusUpdate(price);
            }
        }
    }
    
    class DummyProduct : ASubject
    {
        public void ChangePrice(float price)
        {
            Notify(price);
        }
    }
    
    interface IObserver
    {
        void Update(float price);
    }
    
    class Shop : IObserver
    {
        // name of the product
        string name;
        float price = 0.0f; //default
        
        public Shop(string name)
        {
            this.name = name;
        }
        
        public void Update(float price)
        {
            this.price = price;
            
            Console.WriteLine(@" Price at {0} is now {1}", name, price);
        }
    }
    
    class Program
    {
        static void Main()
        {
            DummyProduct product = new DummyProduct();
            
            // We have four shops wanting to keep updated price set by product owner
            Shop shop1 = new Shop("Shop 1");
            Shop shop2 = new Shop("Shop 2");
            
            Shop shop3 = new Shop("Shop 3");
            Shop shop4 = new Shop("Shop 4");
            
            // Lets use WAY_1 for first two shops
            product.Attach(shop1);
            product.Attach(shop2);
            
            // Lets use WAY_2 for other two shops
            product.Attach2(shop3);
            product.Attach2(shop4);
            
            // Now lets try changing the products price, this should update the shops automatically
            product.ChangePrice(23.0f);
            
            // Now shop2 and shop4 are not intrested in new prices so they unsubsribe
            product.Detach(shop2);
            product.Detach2(shop4);
            
            // Now lets try changing the products price again
            product.ChangePrice(26.0f);
        }
    }
}