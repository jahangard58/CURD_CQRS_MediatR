using MediatR;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Command.Update
{
    public class UpdateProductCommand:IRequest<ResponseMessage>
    {
        public int ID { get; set; }
        public string? ProductName { get; set; } = null;
        public double? Price { get; set; } = 0;
    }
}
