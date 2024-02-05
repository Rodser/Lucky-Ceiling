using System;

namespace Sources.StateMachine.Infrastructure.Interfaces.Services.Updates
{
    public interface IUpdateService : IUpdatable
    {
        event Action<float> Updated;
    }
}