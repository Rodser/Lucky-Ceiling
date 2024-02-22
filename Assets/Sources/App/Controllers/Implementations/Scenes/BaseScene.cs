using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;

namespace Sources.App.Controllers.Implementations.Scenes
{
    public abstract class BaseScene : IScene
    {
        public abstract string Name { get; }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}