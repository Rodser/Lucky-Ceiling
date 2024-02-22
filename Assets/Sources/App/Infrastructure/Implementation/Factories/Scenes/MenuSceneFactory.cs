using Sources.App.Controllers.Implementations.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.Factories.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;

namespace Sources.App.Infrastructure.Implementation.Factories.Scenes
{
    public class MenuSceneFactory : ISceneFactory
    {
        private readonly ISceneManageService _sceneManageService;

        public MenuSceneFactory(ISceneManageService sceneManageService)
        {
            _sceneManageService = sceneManageService;
        }

        public IScene Create(ISceneChanger sceneChanger)
        {
            return new MenuScene(sceneChanger, _sceneManageService);
        }
    }
}