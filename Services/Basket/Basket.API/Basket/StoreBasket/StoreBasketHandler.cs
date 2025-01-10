
namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string userName);
    public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand,StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
           ShoppingCart cart = command.Cart;
            //ToDO: store basket in db (use marten upsert - if exist = update, if not = insert)
            // TODO : Update Cache.

            return new StoreBasketResult("swn");
        }
    }
}
