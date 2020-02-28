using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.IBLC
{
    public interface IProcessingContracts
    {
        Bitmap GetDoc(string path, MagickFormat format, ImageFormat outputFormat);
    }
}
