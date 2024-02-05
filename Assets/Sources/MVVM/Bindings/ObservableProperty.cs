using System;
using System.Reflection;

namespace Sources.MVVM.Bindings
{
    public class ObservableProperty<T>
    {
        private readonly object _target;
        private readonly PropertyInfo _propertyInfo;

        public event Action Changed;

        public ObservableProperty(object target, PropertyInfo propertyInfo)
        {
            _target = target;
            _propertyInfo = propertyInfo;
        }

        public T Value
        {
            get => (T) _propertyInfo.GetValue(_target);

            set
            {
                _propertyInfo.SetValue(_target, value);
                Changed?.Invoke();
            }
        }
    }
}