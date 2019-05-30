using System;
using System.IO;
using Xamarin.Forms;
using sun_or_rain.Droid;
using sun_or_rain.db;

[assembly: Dependency(typeof(FileHelper))]
namespace sun_or_rain.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}