using ECommerceApp.Core.Features.Orders.Domain;
using ECommerceApp.Core.Features.Orders.ValueObjects;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public Address ShippingAddress { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderItem> Items { get; private set; }


    public Order(Guid customerId, Address shippingAddress, List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        ShippingAddress = shippingAddress;
        Items = items;
        TotalAmount = CalculateTotalAmount();
        Status = OrderStatus.Pending;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        TotalAmount = CalculateTotalAmount();
    }

    public void RemoveItem(OrderItem item)
    {
        Items.Remove(item);
        TotalAmount = CalculateTotalAmount();
    }

    public void UpdateShippingAddress(Address newAddress)
    {
        ShippingAddress = newAddress;
    }

    public void CompleteOrder()
    {
        Status = OrderStatus.Completed;
    }

    public void CancelOrder()
    {
        Status = OrderStatus.Cancelled;
    }

    private decimal CalculateTotalAmount()
    {
        return Items.Sum(item => item.Price * item.Quantity);
    }
}

public enum OrderStatus
{
    Pending,
    PaymentProcessing,
    Completed,
    Cancelled
}
