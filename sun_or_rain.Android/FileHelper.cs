using System;
using System.IO;
using Xamarin.Forms;
using sun_or_rain.iOS;
using sun_or_rain.db;

[assembly: Dependency(typeof(FileHelper))]
namespace sun_or_rain.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, filename);
        }
    }
}