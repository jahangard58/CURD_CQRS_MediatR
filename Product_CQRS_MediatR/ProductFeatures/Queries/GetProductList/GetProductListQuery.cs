using MediatR;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.ProductFeatures.Queries.GetProductList
{
    public class GetProductListQuery:IRequest<IEnumerable<Product>>
    {
        public int ID { get; set; }
        public string? ProductName { get; set; } = null;
        public double? Price { get; set; } = 0;
    }
}
