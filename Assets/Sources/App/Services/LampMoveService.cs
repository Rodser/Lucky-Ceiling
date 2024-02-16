using Sources.Domain.Models.SpotLamps;
using UnityEngine;

namespace Sources.App.Services
{
    public class LampMoveService 
    {
        private float _speed = 25f;
        
        public void Move(SpotLamp spotLamp, Vector3 direction, float deltaTime)
        {
            direction.Normalize();
            spotLamp.Position += _speed * deltaTime * direction;
        }
    }
}