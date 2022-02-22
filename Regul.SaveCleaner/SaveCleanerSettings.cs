using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Onebeld.Extensions;

namespace Regul.SaveCleaner
{
	[DataContract]
	public class SaveCleanerSettings : ViewModelBase
	{
		private bool _deletingCharacterPortraits;
		private bool _removingLotThumbnails;
		private bool _removingPhotos;
		private bool _removingTextures;
		private bool _removingGeneratedImages;
		private bool _removingFamilyPortraits;
		private bool _createABackup;
		private bool _clearCache;
		private bool _removeOtherTypes;
		private string _pathToTheSims3Document;
		private string _pathToSaves;
		private string _pathToBackup;
		
		private bool _casPartCacheClear = true;
		private bool _compositorCacheClear = true;
		private bool _scriptCacheClear = true;
		private bool _simCompositorCacheClear = true;
		private bool _socialCacheClear = true;
		private bool _worldCachesClear = true;
		private bool _igaCacheClear = true;
		private bool _thumbnailsClear = true;
		private bool _featuredItemsClear = true;
		private bool _allXmlClear = true;
		private bool _dccClear = true;
		private bool _downloadedSimsClear = true;

		public SaveCleanerSettings()
		{
			if (FirstRun)
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					PathToTheSims3Document = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documents", "Electronic Arts", "The Sims 3");
					PathToSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documents", "Electronic Arts", "The Sims 3", "Saves");
				}
				else
				{
					PathToTheSims3Document = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Electronic Arts", "The Sims 3");
					PathToSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Electronic Arts", "The Sims 3", "Saves");
				}

				WorldCachesClear = !RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

				FirstRun = false;
			}
		}

		public static SaveCleanerSettings Settings { get; set; }

		public static SaveCleanerSettings Load()
		{
			if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Settings"))
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Settings");

			try
			{
				using (FileStream fileStream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "Settings/" + "regulSaveCleaner.xml"))
					return (SaveCleanerSettings)new XmlSerializer(typeof(SaveCleanerSettings)).Deserialize(fileStream);
			}
			catch
			{
				return new SaveCleanerSettings();
			}
		}

		public static void Save()
		{
			using (FileStream fileStream = File.Create(AppDomain.CurrentDomain.BaseDirectory + "Settings/" + "regulSaveCleaner.xml"))
				new XmlSerializer(typeof(SaveCleanerSettings)).Serialize(fileStream, Settings);
		}

		[DataMember]
		public bool FirstRun { get; set; } = true;

		[DataMember]
		public bool DeletingCharacterPortraits
		{
			get => _deletingCharacterPortraits;
			set => RaiseAndSetIfChanged(ref _deletingCharacterPortraits, value);
		}
		[DataMember]
		public bool RemovingLotThumbnails
		{
			get => _removingLotThumbnails;
			set => RaiseAndSetIfChanged(ref _removingLotThumbnails, value);
		}
		[DataMember]
		public bool RemovingPhotos
		{
			get => _removingPhotos;
			set => RaiseAndSetIfChanged(ref _removingPhotos, value);
		}
		[DataMember]
		public bool RemovingTextures
		{
			get => _removingTextures;
			set => RaiseAndSetIfChanged(ref _removingTextures, value);
		}
		[DataMember]
		public bool RemovingGeneratedImages
		{
			get => _removingGeneratedImages;
			set => RaiseAndSetIfChanged(ref _removingGeneratedImages, value);
		}
		[DataMember]
		public bool RemovingFamilyPortraits
		{
			get => _removingFamilyPortraits;
			set => RaiseAndSetIfChanged(ref _removingFamilyPortraits, value);
		}
		[DataMember]
		public bool CreateABackup
		{
			get => _createABackup;
			set => RaiseAndSetIfChanged(ref _createABackup, value);
		}
		[DataMember]
		public bool ClearCache
		{
			get => _clearCache;
			set => RaiseAndSetIfChanged(ref _clearCache, value);
		}

		[DataMember]
		public bool RemoveOtherTypes
		{
			get => _removeOtherTypes;
			set => RaiseAndSetIfChanged(ref _removeOtherTypes, value);
		}

		[DataMember]
		public string PathToTheSims3Document
		{
			get => _pathToTheSims3Document;
			set => RaiseAndSetIfChanged(ref _pathToTheSims3Document, value);
		}
		[DataMember]
		public string PathToSaves
		{
			get => _pathToSaves;
			set => RaiseAndSetIfChanged(ref _pathToSaves, value);
		}
		[DataMember]
		public string PathToBackup
		{
			get => _pathToBackup;
			set => RaiseAndSetIfChanged(ref _pathToBackup, value);
		}
		
		// Clear cache
        [DataMember]
        public bool CasPartCacheClear
		{
            get => _casPartCacheClear;
            set => RaiseAndSetIfChanged(ref _casPartCacheClear, value);
        }
        [DataMember]
        public bool CompositorCacheClear
		{
            get => _compositorCacheClear;
            set => RaiseAndSetIfChanged(ref _compositorCacheClear, value);
        }
        [DataMember]
        public bool ScriptCacheClear
        {
            get => _scriptCacheClear;
            set => RaiseAndSetIfChanged(ref _scriptCacheClear, value);
        }
        [DataMember]
        public bool SimCompositorCacheClear
        {
            get => _simCompositorCacheClear;
            set => RaiseAndSetIfChanged(ref _simCompositorCacheClear, value);
        }
        [DataMember]
        public bool SocialCacheClear
        {
            get => _socialCacheClear;
            set => RaiseAndSetIfChanged(ref _socialCacheClear, value);
        }
        [DataMember]
        public bool WorldCachesClear
        {
            get => _worldCachesClear;
            set => RaiseAndSetIfChanged(ref _worldCachesClear, value);
        }
        [DataMember]
        public bool IgaCacheClear
        {
            get => _igaCacheClear;
            set => RaiseAndSetIfChanged(ref _igaCacheClear, value);
        }
        [DataMember]
        public bool ThumbnailsClear
        {
            get => _thumbnailsClear;
            set => RaiseAndSetIfChanged(ref _thumbnailsClear, value);
        }
        [DataMember]
        public bool FeaturedItemsClear
        {
            get => _featuredItemsClear;
            set => RaiseAndSetIfChanged(ref _featuredItemsClear, value);
        }
        [DataMember]
        public bool AllXmlClear
        {
            get => _allXmlClear;
            set => RaiseAndSetIfChanged(ref _allXmlClear, value);
        }
        [DataMember]
        public bool DccClear
        {
            get => _dccClear;
            set => RaiseAndSetIfChanged(ref _dccClear, value);
        }
        [DataMember]
        public bool DownloadedSimsClear
        {
            get => _downloadedSimsClear;
            set => RaiseAndSetIfChanged(ref _downloadedSimsClear, value);
        }
	}
}