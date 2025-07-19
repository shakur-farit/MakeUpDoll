using Code.Meta.Windows;
using Code.Meta.Windows.Configs;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask Load();
		WindowConfig GetWindowConfig(WindowId id);
		HeroConfig GetHeroConfig(HeroTypeId id);
	}
}