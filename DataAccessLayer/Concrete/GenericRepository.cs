using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<TRequest, TResponse, TEntity> : IGenericRepository<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
    where TEntity : class
    {
        private readonly ServisTakipDbContext _dbContext;
        private readonly IMapper _mapper; // You can use AutoMapper for mapping between Request and Entity types

        public GenericRepository(ServisTakipDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TResponse> GetAll()
        {
            var entities = _dbContext.Set<TEntity>().ToList();
            var responses = entities.Select(MapToResponse).ToList();
            return responses;
        }

        public TResponse GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return null;
            }

            return MapToResponse(entity);
        }

        public int Create(TRequest request)
        {
            var newEntity = _mapper.Map<TEntity>(request);
            _dbContext.Set<TEntity>().Add(newEntity);
            _dbContext.SaveChanges();

            // Assuming that the ID property is named "Id" in your entities
            return (int)typeof(TEntity).GetProperty("Id").GetValue(newEntity);
        }

        public void Update(int id, TRequest request)
        {
            var existingEntity = _dbContext.Set<TEntity>().Find(id);
            if (existingEntity == null)
            {
                return;
            }

            _mapper.Map(request, existingEntity);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = _dbContext.Set<TEntity>().Find(id);
            if (entityToDelete == null)
            {
                return;
            }

            _dbContext.Set<TEntity>().Remove(entityToDelete);
            _dbContext.SaveChanges();
        }

        private TResponse MapToResponse(TEntity entity)
        {
            return _mapper.Map<TResponse>(entity);
        }
    }
}
