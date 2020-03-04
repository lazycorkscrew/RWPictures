using RWPictures.IBLC;
using RWPictures.DAL;
using RWPictures.Entities;
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

        public IEnumerable<DocumentInfo> GetDocumentsInfo()
        {
            return DataAccessProvider.DBAccessor.GetDocumentsInfo();
        }

        public IEnumerable<string> GetAllProjects()
        {
            return DataAccessProvider.DBAccessor.GetAllProjects();
        }

        public bool GenerateDocument(string name, string project, string comment, IEnumerable<byte[]> images)
        {
            int docId = DataAccessProvider.DBAccessor.CreateDocument(name, project, comment);
            List<byte[]> byteImages = images as List<byte[]>;
            int imagesCount = byteImages.Count;
            for (int i = 0; i < imagesCount; i++)
            {
                if(!DataAccessProvider.DBAccessor.AttachImageToDocument(docId, byteImages[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
