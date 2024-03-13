using Microsoft.EntityFrameworkCore;
using Product_CQRS_MediatR.Model;

namespace Product_CQRS_MediatR.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
    }
}