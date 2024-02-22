using Sources.MVVM.Presentations;
using UnityEngine;

namespace Sources.StateMachine.Infrastructure.Interfaces.Factories.Views
{
    public interface IViewFactory
    {
        T Create<T>() where T : Object, IView;
    }
}