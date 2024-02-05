using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Sources.App.Infrastructure.Interfaces.Repositories;
using Sources.Domain.Models;
using UnityEngine;

namespace Sources.App.Infrastructure.Implementation.DataSources
{
    public class PlayerPrefsDataSource : IDataSource
    {
        private const string Key = "USSavesModels";
        
        public IEnumerable<DataModel> Load()
        {
            var json = PlayerPrefs.GetString(Key);
            return JsonConvert.DeserializeObject<CollectionWrapper<DataModel>>(json)?.Collection;
        }

        public void Save(IEnumerable<DataModel> models)
        {
            PlayerPrefs.SetString(Key, JsonConvert.SerializeObject(new CollectionWrapper<DataModel>(models.ToArray())));
        }
    }
}