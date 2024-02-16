using System.Globalization;
using Sources.App.Presentations.BindableViews;
using Sources.Domain.Models.SpotLamps;
using Sources.Helps;
using Sources.MVVM.Bindings;
using Sources.MVVM.Bindings.Attributes;
using Sources.MVVM.ViewModels;
using UnityEngine;

namespace Sources.App.ViewModels
{
    public class SpotLampViewModel : ViewModel<SpotLamp>
    {
        [ComponentBinder(typeof(PositionBindableView))]
        private ObservableProperty<Vector3> _position;
       
        public SpotLampViewModel(SpotLamp model) : base(model)
        {
        }

        public override void Enable()
        {
            Model.PositionChanged += OnPositionChanged;
        }

        public override void Disable()
        {
            Model.PositionChanged -= OnPositionChanged;
        }

        private void OnPositionChanged()
        {
            _position.Value = Model.Position;
        }
    }
}