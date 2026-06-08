using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Orders.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetAllOrdersQuery, Result<List<Order>>>
{
    public async Task<Result<List<Order>>> Handle(GetAllOrdersQuery request, CancellationToken ct)
    {
        var orders = await orderRepository.GetAllAsync();
        return orders;
    }
}
