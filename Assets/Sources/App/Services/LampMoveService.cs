using Sources.Domain.Models.SpotLamps;
using UnityEngine;

namespace Sources.App.Services
{
    public class LampMoveService
    {
        public void Move(SpotLamp spotLamp, Vector2 direction, float deltaTime)
        {
            direction.Normalize();
            spotLamp.Position += spotLamp.Speed * deltaTime * direction;
        }
    }
}