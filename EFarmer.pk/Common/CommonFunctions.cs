using ImageMagick;
using System.IO;

namespace EFarmer.pk.Common
{
    public static class CommonFunctions
    {
        public static void CompressImage(string path)
        {
            FileInfo file = new FileInfo(path);
            using (MagickImage image = new MagickImage(file))
            {
                image.Resize(1280, 720);
                image.Quality = 50;
                image.Write(file);
            }
        }
    }
}
