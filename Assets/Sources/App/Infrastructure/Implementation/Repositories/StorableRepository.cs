using System.Collections.Generic;
using System.Linq;
using Sources.App.Infrastructure.Interfaces.Repositories;

namespace Sources.App.Infrastructure.Implementation.Repositories
{
    public class StorableRepository : IRepository
    {
        private readonly List<IStorable> _models = new List<IStorable>();
        
        public void Add(IStorable model)
        {
            _models.Add(model);
        }

        public void Remove(IStorable model)
        {
            _models.Remove(model);
        }

        public IEnumerable<IStorable> GetAll()
        {
            return _models;
        }

        public IStorable Get<T>() where T : IStorable
        {
            return _models.FirstOrDefault(x => x.GetType() == typeof(T));
        }

        public void Clear()
        {
            _models.Clear();
        }
    }
}