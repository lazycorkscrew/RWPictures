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
using System.Security.Cryptography;
using System.Data.SqlClient;

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

        public IEnumerable<string> GetAllPatterns()
        {
            return DataAccessProvider.DBAccessor.GetAllPatterns();
        }

        public bool GenerateDocument(string name, string project, string comment, string pattern, IEnumerable<byte[]> images)
        {
            int docId = DataAccessProvider.DBAccessor.CreateDocument(name, project, comment, pattern);
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

        public Dictionary<int, string> GetPatternFields(string pattern)
        {
            return DataAccessProvider.DBAccessor.GetPatternFields(pattern);
        }

        public bool RemovePatternField(string pattern, int fieldId)
        {
            return DataAccessProvider.DBAccessor.RemovePatternField(pattern, fieldId);
        }

        public bool AddFieldToPattern(string pattern, string fieldName)
        {
            return DataAccessProvider.DBAccessor.AddFieldToPattern(pattern, fieldName);
        }

        public bool RemovePattern(string pattern)
        {
            return DataAccessProvider.DBAccessor.RemovePattern(pattern);
        }

        public string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append((data[i]).ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public User GetUserByLoginAndPass(string login, string password)
        {
            return DataAccessProvider.DBAccessor.GetUserByLoginAndPass(login, password);
        }

        public bool AddUser(string login, string password, string fname, string lname, string patronymic)
        {
            try
            {
                return DataAccessProvider.DBAccessor.AddUser(login, password, fname, lname, patronymic);
            }
            catch(SqlException ex)
            {
                return false;
            }
        }

        public LinkImageDoc GetImageIdForWork(int user_id)
        {
            return DataAccessProvider.DBAccessor.GetImageIdForWork(user_id);
        }

        public byte[] GetImageById(int imageId)
        {
            return DataAccessProvider.DBAccessor.GetImageById(imageId);
        }

        public IEnumerable<string> GetImageFields(int docId)
        {
            return DataAccessProvider.DBAccessor.GetImageFields(docId);
        }

        public bool ApplyImageToPattern(int imageId, string pattern)
        {
            return DataAccessProvider.DBAccessor.ApplyImageToPattern(imageId, pattern);
        }

        public bool AttachFieldToImage(int imageId, string field, string value)
        {
            return DataAccessProvider.DBAccessor.AttachFieldToImage(imageId, field, value);
        }

        public bool MoveImageToCheck(int imageId)
        {
            return DataAccessProvider.DBAccessor.MoveImageToCheck(imageId);
        }

        public IEnumerable<Field> GetFirstImageFieldsForCheck(int checkerId)
        {
            return DataAccessProvider.DBAccessor.GetFirstImageFieldsForCheck(checkerId);
        }

        public int GetImageIdForCheck(int checkerId)
        {
            return DataAccessProvider.DBAccessor.GetImageIdForCheck(checkerId);
        }

        public bool SetVerdictForImage(int imageId, int checkerId, int verdict)
        {
            return DataAccessProvider.DBAccessor.SetVerdictForImage(imageId, checkerId, verdict);
        }

        public bool RemoveDocument(int docId)
        {
            return DataAccessProvider.DBAccessor.RemoveDocument(docId);
        }
    }
}