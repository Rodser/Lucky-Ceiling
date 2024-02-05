using System;
using System.Collections.Generic;
using Sources.StateMachine.Infrastructure.Implementation.StateMachines;
using Sources.StateMachine.Infrastructure.Interfaces.Factories.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.StateMaсhines;

namespace Sources.StateMachine.Infrastructure.Implementation.Services.Scenes
{
    public class SceneStateMachineService : ISceneStateMachineService
    {
        private readonly IStateMachine _stateMachine;
        private readonly IReadOnlyDictionary<Type, ISceneFactory> _sceneFactories;
        private readonly UpdatableStateMachine _updatableStateMachine;

        public SceneStateMachineService(IStateMachine stateMachine, IReadOnlyDictionary<Type, ISceneFactory> sceneFactories)
        {
            _stateMachine = stateMachine;
            _sceneFactories = sceneFactories;
            _updatableStateMachine = new UpdatableStateMachine(stateMachine);
        }
        
        public void ChangeScene<T>() where T : IScene
        {
            if (_sceneFactories.TryGetValue(typeof(T), out ISceneFactory factory) == false)
                throw new InvalidOperationException();
            
            IState state = factory.Create(this);
            _stateMachine.ChangeState(state);
        }
        
        public void Update(float deltaTime)
        {
            _updatableStateMachine.Update(deltaTime);
        }
    }
}