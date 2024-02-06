using System;
using Sources.App.Infrastructure.Implementation.Factories.Presentations;
using Sources.App.Infrastructure.Implementation.Services.Stores;
using Sources.App.Infrastructure.Interfaces.Inputs;
using Sources.App.Storabls;
using Sources.Domain.Models.SpotLamps;
using Sources.Helps;
using Sources.StateMachine.Infrastructure.Implementation.Repositories;
using Sources.StateMachine.Infrastructure.Implementation.Services.Updates;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;
using UnityEngine;

namespace Sources.App.Controllers.Implementations.Scenes
{
    public class GameplayScene : BaseScene, IUpdatable
    {
        private readonly ISceneChanger _sceneChanger;
        private readonly ISceneManageService _sceneManageService;
        private readonly IInputService _inputService;
        private readonly UpdateService _updateService;
        private readonly SpotLampViewFactory _spotLampViewFactory;
        private readonly StoreService _storeService;
        private readonly StorableRepository _storableRepository;

        public override string Name { get; } = nameof(GameplayScene);

        public GameplayScene(ISceneChanger sceneChanger, ISceneManageService sceneManageService,
            IInputService inputService, UpdateService updateService, SpotLampViewFactory spotLampViewFactory,
            StoreService storeService, StorableRepository storableRepository)
        {
            _sceneChanger = sceneChanger?? throw new ArgumentNullException(nameof(sceneChanger));
            _sceneManageService = sceneManageService?? throw new ArgumentNullException(nameof(sceneManageService));
            _inputService = inputService?? throw new ArgumentNullException(nameof(inputService));
            _updateService = updateService?? throw new ArgumentNullException(nameof(updateService));
            _spotLampViewFactory = spotLampViewFactory?? throw new ArgumentNullException(nameof(spotLampViewFactory));
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            _storableRepository = storableRepository?? throw new ArgumentNullException(nameof(storableRepository));
        }

        public override async void Enter()
        {
            await _sceneManageService.LoadSceneAsync(Name);

            _storeService.Load();

            // var model = new SpotLamp(Vector3.zero);
            // var view = _spotLampViewFactory.Create(model);
            // _storableRepository.Add(new SpotLampStorable(model));
        }

        public override void Exit()
        {
        }

        public void Update(float deltaTime)
        {
            _inputService.Update(deltaTime);
            _updateService.Update(deltaTime);

            // TODO: Extract inputs
            if (Input.GetKeyDown(KeyCode.C))
            {
                _storeService.Save();
                RegLog.Print("Save");
            }
            else if(Input.GetKeyDown(KeyCode.V))
            {
                RegLog.Print("Load");
                _sceneChanger.ChangeScene<GameplayScene>();
                // _storeService.Load();
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                _storeService.Clear();
                RegLog.Print("Clear");
            }
        }
    }
}