namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public string UserName { get; set; }

    public List<ShoppingCartItemResponse> Items { get; set; }

    public decimal TotalPrice
    {
        get
        {
            return Items.Sum(i => i.Price * i.Quantity);
        }
    }

    public ShoppingCartResponse()
    {
    }

    public ShoppingCartResponse(string userName)
    {
        UserName = userName;
    }
}