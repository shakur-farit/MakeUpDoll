using Code.Meta.Windows.Beahviours;
using UnityEngine;

namespace Code.Meta.Windows.Factory
{
	public interface IWindowFactory
	{
		void SetUIRoot(RectTransform uiRoot);
		BaseWindow CreateWindow(WindowId windowId);
	}
}