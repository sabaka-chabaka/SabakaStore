using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<Result<List<Product>>>;
