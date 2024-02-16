using System;
using System.Linq;
using Newtonsoft.Json;
using Sources.App.Infrastructure.Implementation.Factories.Presentations;
using Sources.App.Infrastructure.Interfaces.Repositories;
using Sources.App.Infrastructure.Interfaces.Stores;
using Sources.App.Storabls;
using Sources.Domain.Models;
using Sources.Domain.Models.SpotLamps;
using Sources.Helps;
using Sources.StateMachine.Infrastructure.Interfaces.Providers;
using UnityEngine;

namespace Sources.App.Infrastructure.Implementation.Services.Stores
{
    public class StoreService : IStoreService
    {
        private readonly IRepository _repository;
        private readonly IDataSource _dataSource;
        private readonly IViewFactoryProvider _viewFactoryProvider;

        public StoreService(IRepository repository, IDataSource dataSource, IViewFactoryProvider viewFactoryProvider)
        {
            _repository = repository;
            _dataSource = dataSource;
            _viewFactoryProvider = viewFactoryProvider;
        }

        public void Load()
        {
            var storables = _dataSource.Load()?.Select(model =>
            {
                var type = Type.GetType(model.Type);
                RegLog.Print("Load type: " + type.Name);
                
                return (IStorable) JsonConvert.DeserializeObject(model.Data, type);
            });

            if (storables == null) return;
            
            foreach (IStorable storable in storables)
            {
                storable?.Load(_viewFactoryProvider);
                _repository.Add(storable);
            }
        }

        public void Save()
        {
            var storables = _repository.GetAll();
            foreach (IStorable storable in storables)
            {
                storable.Save();
            }

            var dataModels = storables.Select(storable => new DataModel()
            {
                Type = storable.GetType().FullName,
                Data = JsonConvert.SerializeObject(storable)
            });

            _dataSource.Save(dataModels);
        }

        public void Clear()
        {
            _repository.Clear();
        }
    }
}