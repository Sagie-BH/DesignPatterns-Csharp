using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorProblem
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
	public class Product
	{
		public int Id { get; set; }
	}

	public class Cart
	{
		List<Product> products;

		public void AddProduct(Product product)
		{
			products.Add(product);
		}
	}

	public class Catalog
	{
		List<Product> products;

		public List<Product> GetProducts()
		{
			return products;
		}
	}

	public class ProductPage
	{
		// Must live on the product page
		Cart cart;
		Catalog catalog;

		public ProductPage(Catalog catalog, Cart cart)
		{
			this.cart = cart;
			this.catalog = catalog;
		}

		// Inside interaction 
		public void AddToCart(int id)
		{
			var product = catalog.GetProducts().First(x => x.Id == id);
			cart.AddProduct(product);
		}

		public void DisplayProducts()
		{
			// set ui elements from catalog
		}
	}
}
