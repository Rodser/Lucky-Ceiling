using Sources.App.Controllers.Implementations.Scenes;
using Sources.Helps;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;
using UnityEngine;

namespace Sources.App.Applications
{
    public class App : MonoBehaviour
    {
        private ISceneStateMachineService _sceneService;

        public void Construct(ISceneStateMachineService sceneService)
        {
            _sceneService = sceneService;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            RegLog.Print(nameof(App));
        }

        private void Start()
        {
            // TODO: change on menu scene
            _sceneService.ChangeScene<GameplayScene>();
        }

        private void Update()
        {
            _sceneService?.Update(Time.deltaTime);
        }
    }
}
