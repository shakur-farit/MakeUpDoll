namespace Code.Meta.Windows.Services
{
	public interface IWindowService
	{
		void Open(WindowId windowId);
		void Close(WindowId windowId);
	}
}