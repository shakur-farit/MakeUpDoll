using Code.Gameplay.Hero.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.Windows;
using Code.Meta.Windows.Configs;
using Code.Meta.Windows.Services;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IHeroFactory _heroFactory;
		private readonly IWindowService _windowService;

		public GameplayState(
			IGameStateMachine stateMachine,
			IHeroFactory heroFactory,
			IWindowService windowService)
		{
			_stateMachine = stateMachine;
			_heroFactory = heroFactory;
			_windowService = windowService;
		}

		public void Enter()
		{
			PlaceHero();
			OpenHud();
		}

		public void Exit()
		{
			
		}

		private void PlaceHero() => 
			_heroFactory.CreateHero(HeroTypeId.Belly);

		private void OpenHud() => 
			_windowService.Open(WindowId.Hud);
	}
}