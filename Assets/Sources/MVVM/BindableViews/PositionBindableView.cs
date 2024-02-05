using Sources.MVVM.Bindings;
using UnityEngine;

namespace Sources.MVVM.BindableViews
{
    public class PositionBindableView : MonoBehaviour, IBindableView<Vector3>
    {
        public ObservableProperty<Vector3> OnBind()
        {
            return new(transform, typeof(Transform).GetProperty("position"));
        }
    }
}