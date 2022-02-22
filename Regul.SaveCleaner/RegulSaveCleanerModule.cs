using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using Onebeld.Extensions;
using Regul.Base;
using Regul.Base.Generators;
using Regul.ModuleSystem;
using Regul.ModuleSystem.Models;

namespace Regul.SaveCleaner
{
	public class RegulSaveCleanerModule : IModule
	{
		public IImage Icon { get; set; } = new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri("avares://Regul.Assets/icon.ico")));
		public string Name { get; } = "RegulSaveCleaner";
		public string Creator { get; } = "Onebeld";
		public string Description { get; } = "A tool to clean saves the game The Sims™ 3 and keep it stable.";
		public string Version { get; } = "2.2.0.0";
		public bool CorrectlyInitialized { get; set; }
		public bool ThereIsAnUpdate { get; set; }
		public void Execute()
		{
			SaveCleanerSettings.Settings = SaveCleanerSettings.Load();

			Application.Current.Styles.Add(new StyleInclude(new Uri("resm:Style?assembly=Regul"))
			{
				Source = new Uri("avares://Regul.SaveCleaner/Icons.axaml")
			});

			Base.Views.Windows.MainViewModel viewModel =
				WindowsManager.MainWindow.GetDataContext<Base.Views.Windows.MainViewModel>();
			
			((RegulMenuItem)viewModel.RegulMenuItems[1]).Items.Add
			(
				new RegulMenuItem("RegulSaveCleaner", Command.Create(ShowSaveCleaner))
				{
					Bindings = { new Binding(MenuItem.HeaderProperty, new DynamicResourceExtension("TheSims3SaveCleaner")) }
				});
			
			App.ActionsWhenCompleting.Add(Release);
		}

		private void Release()
		{
			SaveCleanerSettings.Save();
		}

		private void ShowSaveCleaner()
		{
			MainModalWindow foundWindow = WindowsManager.FindModalWindow<MainModalWindow>();

			if (foundWindow != null && foundWindow.CanOpen)
				return;

			MainModalWindow window = new MainModalWindow();
			WindowsManager.OtherModalWindows.Add(window);
			window.Show(WindowsManager.MainWindow);
		}

		public Language[] Languages { get; } = 
		{
			new Language("English", "en"),
			new Language("Russian", "ru"),
		};
		
		public IStyle LanguageStyle { get; set; }
		public string PathToLocalization { get; } = "Regul.SaveCleaner/Localization/";
		public string LinkForCheckUpdates { get; }
	}
}