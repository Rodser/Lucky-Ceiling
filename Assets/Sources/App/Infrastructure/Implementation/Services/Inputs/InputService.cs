using System;
using Sources.App.Infrastructure.Interfaces.Inputs;
using UnityEngine;

namespace Sources.App.Infrastructure.Implementation.Services.Inputs
{
    public class InputService : IInputService
    {
        public event Action<Vector3, float> DirectionChanged;
        public event Action Saved;
        public event Action Loaded;
        
        public void Update(float deltaTime)
        {
            var changed = false;
            var direction = Vector3.zero;
            
            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector3.left;
                changed = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector3.right;
                changed = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector3.forward;
                changed = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector3.back;
                changed = true;
            }
            if (changed)
            {
                DirectionChanged?.Invoke(direction, deltaTime);
            }
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                Saved?.Invoke();
            }
            else if(Input.GetKeyDown(KeyCode.V))
            {
                Loaded?.Invoke();
            }
        }
    }
}