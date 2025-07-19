using Code.Infrastructure.StaticData;
using Code.Meta.Windows.Configs;
using Zenject;

namespace Code.Gameplay.Hero.Factory
{
	public class HeroFactory : IHeroFactory
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public HeroFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public void CreateHero(HeroTypeId typeId)
		{
			HeroConfig config = _staticDataService.GetHeroConfig(typeId);

			HeroInitializer hero = _instantiator.InstantiatePrefabForComponent<HeroInitializer>(config.VeiwPrefab);

			hero.Initialize(config.Sprite);
		}
	}
}