namespace market.Test;

public class UnitTest1
{
    [Fact]
    public void AddProduct_ShouldIncreaseQuantity_WhenProductAlreadyExists()
    {
        var cart = new ShoppingCart();
        cart.AddProduct("Apple", 1.00m, 2);
        cart.AddProduct("Apple", 1.00m, 3);

        Assert.Equal(5, cart._products.First(p => p.Name == "Apple").Quantity);
    }
    
    [Fact]
    public void CustomDiscount_ShouldApplyCorrectDiscount()
    {
        var cart = new ShoppingCart();
        cart.AddProduct("Apple", 1.00m, 5);
        cart.AddDiscount(new CustomDiscount("Apple",2));

        Assert.Equal(3.00m, cart.CalculateTotal());
    }
    
    [Fact]
    public void BulkDiscount_ShouldApplyCorrectDiscount()
    {
        var cart = new ShoppingCart();
        cart.AddProduct("Banana", 0.50m, 20);
        cart.AddDiscount(new BulkDiscount("Banana", 10, 1.00m));

        Assert.Equal(8.00m, cart.CalculateTotal());
    }
}