using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;

namespace Code.Infrastructure.States.GameStates
{
	public class LoadStaticDataState : IState
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IGameStateMachine _stateMachine;

		public LoadStaticDataState(IStaticDataService staticDataService, IGameStateMachine stateMachine)
		{
			_staticDataService = staticDataService;
			_stateMachine = stateMachine;
		}

		public async void Enter()
		{
			await _staticDataService.Load();

			_stateMachine.Enter<LoadingGameplayState, string>(Scenes.Gameplay);

		}

		public void Exit()
		{

		}
	}
}