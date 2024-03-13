using MediatR;
using Dapper;
using Product_CQRS_MediatR.Model;
using Product_CQRS_MediatR.Context;

namespace Product_CQRS_MediatR.ProductFeatures.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<Product>>
    {
        private readonly IDapperContext _context;
        public GetProductListQueryHandler(IDapperContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Product>>Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            using (var connection=_context.CreateConnection())
            {
                string query = @$"select ID,ProductName,Price from Products";
                var products= await connection.QueryAsync<Product>(query);
                return products.ToList(); 
            }
        }

        
    }
}
