using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Products.Queries.GetProduct;

public record GetProductQuery(Guid ProductId) : IRequest<Result<Product>>;
