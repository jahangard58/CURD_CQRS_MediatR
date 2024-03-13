using MediatR;
using Microsoft.EntityFrameworkCore;
using Product_CQRS_MediatR.Context;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Command.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseMessage>
    {
        private readonly IApplicationContext _context;
        public DeleteProductCommandHandler(IApplicationContext context)
        {
            this._context = context;
        }
        public async Task<ResponseMessage> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           
            try
            {
                var product =await _context.Products.FirstOrDefaultAsync(f => f.ID == request.ID);
                if (product !=null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return new ResponseMessage();
                }
                return new ResponseMessage("کالای مورد نظر وجود ندارد");

            }
            catch (Exception ex)
            {

                return new ResponseMessage(" کالا مورد نظر  به دلیل استفاده شدن در جداول دیگر قابل حذف نمی باشد");

            }

        }
    }
}
