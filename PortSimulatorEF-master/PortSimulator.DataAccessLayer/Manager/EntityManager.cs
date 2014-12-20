using System.Linq;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.DataAccessLayer.Manager
{
    public class EntityManager<T> where T : BaseEntity
    {
        private readonly Repository<T> _repository;
        private readonly IValidate<T> _validatorBehaviour;

        public EntityManager(Repository<T> repository, IValidate<T> validatorBehaviour)
        {
            _validatorBehaviour = validatorBehaviour;
            _repository = repository;
        }

        public void Insert(T entity)
        {
            if (_validatorBehaviour.IsValidEntity(entity))
                _repository.Insert(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            if (_validatorBehaviour.IsEntityExist(id))
                _repository.Delete(SelectAll().FirstOrDefault(entity => entity.Id == id));
        }

        public T Select(int id)
        {
            return _validatorBehaviour.IsEntityExist(id) ? _repository.GetById(id) : null;
        }

        public IQueryable<T> SelectAll()
        {
            return _repository.Table;
        }
    }
}
