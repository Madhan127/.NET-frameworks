using System;
using System.Collections.Generic;

public class Product
{
    public string ProductName { get; set; }
    public int ProductID { get; set; }
    public double Price { get; set; }

    public Product(string name, int id, double price)
    {
        ProductName = name;
        ProductID = id;
        Price = price;
    }
}

public class ProductStackDAL
{
    private Stack<Product> products = new Stack<Product>();

    public bool PushProduct(Product p)
    {
        products.Push(p);
        return true;
    }

    public bool PopProduct()
    {
        if (products.Count > 0)
        {
            products.Pop();
            return true;
        }
        return false;
    }

    public double SearchProduct(int id)
    {
        foreach (Product p in products)
        {
            if (p.ProductID == id)
                return p.Price;
        }
        return -1;
    }

    public Product[] GetAllProducts()
    {
        return products.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductStackDAL dal = new ProductStackDAL();

        dal.PushProduct(new Product("Laptop", 201, 55000));
        dal.PushProduct(new Product("Mobile", 202, 25000));
        dal.PushProduct(new Product("Headphones", 203, 3000));

        Console.WriteLine("Search Product ID 202:");
        double price = dal.SearchProduct(202);

        if (price != -1)
            Console.WriteLine("Price: " + price);
        else
            Console.WriteLine("Product Not Found");

        Console.WriteLine("\nAll Products (Stack - LIFO):");
        foreach (Product p in dal.GetAllProducts())
        {
            Console.WriteLine($"{p.ProductID} - {p.ProductName} - {p.Price}");
        }

        Console.WriteLine("\nPopping top product...");
        dal.PopProduct();

        Console.WriteLine("\nProducts After Pop:");
        foreach (Product p in dal.GetAllProducts())
        {
            Console.WriteLine($"{p.ProductID} - {p.ProductName} - {p.Price}");
        }
    }
}
