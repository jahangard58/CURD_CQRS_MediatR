using MediatR;
using Product_CQRS_MediatR.Context;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Command.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ResponseMessage>
    {
        private readonly IApplicationContext _context;
        public AddProductCommandHandler(IApplicationContext context)
        {
            this._context = context;
        }
        public async Task<ResponseMessage> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            
            var product = new Product
            {
                
                ProductName = request.ProductName,
                Price = request.Price,

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new ResponseMessage();
        }
    }
}
