using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class CityValidator : IValidate<City>
    {
        private readonly Repository<City> _repository;

        public CityValidator(Repository<City> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(City entity)
        {
            return _repository.Table.FirstOrDefault(c => c.Name == entity.Name) == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
