using System;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;
using UnityEngine;

namespace Sources.App.Infrastructure.Interfaces.Inputs
{
    public interface IInputService : IUpdatable
    {
        event Action<Vector3, float> DirectionChanged;
    }
}