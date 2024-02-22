using Sources.App.ViewModels;
using Sources.Domain.Models.SpotLamps;
using Sources.MVVM.Presentations;

namespace Sources.App.Presentations
{
    public class SpotLampView : View
    {
        public SpotLamp GetModel()
        {
            var viewModel = (SpotLampViewModel) _viewModel;
            return viewModel.SpotLamp;
        }
    }
}