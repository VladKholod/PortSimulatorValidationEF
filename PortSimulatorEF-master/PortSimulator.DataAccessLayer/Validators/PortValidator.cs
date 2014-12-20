using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class PortValidator : IValidate<Port>
    {
        private readonly Repository<Port> _repository;

        public PortValidator(Repository<Port> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(Port entity)
        {
            return _repository.Table.FirstOrDefault(p =>
                p.Name == entity.Name
                && p.CityId == entity.CityId) == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
