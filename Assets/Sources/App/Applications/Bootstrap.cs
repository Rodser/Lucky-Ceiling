using Sources.App.Domains;
using Sources.App.Presentations;
using Sources.App.ViewModels;
using Sources.MVVM.Factories;
using Sources.MVVM.Presentations;
using UnityEngine;

namespace Sources.App.Applications
{
    // example
    public class Bootstrap : MonoBehaviour
    {
        private IView _view;
        private ItemModel _item;
        private ItemViewModel _itemViewModel;
        
        private void Awake()
        {
            _item = new ItemModel(Vector3.up);
            _itemViewModel = new ItemViewModel(_item);
            _view = new ViewFactory().Create<ItemView, ItemViewModel>(_itemViewModel);
        }

        private void OnEnable()
        {
            _view.Show();
        }

        private void OnDisable()
        {
            _view.Hide();
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Move");
                _item.Move();
            }
            
            if(Input.GetKey(KeyCode.R))
            {
                Debug.Log("Rotate");
                _item.Rotate();
            }

        }
    }
}