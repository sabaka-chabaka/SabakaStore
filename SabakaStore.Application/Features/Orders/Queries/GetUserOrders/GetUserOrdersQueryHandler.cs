using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Orders.Queries.GetUserOrders;

public class GetUserOrdersQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetUserOrdersQuery, Result<Order>>
{
    public async Task<Result<Order>> Handle(GetUserOrdersQuery request, CancellationToken ct)
    {
        var order = await orderRepository.GetByUserIdAsync(request.UserId);
        if (order is null)
            return OrderErrors.NotFound;

        return order;
    }
}
