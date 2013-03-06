using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpInDepth.Chapter1
{
	public class Product
	{
		private string name;
		public string Name 
		{ 
			get { return name; } 
			private set { name = value; }
		}

		private decimal price;
		public decimal Price 
		{ 
			get { return price; } 
			private set { price = value;}
		}

		public Product(string name, decimal price) 
		{
			Name = name;
			Price = price;
		}

		public static List<Product> GetSampleProducts()
		{
			List<Product> products = new List<Product>();
			products.Add(new Product("West Side Story", 9.99m));
			products.Add(new Product("Assassins", 14.99m));
			products.Add(new Product("Frogs", 13.99m));
			products.Add(new Product("Sweeney Todd", 10.99m));
			return products;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}", name, price);
		}
	}

	public class Client
	{
		public static void Main(string[] args) 
		{
			List<Product> products = Product.GetSampleProducts();

			if (products != null) 
			{
				foreach (Product product in products) 
				{
					Console.WriteLine(product.ToString());
				}
			}
		}
	}
}