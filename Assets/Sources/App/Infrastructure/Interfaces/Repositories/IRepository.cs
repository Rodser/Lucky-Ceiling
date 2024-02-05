using System.Collections.Generic;

namespace Sources.App.Infrastructure.Interfaces.Repositories
{
    public interface IRepository
    {
        void Add(IStorable model);
        void Remove(IStorable model);
        IEnumerable<IStorable> GetAll();
        void Clear();
    }
}