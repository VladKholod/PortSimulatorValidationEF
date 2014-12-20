using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class ShipValidator : IValidate<Ship>
    {
        private readonly Repository<Ship> _repository;

        public ShipValidator(Repository<Ship> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(Ship entity)
        {
            return _repository.Table.FirstOrDefault(s => s.Number == entity.Number) == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
