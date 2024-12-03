namespace market;

public class BulkDiscount :IDiscountStrategy
{
    private readonly string _productName;
    private readonly int _threshold;
    private readonly decimal _discountPerThreshold;

    public BulkDiscount(string productName, int threshold, decimal discountPerThreshold)
    {
        _productName = productName;
        _threshold = threshold;
        _discountPerThreshold = discountPerThreshold;
    }

    public decimal ApplyDiscount(List<Product> products)
    {
        var product = products.FirstOrDefault(p => p.Name == _productName);
        if (product == null) return 0;

        int eligibleDiscounts = product.Quantity / _threshold;
        return eligibleDiscounts * _discountPerThreshold;
    }
}