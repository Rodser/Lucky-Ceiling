using System;
using Sources.App.Infrastructure.Implementation.Repositories;
using Sources.App.Infrastructure.Implementation.Services.Inputs;
using Sources.App.Infrastructure.Implementation.Services.Stores;
using Sources.App.Services;
using Sources.Domain.Models.SpotLamps;
using Sources.Helps;
using Sources.StateMachine.Infrastructure.Implementation.Services.Updates;
using Sources.StateMachine.Infrastructure.Interfaces.Providers;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;
using UnityEngine;

namespace Sources.App.Controllers.Implementations.Scenes
{
    public class GameplayScene : BaseScene, IUpdatable
    {
        private readonly ISceneChanger _sceneChanger;
        private readonly ISceneManageService _sceneManageService;
        private readonly InputService _inputService;
        private readonly UpdateService _updateService;
        private readonly IViewFactoryProvider _viewFactoryProvider;
        private readonly StoreService _storeService;
        private readonly StorableRepository _storableRepository;
        private LampMoveService _movable;
        private SelectService _selectService;

        public override string Name { get; } = nameof(GameplayScene);

        public GameplayScene(ISceneChanger sceneChanger, ISceneManageService sceneManageService,
            InputService inputService, UpdateService updateService, IViewFactoryProvider viewFactoryProvider,
            StoreService storeService, StorableRepository storableRepository)
        {
            _sceneChanger = sceneChanger?? throw new ArgumentNullException(nameof(sceneChanger));
            _sceneManageService = sceneManageService?? throw new ArgumentNullException(nameof(sceneManageService));
            _inputService = inputService?? throw new ArgumentNullException(nameof(inputService));
            _updateService = updateService?? throw new ArgumentNullException(nameof(updateService));
            _viewFactoryProvider = viewFactoryProvider;
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            _storableRepository = storableRepository?? throw new ArgumentNullException(nameof(storableRepository));
        }

        public override async void Enter()
        {
            await _sceneManageService.LoadSceneAsync(Name);

            _movable = new LampMoveService();
            _selectService = new SelectService();
            
            _storeService.Load();

            _inputService.Click += OnClick; 
            _inputService.DirectionChanged += OnDirectionChanged;
        }

        private void OnClick(Vector2 position)
        {
            var click = new ClickService(_viewFactoryProvider, _storableRepository, _selectService);
            click.Click(position);
        }
        
        private void OnDirectionChanged(Vector3 direction, float deltaTime)
        {
            if (_selectService.SelectedObject == null) return;

            _movable.Move((SpotLamp)_selectService.SelectedObject, direction, deltaTime);
        }

        public override void Exit()
        {
            _inputService.Click -= OnClick; 
            _inputService.DirectionChanged -= OnDirectionChanged;
        }

        public void Update(float deltaTime)
        {
            _inputService.Update(deltaTime);
            _updateService.Update(deltaTime);
        }

        private void OnSave()
        {
            RegLog.Print("Save");
            _storeService.Save();
        }

        private void OnLoad()
        {
            RegLog.Print("Load");
            _sceneChanger.ChangeScene<GameplayScene>();
        }
    }
}