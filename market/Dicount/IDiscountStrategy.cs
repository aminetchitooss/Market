namespace market;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(List<Product> products);
}