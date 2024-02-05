using System.Reflection;
using Sources.MVVM.Bindings;
using UnityEngine;

namespace Sources.MVVM.BindableViews
{
    public class RotationBindableView : MonoBehaviour, IBindableView<Vector3>
    {
        public ObservableProperty<Vector3> OnBind()
        {
            return new(this, GetType()
                .GetProperty(nameof(Rotation), BindingFlags.Instance | BindingFlags.NonPublic));
    }

        private Vector3 Rotation
        {
            get => transform.rotation.eulerAngles;
            set => transform.rotation = Quaternion.Euler(value);
        }
    }
}