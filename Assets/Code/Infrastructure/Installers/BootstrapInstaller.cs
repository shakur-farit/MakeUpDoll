using Code.Gameplay.Hero.Factory;
using Code.Infrastructure.AssetsManagement;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Code.Meta.Windows.Factory;
using Code.Meta.Windows.Services;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
	{
		public override void InstallBindings()
		{
			BindStateMachine();
			BindStateFactory();
			BindGameStates();
			BindInputService();
			BindInfrastructureServices();
			BindAssetManagementServices();
			BindCommonServices();
			BindGameplayFactories();
			BindMetaFactories();
			BindMetaServices();
		}

		private void BindStateMachine()
		{
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
		}

		private void BindStateFactory()
		{
			Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
		}

		private void BindGameStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadStaticDataState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingGameplayState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
		}

		private void BindGameplayFactories()
		{
			Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
		}

		private void BindMetaFactories()
		{
			Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
		}

		private void BindMetaServices()
		{
			Container.Bind<IWindowService>().To<WindowService>().AsSingle();
		}

		private void BindInfrastructureServices()
		{
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
		}

		private void BindAssetManagementServices()
		{
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
		}

		private void BindCommonServices()
		{
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
		}

		private void BindInputService()
		{
			//Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
		}

		public void Initialize()
		{
			Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
		}
	}
}
