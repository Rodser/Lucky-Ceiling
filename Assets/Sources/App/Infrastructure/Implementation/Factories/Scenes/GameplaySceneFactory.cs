using Sources.App.Controllers.Implementations.Scenes;
using Sources.App.Infrastructure.Implementation.DataSources;
using Sources.App.Infrastructure.Implementation.Factories.Presentations;
using Sources.App.Infrastructure.Implementation.Repositories;
using Sources.App.Infrastructure.Implementation.Services.Inputs;
using Sources.App.Infrastructure.Implementation.Services.Stores;
using Sources.StateMachine.Infrastructure.Implementation.Collections;
using Sources.StateMachine.Infrastructure.Implementation.Services.Updates;
using Sources.StateMachine.Infrastructure.Interfaces.Factories.Scenes;
using Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes;

namespace Sources.App.Infrastructure.Implementation.Factories.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly ISceneManageService _sceneManageService;

        public GameplaySceneFactory(ISceneManageService sceneManageService)
        {
            _sceneManageService = sceneManageService;
        }

        public IScene Create(ISceneChanger sceneChanger)
        {
            var updateService = new UpdateService();
            var inputService = new InputService();

            var spotLampViewFactory = new SpotLampViewFactory();

            var viewFactoryCollection = new ViewFactoryCollection();
            viewFactoryCollection.Register(spotLampViewFactory);

            var repository = new StorableRepository();
            var dataSource = new PlayerPrefsDataSource();
            var storeService = new StoreService(repository, dataSource, viewFactoryCollection);
            
            return new GameplayScene(sceneChanger, _sceneManageService, inputService, updateService, viewFactoryCollection, storeService, repository);
        }
    }
}