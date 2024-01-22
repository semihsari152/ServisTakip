using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<ProductResponseModel> GetAllProducts();
        ProductResponseModel GetProductById(int productId);
        int CreateProduct(ProductRequestModel productRequest);
        void UpdateProduct(int productId, ProductRequestModel productRequest);
        void DeleteProduct(int productId);

    }
}