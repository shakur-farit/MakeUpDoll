using Code.Gameplay.Hero.Factory;
using UnityEngine;

namespace Code.Meta.Windows.Configs
{
	[CreateAssetMenu(menuName = "Makeup Dressdoll/Hero Config", fileName = "HeroConfig")]
	public class HeroConfig : ScriptableObject
	{
		public HeroTypeId TypeId;
		public Sprite Sprite;
		public HeroInitializer VeiwPrefab;
	}
}