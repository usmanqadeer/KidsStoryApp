using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace KidsStoriesApp.Data
{
    public class AudioFilePath
    {
        public AudioFilePath()
        {
            string DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AudioFile");
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream ambededDataBaseStreem = assembly.GetManifestResourceStream("KidsStoriesApp.AudioFile");

            if (!File.Exists(DataBasePath))
            {
                FileStream fileStreamToWrite = File.Create(DataBasePath);
                ambededDataBaseStreem.Seek(0, SeekOrigin.Begin);
                ambededDataBaseStreem.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();
            }
        }
    }
}
