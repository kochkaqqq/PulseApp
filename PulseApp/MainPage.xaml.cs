namespace PulseApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			Loaded += MainPage_Loaded;
			InitializeComponent();
		}

		private async void MainPage_Loaded(object? sender, EventArgs e)
		{
#if WINDOWS
        await (blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).EnsureCoreWebView2Async();

        (blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
#endif
		}
	}
}
