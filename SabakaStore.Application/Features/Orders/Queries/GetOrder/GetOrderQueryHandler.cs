using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Orders.Queries.GetOrder;

public class GetOrderQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderQuery, Result<Order>>
{
    public async Task<Result<Order>> Handle(GetOrderQuery request, CancellationToken ct)
    {
        var order = await orderRepository.GetByIdAsync(request.OrderId);
        if (order is null)
            return OrderErrors.NotFound;

        return order;
    }
}
