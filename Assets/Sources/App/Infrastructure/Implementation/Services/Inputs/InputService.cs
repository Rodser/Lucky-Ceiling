using System;
using Sources.App.Infrastructure.Interfaces.Inputs;
using Sources.Domain;
using UnityEngine;

namespace Sources.App.Infrastructure.Implementation.Services.Inputs
{
    public class InputService : IInputService
    {
        public event Action Saved;
        public event Action Loaded;
        
        public InputData InputData { get; set; } 
        
        public void Update(float deltaTime)
        {
            var isFire = false;
            var direction = Vector2.zero;
            
            if (Input.GetKey(KeyCode.Space))
            {
                isFire = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Saved?.Invoke();
            }
            else if(Input.GetKeyDown(KeyCode.V))
            {
                Loaded?.Invoke();
            }

            InputData = new InputData(direction, isFire);
        }
    }
}