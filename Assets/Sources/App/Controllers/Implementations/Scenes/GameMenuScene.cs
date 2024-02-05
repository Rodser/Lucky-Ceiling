using Sources.Helps;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;

namespace Sources.App.Controllers.Implementations.Scenes
{
    public class GameMenuScene : BaseScene
    {
        private readonly ISceneChanger _sceneChanger;
        private readonly ISceneManageService _sceneManageService;

        public GameMenuScene(ISceneChanger sceneChanger, ISceneManageService sceneManageService)
        {
            _sceneChanger = sceneChanger;
            _sceneManageService = sceneManageService;
        }

        public override string Name { get; } = nameof(GameMenuScene);

        public override async void Enter()
        {
            await _sceneManageService.LoadSceneAsync(Name);
            
            RegLog.Print(Name);
        }
    }
}