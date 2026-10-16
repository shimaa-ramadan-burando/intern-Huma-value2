using ECommerce.Application.Common.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IApplicationDbContext context, ILogger<CreateProductCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating product with name: {ProductName}", request.Name);
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Product created successfully with ID: {ProductId}", product.Id);
            return product.Id;
        }
    }
}
