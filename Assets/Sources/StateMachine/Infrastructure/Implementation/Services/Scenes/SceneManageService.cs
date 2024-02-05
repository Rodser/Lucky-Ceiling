using Cysharp.Threading.Tasks;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.StateMachine.Infrastructure.Implementation.Services.Scenes
{
    public class SceneManageService : ISceneManageService
    {
        public async UniTask LoadSceneAsync(string nameScene)
        {
            await SceneManager.LoadSceneAsync(nameScene);
        }
    }
}