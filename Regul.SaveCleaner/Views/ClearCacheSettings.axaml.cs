using Avalonia.Markup.Xaml;
using PleasantUI.Controls.Custom;

namespace Regul.SaveCleaner.Views
{
	public class ClearCacheSettings : PleasantDialogWindow
	{
		public ClearCacheSettings() => AvaloniaXamlLoader.Load(this);
	}
}
