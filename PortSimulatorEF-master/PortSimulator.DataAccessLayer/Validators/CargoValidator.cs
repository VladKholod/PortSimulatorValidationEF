using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class CargoValidator : IValidate<Cargo>
    {
        private readonly Repository<Cargo> _repository;

        public CargoValidator(Repository<Cargo> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(Cargo entity)
        {
            return _repository.Table.FirstOrDefault(c => c.Number == entity.Number) == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
