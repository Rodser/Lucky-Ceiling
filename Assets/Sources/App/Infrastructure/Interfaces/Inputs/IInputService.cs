using Sources.Domain;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;

namespace Sources.App.Infrastructure.Interfaces.Inputs
{
    public interface IInputService : IUpdatable
    {
        InputData InputData { get; set; } 
    }
}