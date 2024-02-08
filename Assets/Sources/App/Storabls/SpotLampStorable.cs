using System;
using Newtonsoft.Json;
using Sources.App.Infrastructure.Implementation.Factories.Presentations;
using Sources.App.Infrastructure.Interfaces.Repositories;
using Sources.Domain;
using Sources.Domain.Models.SpotLamps;
using Sources.Extensions.Vector2;
using Sources.StateMachine.Infrastructure.Interfaces.Providers;
using UnityEngine;

namespace Sources.App.Storabls
{
    public class SpotLampStorable : IStorable
    {
        private readonly SpotLamp _spotLamp;

        public SpotLampStorable(SpotLamp spotLamp)
        {
            SpotLamp = spotLamp ?? throw new ArgumentNullException(nameof(spotLamp));
            Position = new Vector2Data();
        }

        public SpotLampStorable()
        {
            SpotLamp = new SpotLamp(Vector3.zero);
        }
        
        [JsonIgnore]
        public SpotLamp SpotLamp { get; private set; }
        public Vector2Data Position { get; set; }
        
        public void Load(IViewFactoryProvider viewFactoryProvider)
        {
            var factory = viewFactoryProvider.Get<SpotLampViewFactory>();

            factory.Create(SpotLamp);
            SpotLamp.Position = Position.Vector2DataToVector2();
        }

        public void Save()
        {
            Position = SpotLamp.Position.Vector2ToVector2Data();
        }
    }
}