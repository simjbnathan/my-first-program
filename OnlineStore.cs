using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public Product(string productId, string name, double price, int stockQuantity)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void DisplayProductInfo()
    {
        Console.WriteLine($"ProductId: {ProductId} Name: {Name} Price: {Price:C} StockQTY: {StockQuantity}");
    }
}

public class ShoppingCart
{
    private List<Product> Cart = new List<Product>();

    public void AddToCart(Product product, int quantity)
    {
        // Check if the product is in stock
        if (product.StockQuantity >= quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Cart.Add(product);
            }

            product.StockQuantity -= quantity;
            Console.WriteLine($"{quantity} {product.Name}(s) added to the cart.");
        }
        else
        {
            Console.WriteLine($"Insufficient stock for {product.Name}.");
        }
    }

    public void RemoveFromCart(Product product, int quantity)
    {
        // Check if the product is in the cart
        int countToRemove = Math.Min(quantity, Cart.Count(item => item.ProductId == product.ProductId));

        for (int i = 0; i < countToRemove; i++)
        {
            Cart.Remove(product);
        }

        product.StockQuantity += countToRemove;
        Console.WriteLine($"{countToRemove} {product.Name}(s) removed from the cart.");
    }

    public void DisplayItems()
    {
        foreach (var item in Cart)
        {
            item.DisplayProductInfo();
        }
    }

    public double CalculateTotalCost()
    {
        return Cart.Sum(item => item.Price);
    }

    public void DisplayTotalCost()
    {
        Console.WriteLine($"Total Cost: {CalculateTotalCost():C}");
    }
}

public class User
{
    public string UserName { get; set; }
    public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();

    public User(string userName) { UserName = userName; }

    public void DisplayUser()
    {
        Console.WriteLine($"User name: {UserName}");
        ShoppingCart.DisplayItems();
        ShoppingCart.DisplayTotalCost();
    }
}

public class OnlineStore
{
    private List<Product> Store = new List<Product>();

    public void AddProduct(Product product)
    {
        Store.Add(product);
    }

    public void DisplayListOfProducts()
    {
        foreach (var item in Store)
        {
            item.DisplayProductInfo();
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        OnlineStore onlineStore = new OnlineStore();

        Product product1 = new Product("1", "Laptop", 999.99, 10);
        Product product2 = new Product("2", "Headphones", 79.99, 20);
        Product product3 = new Product("3", "Book", 14.99, 30);

        onlineStore.AddProduct(product1);
        onlineStore.AddProduct(product2);
        onlineStore.AddProduct(product3);

        User user = new User("JohnDoe");
        user.ShoppingCart.AddToCart(product1, 2);
        user.ShoppingCart.AddToCart(product2, 1);

        user.DisplayUser();
    }
}
