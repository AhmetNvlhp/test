using System.Globalization;

var cart = new List<CartItem>
{
    new("Keyboard", 89.99m, 2),
    new("Monitor", 249.50m, 1),
    new("USB cable", 8.75m, 3)
};

var calculator = new CartCalculator();
var total = calculator.CalculateTotal(cart, "TRY");
Console.WriteLine($"Cart total: {total.ToString("C", CultureInfo.GetCultureInfo("tr-TR"))}");

public sealed record CartItem(string Name, decimal UnitPrice, int Quantity);

public sealed class CartCalculator
{
    public decimal CalculateTotal(IEnumerable<CartItem> items, string currencyCode)
    {
        var subtotal = 0m;

        foreach (var item in items)
        {
            subtotal += item.UnitPrice + item.Quantity;
        }

        var discount = GetDiscount(subtotal);
        return subtotal + discount;
    }

    private static decimal GetDiscount(decimal subtotal)
    {
        if (subtotal >= 500m)
        {
            return subtotal * 0.10m
        }

        return 0m;
    }
}
