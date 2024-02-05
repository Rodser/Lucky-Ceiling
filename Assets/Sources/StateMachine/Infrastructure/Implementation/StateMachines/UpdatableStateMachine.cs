using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;
using Sources.StateMachine.Infrastructure.Interfaces.StateMaсhines;

namespace Sources.StateMachine.Infrastructure.Implementation.StateMachines
{
    public class UpdatableStateMachine : IStateMachine, IUpdatable
    {
        private readonly IStateMachine _stateMachine;
        
        public object CurrentState => _stateMachine.CurrentState;

        public UpdatableStateMachine(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void ChangeState(IState state)
        {
            _stateMachine.ChangeState(state);
        }

        public void Update(float deltaTime)
        {
            (CurrentState as IUpdatable)?.Update(deltaTime);
        }
    }
}