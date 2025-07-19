using Code.Meta.Windows.Beahviours;
using UnityEngine;

namespace Code.Meta.Windows.Configs
{
	[CreateAssetMenu(menuName = "Makeup Dressdoll/Window Config", fileName = "WindowConfig")]
	public class WindowConfig : ScriptableObject
	{
		public WindowId TypeId;
		public BaseWindow ViewPrefab;
	}
}