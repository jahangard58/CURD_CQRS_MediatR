using MediatR;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Command.Add
{
    public class AddProductCommand:IRequest<ResponseMessage>
    {
        public string? ProductName { get; set; } = null;
        public double? Price { get; set; } = 0;
    }
}
