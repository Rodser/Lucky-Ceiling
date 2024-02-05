using Sources.App.Presentations;
using Sources.App.ViewModels;
using Sources.Domain.Models.SpotLamps;
using Sources.MVVM.Factories;
using Sources.MVVM.Presentations;
using Sources.StateMachine.Infrastructure.Interfaces.Factories;

namespace Sources.App.Infrastructure.Implementation.Factories.Presentations
{
    public class SpotLampViewFactory : IFactory<IView>
    {
        
        public SpotLampView Create(SpotLamp spotLamp)
        {
            var spotLampViewModel = new SpotLampViewModel(spotLamp);
            return new ViewFactory().Create<SpotLampView, SpotLampViewModel>(spotLampViewModel);
        }
    }
}