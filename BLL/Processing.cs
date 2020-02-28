using ImageMagick;
using RWPictures.IBLC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.BLL
{
    public static class Processing
    {
        public static Bitmap GetBitmap(string path, MagickFormat format, ImageFormat outputFormat)
        {
            Bitmap bmp;
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                MagickReadSettings settings = new MagickReadSettings
                {
                    Format = format,
                    Density = new Density(250),
                    UseMonochrome = true,
                    AntiAlias = false,
                    ColorType = ColorType.Bilevel
                };
                //settings.FrameIndex = 0; // First page
                //settings.FrameCount = 1; // Number of pages

                collection.Read(path, settings);
                bmp = collection[0].ToBitmap(outputFormat); //Хорошо зарекомендовали себя: Gif, Tiff
                                                            //bmp.Save(Path.Combine(Environment.CurrentDirectory, "output.Bmp"));
            }

            return bmp;
        }
    }
}
