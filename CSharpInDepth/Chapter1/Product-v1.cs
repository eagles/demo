using System;
using System.Collections;

namespace CSharpInDepth.Chapter1
{
	public class Product
	{
		private string name;
		public string Name { get {return name; } }

		private decimal price;
		public decimal Price { get { return price; } }

		public Product(string name, decimal price) 
		{
			this.name = name;
			this.price = price;
		}

		public static ArrayList GetSampleProducts()
		{
			ArrayList list = new ArrayList();
			list.Add(new Product("West Side Story", 9.99m));
			list.Add(new Product("Assassins", 14.99m));
			list.Add(new Product("Frogs", 13.99m));
			list.Add(new Product("Sweeney Todd", 10.99m));
			return list;
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
			ArrayList list = Product.GetSampleProducts();

			if (list != null) 
			{
				foreach (Product product in list) 
				{
					Console.WriteLine(product.ToString());
				}
			}
		}
	}
}