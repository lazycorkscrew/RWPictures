using RWPictures.IBLC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.BLL
{
    public class Logic : ILogicContracts
    {
        public byte[] GetImageFromFile(string filePath)
        {
            Bitmap bmp = Processing.GetBitmap(filePath, ImageMagick.MagickFormat.Pdf, ImageFormat.Gif);

            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                bmp.Save(memoryStream, ImageFormat.Gif);
                data = memoryStream.ToArray();
            }

            return new MemoryStream(data).ToArray();
        }

        public bool ReturnTrue()
        {
            throw new NotImplementedException();
        }
    }
}
