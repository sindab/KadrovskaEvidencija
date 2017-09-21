using System.Collections.Generic;

namespace ecDBLib.DbDapper.Service.Interface
{
    public interface IService
    {
        List<object> GetAll();

        List<object> GetAll(int amount, string sort);

        object GetByID(int Id);

        bool Create(object o);

        bool Update(object o);

        bool Delete(int Id);

    }
}
