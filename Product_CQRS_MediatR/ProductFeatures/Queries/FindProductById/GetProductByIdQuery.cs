using MediatR;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Queries.FindProductById
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int ID { get; set; }
        
    }
}
