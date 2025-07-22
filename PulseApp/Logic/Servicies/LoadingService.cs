namespace PulseApp.Logic.Servicies
{
	public class LoadingService
	{
		public event Action OnStartLoading;
		public event Action OnFinishLoading;

		public void ShowLoading()
		{
			OnStartLoading?.Invoke();
		}

		public void HideLoading()
		{
			OnFinishLoading?.Invoke();
		}
	}
}
