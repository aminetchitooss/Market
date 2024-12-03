namespace market;

public class ShoppingCart
{
    public readonly List<Product> _products= new ();
    private readonly List<IDiscountStrategy> _discountStrategies= new();
    
    public void AddProduct(string name, decimal price, int quantity = 1)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Name == name);
        if (existingProduct != null)
        {
            existingProduct.Quantity += quantity;
        }
        else
        {
            _products.Add(new Product(name, price, quantity));
        }
    }
    
    public void AddDiscount(IDiscountStrategy discount)
    {
        _discountStrategies.Add(discount);
    }
    
    public decimal CalculateTotal()
    {
        decimal total = _products.Sum(p => p.Price * p.Quantity);
        decimal totalDiscount = _discountStrategies.Sum(d => d.ApplyDiscount(_products));
        return total - totalDiscount;
    }

    public void PrintReceipt()
    {
        Console.WriteLine("Receipt:");
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Name} x{product.Quantity} @ {product.Price:C} = {product.Price * product.Quantity:C}");
        }
        
        decimal total = CalculateTotal();
        Console.WriteLine("---------------------");
        Console.WriteLine($"Total: {total:C}");
        Console.ReadLine();
    }
    
}