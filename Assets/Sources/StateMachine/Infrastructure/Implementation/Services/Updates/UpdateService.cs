using System;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;

namespace Sources.StateMachine.Infrastructure.Implementation.Services.Updates
{
    public class UpdateService : IUpdateService
    {
        public event Action<float> Updated;

        public void Update(float deltaTime)
        {
            Updated?.Invoke(deltaTime);
        }
    }
}