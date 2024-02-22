using Sources.App.Infrastructure.Implementation.Repositories;
using Sources.App.Presentations;
using Sources.App.Storabls;
using Sources.Domain.Models.SpotLamps;
using Sources.MVVM.Presentations;
using Sources.StateMachine.Infrastructure.Interfaces.Providers;
using UnityEngine;

namespace Sources.App.Services
{
    public class ClickService
    {
        private readonly IViewFactoryProvider _viewFactoryProvider;
        private readonly StorableRepository _storableRepository;
        private readonly SelectService _selectService;

        public ClickService(IViewFactoryProvider viewFactoryProvider, 
            StorableRepository storableRepository,
            SelectService selectService)
        {
            _viewFactoryProvider = viewFactoryProvider;
            _storableRepository = storableRepository;
            _selectService = selectService;
        }
        
        public void Click(Vector2 position)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            Physics.Raycast(ray, out RaycastHit hit);

            if(hit.collider == null)
                return;

            if (!hit.collider.TryGetComponent(out View component)) return;
            
            if (component is CeilingView)
            {
                Debug.Log(hit.point);

                var spot = new SpotLampStorable(new SpotLamp(hit.point), hit.point);
                spot.Load(_viewFactoryProvider);
                _storableRepository.Add(spot);
            }
            else if (component is SpotLampView spotLampView)
            {
                _selectService.ChangeSelect(spotLampView);
            }
        }
    }
}