using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public class TripValidator : IValidate<Trip>
    {
        private readonly Repository<Trip> _repository;

        public TripValidator(Repository<Trip> repository)
        {
            _repository = repository;
        }

        public bool IsValidEntity(Trip entity)
        {
            return
                _repository.Table.FirstOrDefault(t =>
                    t.ShipId == entity.ShipId
                    && t.CaptainId == entity.CaptainId
                    && t.StartDate == entity.StartDate)
                == null;
        }

        public bool IsEntityExist(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
