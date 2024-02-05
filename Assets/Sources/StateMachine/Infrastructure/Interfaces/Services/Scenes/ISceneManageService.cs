using Cysharp.Threading.Tasks;

namespace Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes
{
    public interface ISceneManageService
    {
        UniTask LoadSceneAsync(string nameScene);
    }
}