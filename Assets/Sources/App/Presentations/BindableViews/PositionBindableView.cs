using System.Reflection;
using Sources.MVVM.Bindings;
using UnityEngine;

namespace Sources.App.Presentations.BindableViews
{
    public class PositionBindableView : MonoBehaviour, IBindableView<Vector3>
    {
        public ObservableProperty<Vector3> OnBind()
        {
            return new(this, GetType()
                .GetProperty(nameof(Position), BindingFlags.Instance | BindingFlags.NonPublic));
        }

        private Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}