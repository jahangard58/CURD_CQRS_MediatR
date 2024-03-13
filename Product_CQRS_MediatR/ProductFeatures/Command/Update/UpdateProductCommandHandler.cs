using MediatR;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Product_CQRS_MediatR.Context;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Command.Update
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResponseMessage>
    {
        private readonly IApplicationContext _context;

        public UpdateProductCommandHandler(IApplicationContext context)
        {
            this._context = context;
        }

        public async Task<ResponseMessage> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _context.Products.SingleOrDefaultAsync(f => f.ID == request.ID);
            if (product != null)
            {
                product.ProductName = request.ProductName;
                product.Price = request.Price;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return new ResponseMessage();
            }
            return new ResponseMessage("کالای مورد نظر وجود ندارد");
        }
    }
}
