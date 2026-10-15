using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
      
            DbSet<Product> Products { get; }
            Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        }
    }


