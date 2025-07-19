using Code.Meta.Windows.Configs;

namespace Code.Gameplay.Hero.Factory
{
	public interface IHeroFactory
	{
		void CreateHero(HeroTypeId typeId);
	}
}