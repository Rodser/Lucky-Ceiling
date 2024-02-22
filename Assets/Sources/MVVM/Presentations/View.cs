using System;
using Sources.MVVM.Bindings;
using Sources.MVVM.ViewModels;
using UnityEngine;

namespace Sources.MVVM.Presentations
{
    public class View : MonoBehaviour, IView, IDisposable
    {
        protected IViewModel _viewModel;
        private Binder _binder;

        private void Construct(IViewModel viewModel, Binder binder)
        {
            Hide();
            _viewModel = viewModel;
            _binder = binder;
            
            _binder.Bind(this, _viewModel);
            Show();
        }

        private void OnEnable()
        {
            _viewModel?.Enable();
        }

        private void OnDisable()
        {
            _viewModel?.Disable();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _binder.UnBind(this, _viewModel);
        }
    }
}