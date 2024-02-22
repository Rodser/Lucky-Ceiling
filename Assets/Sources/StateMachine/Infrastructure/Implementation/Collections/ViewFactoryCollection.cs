using System;
using System.Collections.Generic;
using Sources.MVVM.Presentations;
using Sources.StateMachine.Infrastructure.Interfaces.Factories;
using Sources.StateMachine.Infrastructure.Interfaces.Providers;

namespace Sources.StateMachine.Infrastructure.Implementation.Collections
{
    public class ViewFactoryCollection : IViewFactoryProvider
    {
        private readonly Dictionary<Type, object> _factories = new Dictionary<Type, object>();

        public void Register<T>(IFactory<T> factory) where T : IView
        {
            _factories[factory.GetType()] = factory;
        }   
        
        public T Get<T>() where T : IFactory<IView>
        {
            return (T)_factories[typeof(T)];
        }
    }
}