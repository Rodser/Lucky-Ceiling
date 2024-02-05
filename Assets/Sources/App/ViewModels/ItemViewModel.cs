using Sources.App.Domains;
using Sources.MVVM.BindableViews;
using Sources.MVVM.Bindings;
using Sources.MVVM.Bindings.Attributes;
using Sources.MVVM.ViewModels;
using UnityEngine;

namespace Sources.App.ViewModels
{
    public class ItemViewModel : ViewModel<ItemModel>
    {
        
        [ComponentBinder(typeof(PositionBindableView))]
        private ObservableProperty<Vector3> _position;
        [ComponentBinder(typeof(RotationBindableView))]
        private ObservableProperty<Vector3> _rotation;
       
        public ItemViewModel(ItemModel model) : base(model)
        {
        }

        public override void Enable()
        {
            Model.Moved += _position.SetValue;
            Model.RotationChanged += _rotation.SetValue;
        }

        public override void Disable()
        {
            Model.Moved -= _position.SetValue;
            Model.RotationChanged -= _rotation.SetValue;
        }
    }
}