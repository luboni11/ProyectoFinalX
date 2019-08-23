using System;
namespace AppBancaEnLinea2C2019.Droid
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return System.IO.Path.Combine(docFolder, filename);
        }

        public FileAccessHelper()
        {
        }
    }
}
