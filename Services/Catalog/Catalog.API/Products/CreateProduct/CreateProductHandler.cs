﻿
namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string>Category, string Description, string ImageFile, decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            
            //var result = await validator.ValidateAsync(command, cancellationToken);
            //var errors = result.Errors.Select(x=>x.ErrorMessage).ToList();

            //if (errors.Any()) 
            //{
            //    throw new ValidationException(errors.FirstOrDefault());
            //}

            //Create Product Entity from command Object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            // Save the DB
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //return result

            return  new CreateProductResult(product.Id);
        }
    }
}
