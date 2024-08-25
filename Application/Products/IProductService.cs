﻿using Domain.Products;

namespace Application.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        bool Add(ProductAddModel productAddModel);
    }
}
