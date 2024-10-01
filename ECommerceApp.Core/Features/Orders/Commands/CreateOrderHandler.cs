using CSharpFunctionalExtensions;
using ECommerceApp.Core.Features.Orders.Domain;
using ECommerceApp.Core.Features.Orders.Repositories;
using MediatR;

namespace ECommerceApp.Core.Features.Orders.Commands;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Validação dos dados de entrada
        if (request.Items == null || request.Items.Count == 0)
        {
            return Result.Failure("Order must contain at least one item.");
        }

        // Verificação da disponibilidade dos produtos
        //foreach (var item in request.Items)
        //{
        //    var product = await _productRepository.GetByIdAsync(item.ProductId);
        //    if (product == null)
        //    {
        //        return Result.Failure($"Product with ID {item.ProductId} not found.");
        //    }

        //    if (product.StockQuantity < item.Quantity)
        //    {
        //        return Result.Failure($"Insufficient stock for product {product.Name}.");
        //    }
        //}

        // Criação da ordem
        var orderItems = request.Items.Select(item => new OrderItem(item.ProductId, item.Quantity, item.Price)).ToList();
        var order = new Order(request.CustomerId, request.ShippingAddress, orderItems);

        // Salvando a ordem no repositório
        await _orderRepository.AddAsync(order);

        // Atualização do estoque dos produtos
        //foreach (var item in request.Items)
        //{
        //    var product = await _productRepository.GetByIdAsync(item.ProductId);
        //    product.ReduceStock(item.Quantity);
        //    await _productRepository.UpdateAsync(product);
        //}

        return Result.Success();
    }
}
