using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.Validators
{
    public interface IValidate<in T> where T : BaseEntity
    {
        bool IsValidEntity(T entity);
        bool IsEntityExist(int id);
    }
}
