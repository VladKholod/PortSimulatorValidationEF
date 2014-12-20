using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class CaptainValidator : IValidate<Captain>
    {
        private readonly Repository<Captain> _repository;

        public CaptainValidator(Repository<Captain> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(Captain entity)
        {
            return _repository.Table.FirstOrDefault(c => c.LastName == entity.LastName 
                && c.FirstName == entity.FirstName) == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
