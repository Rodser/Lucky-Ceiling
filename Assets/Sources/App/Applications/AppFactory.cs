using System;
using System.Collections.Generic;
using Sources.App.Controllers.Implementations.Scenes;
using Sources.App.Infrastructure.Implementation.Factories.Scenes;
using Sources.StateMachine.Infrastructure.Implementation.Services.Scenes;
using Sources.StateMachine.Infrastructure.Implementation.StateMachines;
using Sources.StateMachine.Infrastructure.Interfaces.Factories.Scenes;
using UnityEngine;

namespace Sources.App.Applications
{
    public class AppFactory
    {
        public App Create()
        {
            var app = CreateApp();

            var stateMaсhine = new StateMachineCore();
            var sceneManageService = new SceneManageService(); 
            
            var sceneFactories = new Dictionary<Type, ISceneFactory>()
            {
                [typeof(MenuScene)] = new GameMenuSceneFactory(sceneManageService),
                [typeof(GameplayScene)] = new GameplaySceneFactory(sceneManageService),
            };

            var sceneService = new SceneStateMachineService(stateMaсhine, sceneFactories);
            app.Construct(sceneService);
            
            return app;
        }

        private App CreateApp()
        {
            return new GameObject(nameof(App)).AddComponent<App>();
        }
    }
}