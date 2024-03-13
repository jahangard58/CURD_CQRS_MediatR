using MediatR;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Command.Delete
{
    public class DeleteProductCommand:IRequest<ResponseMessage>
    {
        public int ID { get; set; }
    }
}
