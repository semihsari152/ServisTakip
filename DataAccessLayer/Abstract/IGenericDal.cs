using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        List<TResponse> GetAll();
        TResponse GetById(int id);
        int Create(TRequest request);
        void Update(int id, TRequest request);
        void Delete(int id);
    }
}