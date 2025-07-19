using UnityEngine;

namespace Code.Gameplay.Hero.Factory
{
	public class HeroInitializer : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		public void Initialize(Sprite sprite)
		{
			_spriteRenderer.sprite = sprite;
		}
	}
}