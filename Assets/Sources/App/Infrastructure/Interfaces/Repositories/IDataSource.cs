using System.Collections.Generic;
using Sources.Domain.Models;

namespace Sources.App.Infrastructure.Interfaces.Repositories
{
    public interface IDataSource
    {
        IEnumerable<DataModel> Load();
        void Save(IEnumerable<DataModel> models);
    }
}