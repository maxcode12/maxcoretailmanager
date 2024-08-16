﻿using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Commands
{
    internal class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommandRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductDeleteCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        async Task<Unit> IRequestHandler<ProductDeleteCommandRequest, Unit>.Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            //var validator = new ProductDeleteValidator(_productRepository);
            //var validationResult = validator.Validate(request.ProductDeleteDto);
            //if (validationResult != null)
            //{
            //    throw new ValidationException(validationResult.ToString());
            //}

            var product = _mapper.Map<Product>(request.ProductDeleteDto);
            await _productRepository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}
