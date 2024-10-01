using CSharpFunctionalExtensions;
using ECommerceApp.Core.Features.Orders.ValueObjects;
using MediatR;

namespace ECommerceApp.Core.Features.Orders.Commands;

public class CreateOrderCommand : IRequest<Result>
{
    public Guid CustomerId { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public Address ShippingAddress { get; set; }

    public CreateOrderCommand(Guid customerId, List<OrderItemDto> items, Address shippingAddress)
    {
        CustomerId = customerId;
        Items = items ?? new List<OrderItemDto>();
        ShippingAddress = shippingAddress;
    }
}

public record OrderItemDto(Guid ProductId, int Quantity, decimal Price);