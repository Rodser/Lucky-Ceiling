using System;

namespace Sources.MVVM.Bindings.Attributes
{
    public class ComponentBinderAttribute : Attribute
    {
        public ComponentBinderAttribute(Type componentType)
        {
            ComponentType = componentType;
        }

        public Type ComponentType { get; }
    }
}