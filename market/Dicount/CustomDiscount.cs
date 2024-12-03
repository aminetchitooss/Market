namespace market;

public class CustomDiscount:IDiscountStrategy
{
    private readonly string _productName;
    private readonly int _threshold;

    public CustomDiscount(string productName, int threshold)
    {
        _productName = productName;
        _threshold = threshold;
    }

    public decimal ApplyDiscount(List<Product> products)
    {
        var product = products.FirstOrDefault(p => p.Name == _productName);
        if (product == null) return 0;

        int freeItems = product.Quantity;
        
        if (_threshold == 1)
        {
            freeItems = product.Quantity - 1;
        }
        else
        {
            freeItems = product.Quantity / _threshold;
        }
        
        return freeItems * product.Price;
    }
}