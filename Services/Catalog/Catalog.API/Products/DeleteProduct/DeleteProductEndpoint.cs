
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async(Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(Id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
                 .WithName("DeleteProduct")
                .Produces<GetProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product");
        }
    }
}
