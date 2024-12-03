using market;

Console.WriteLine("Welcome to market!");


var cart = new ShoppingCart();

cart.AddProduct("Apple", 1.00m, 5);
cart.AddProduct("Banana", 0.50m, 20);

cart.AddDiscount(new CustomDiscount("Apple",2));
cart.AddDiscount(new BulkDiscount("Banana", 10, 1.00m));

cart.PrintReceipt();