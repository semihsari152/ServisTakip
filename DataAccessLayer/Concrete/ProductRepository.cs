using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using ServisTakipWebAPI.Models;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ProductRepository : IProductDal
    {
        private readonly ServisTakipDbContext _dbContext;

        public ProductRepository(ServisTakipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductResponseModel> GetAllProducts()
        {
            var products = _dbContext.Products.ToList();
            var productResponses = products.Select(MapToProductResponse).ToList();
            return productResponses;
        }

        public ProductResponseModel GetProductById(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            if (product == null)
            {
                return null;
            }

            return MapToProductResponse(product);
        }

        public int CreateProduct(ProductRequestModel productRequest)
        {
            var newProduct = new Product
            {
                ProductName = productRequest.ProductName,
                ProductType = productRequest.ProductType,
                ProductSerialNumber = productRequest.ProductSerialNumber,
                ProductAccessories = productRequest.ProductAccessories
                // Other properties can be set similarly
            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            return newProduct.ProductID;
        }

        public void UpdateProduct(int productId, ProductRequestModel productRequest)
        {
            var existingProduct = _dbContext.Products.Find(productId);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.ProductName = productRequest.ProductName;
            existingProduct.ProductType = productRequest.ProductType;
            existingProduct.ProductSerialNumber = productRequest.ProductSerialNumber;
            existingProduct.ProductAccessories = productRequest.ProductAccessories;
            // Update other properties similarly

            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _dbContext.Products.Find(productId);
            if (productToDelete == null)
            {
                return;
            }

            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        private ProductResponseModel MapToProductResponse(Product product)
        {
            return new ProductResponseModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductType = product.ProductType,
                ProductSerialNumber = product.ProductSerialNumber,
                ProductAccessories = product.ProductAccessories
                // Other properties can be mapped similarly
            };
        }
    }
}
