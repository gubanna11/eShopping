namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public string UserName { get; set; }

    public List<ShoppingCartItemResponse> Items { get; set; }

    public decimal TotalPrice 
        => Items.Sum(i => i.Price* i.Quantity);
    
    public ShoppingCartResponse()
    {
        UserName = string.Empty;
        Items = new List<ShoppingCartItemResponse>();
    }

    public ShoppingCartResponse(string userName)
        : this(userName, new List<ShoppingCartItemResponse>())
    {
    }

    public ShoppingCartResponse(string userName, List<ShoppingCartItemResponse> items)
    {
        UserName = userName ?? string.Empty;
        Items = items ?? new List<ShoppingCartItemResponse>();
    }
}