using Sources.App.Infrastructure.Implementation.Repositories;
using Sources.App.Storabls;
using Sources.Domain.Models.SpotLamps;
using Sources.StateMachine.Infrastructure.Interfaces.Providers;
using UnityEngine;

namespace Sources.App.Services
{
    public class ClickService
    {
        private readonly IViewFactoryProvider _viewFactoryProvider;
        private readonly StorableRepository _storableRepository;

        public ClickService(IViewFactoryProvider viewFactoryProvider, StorableRepository storableRepository)
        {
            _viewFactoryProvider = viewFactoryProvider;
            _storableRepository = storableRepository;
        }
        
        public void Click(Vector2 position)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            Physics.Raycast(ray, out RaycastHit hit);

            if(hit.collider == null)
                return;
            
            // var component = hit.collider.GetComponent<CeilingView>();
            Debug.Log(hit.point);

            var spot = new SpotLampStorable(new SpotLamp(hit.point), hit.point);
            spot.Load(_viewFactoryProvider);
            _storableRepository.Add(spot);
        }
    }
}