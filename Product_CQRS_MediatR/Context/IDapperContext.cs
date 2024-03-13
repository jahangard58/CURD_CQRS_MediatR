using System.Data;

namespace Product_CQRS_MediatR.Context
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}