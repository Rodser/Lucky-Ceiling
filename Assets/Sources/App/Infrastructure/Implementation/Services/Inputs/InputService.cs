using System;
using Sources.App.Infrastructure.Interfaces.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.App.Infrastructure.Implementation.Services.Inputs
{
    public class InputService : IInputService
    {
        private readonly InputControl _inputControl;
        private float _deltaTime;
        private bool _isSelect;

        public event Action<Vector3, float> DirectionChanged;
        public event Action Saved;
        public event Action Loaded;

        public InputService(InputControl inputControl)
        {
            _inputControl = inputControl;

            InitializeControl();
        }

        public void Update(float deltaTime)
        {
            _deltaTime = deltaTime;
        }

        private void InitializeControl()
        {
            _inputControl.BasicMap.Enable();

            _inputControl.BasicMap.Direction.performed += OnDirection;
            _inputControl.BasicMap.Select.performed += OnSelect;
        }

        private void OnSelect(InputAction.CallbackContext context)
        {
            Debug.Log("select : " + context.valueType);
            _isSelect = context.ReadValueAsButton();
        }

        private void OnDirection(InputAction.CallbackContext context)
        {
            if (!_isSelect) return;
            
            var directionVector2 = context.ReadValue<Vector2>();
            var direction = new Vector3(directionVector2.x, 0, -directionVector2.y);
            DirectionChanged?.Invoke(direction, _deltaTime);
        }
    }
}