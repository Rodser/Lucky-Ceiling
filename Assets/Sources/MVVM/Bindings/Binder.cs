using System.Reflection;
using Sources.MVVM.Bindings.Attributes;
using Sources.MVVM.Presentations;
using Sources.MVVM.ViewModels;
using UnityEngine;

namespace Sources.MVVM.Bindings
{
    public class Binder
    {
        private const BindingFlags DefaultBindingFlags =  BindingFlags.Instance | BindingFlags.NonPublic;

        public void Bind(View view, IViewModel viewModel)
        {
            var fields = viewModel.GetType().GetFields(DefaultBindingFlags);

            foreach (FieldInfo fieldInfo in fields)
            {
                var attributes = fieldInfo.GetCustomAttributes(true);

                foreach (var attribute in attributes)
                {
                    if (attribute is ComponentBinderAttribute componentAttribute)
                    {
                        Debug.Log(componentAttribute.ComponentType);
                        Component component = view.GetComponent(componentAttribute.ComponentType);

                        if(component == null)
                            component = view.GetComponentInChildren(componentAttribute.ComponentType);
                        
                        if (component is IBindableView bindableView)
                        {
                            fieldInfo.SetValue(viewModel, bindableView.OnBind());
                        }
                    }
                }
            }
        }

        public void UnBind(View view, IViewModel viewModel)
        {
            
        }
    }
}