using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductDal _productRepository;

        public ProductManager()
        {
            
        }

        public int CreateProduct(ProductRequestModel productRequest)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductResponseModel> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductResponseModel GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productId, ProductRequestModel productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
