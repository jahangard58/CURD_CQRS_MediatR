using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product_CQRS_MediatR.Context;
using Product_CQRS_MediatR.Model;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Product_CQRS_MediatR.ProductFeatures.Queries.FindProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,Product> 
    {
        private readonly IDapperContext _context;
        public GetProductByIdQueryHandler(IDapperContext context)
        {
            this._context = context;
        }

       public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _context.CreateConnection())
            {
                ////////var companies = await connection.QueryAsync<Company>(query);
                ////////return companies.ToList();
                int id = request.ID;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                string query = @$"select ID,ProductName,Price from Products where ID = @Id";
                return await connection.QuerySingleOrDefaultAsync<Product>(query, dynamicParameters);
            }
            

        }

        
    }
}
