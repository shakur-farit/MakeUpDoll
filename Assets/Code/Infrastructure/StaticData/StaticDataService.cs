using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetsManagement;
using Code.Meta.Windows;
using Code.Meta.Windows.Configs;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string HeroConfigLabel = "HeroConfig";
		private const string WindowConfigLabel = "WindowConfig";

		private Dictionary<HeroTypeId, HeroConfig> _heroById;
		private Dictionary<WindowId, WindowConfig> _windowById;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public async UniTask Load()
		{
			await LoadHeroes();
			await LoadWindows();
		}

		public HeroConfig GetHeroConfig(HeroTypeId id)
		{
			if (_heroById.TryGetValue(id, out HeroConfig config))
				return config;

			throw new Exception($"Hero config for {id} was not found");
		}

		public WindowConfig GetWindowConfig(WindowId id)
		{
			if (_windowById.TryGetValue(id, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {id} was not found");
		}

		private async UniTask LoadHeroes() =>
			_heroById = (await _assetProvider.LoadAll<HeroConfig>(HeroConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);
	}
}