using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class CargoTypeValidator : IValidate<CargoType>
    {
        private readonly Repository<CargoType> _repository;

        public CargoTypeValidator(Repository<CargoType> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(CargoType entity)
        {
            return _repository.Table.FirstOrDefault(ct => ct.Name == entity.Name) == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
