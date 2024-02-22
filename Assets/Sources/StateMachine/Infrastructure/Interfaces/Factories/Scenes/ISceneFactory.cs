using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;

namespace Sources.StateMachine.Infrastructure.Interfaces.Factories.Scenes
{
    public interface ISceneFactory
    {
        IScene Create(ISceneChanger sceneChanger);
    }
}