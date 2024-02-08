using System.Collections.Generic;
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

        public void Clear()
        {
            _models.Clear();
        }
    }
}