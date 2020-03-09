using RWPictures.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.IBLC
{
    public interface ILogicContracts
    {
        byte[] GetImageFromFile(string filePath);
        IEnumerable<DocumentInfo> GetDocumentsInfo();
        IEnumerable<string> GetAllProjects();
        IEnumerable<string> GetAllPatterns();
        Dictionary<int, string> GetPatternFields(string pattern);
        bool AddFieldToPattern(string pattern, string fieldName);
        bool RemovePatternField(string pattern, int fieldId);
        bool GenerateDocument(string name, string project, string comment, string pattern, IEnumerable<byte[]> images);
        bool RemovePattern(string pattern);
        string GetMd5Hash(string input);
        User GetUserByLoginAndPass(string login, string password);
        bool AddUser(string login, string password, string fname, string lname, string patronymic);
        LinkImageDoc GetImageIdForWork(int user_id);
        byte[] GetImageById(int imageId);
        IEnumerable<string> GetImageFields(int docId);
        bool ApplyImageToPattern(int imageId, string pattern);
        bool AttachFieldToImage(int imageId, string field, string value);
        bool MoveImageToCheck(int imageId);
        IEnumerable<Field> GetFirstImageFieldsForCheck(int checkerId);
        int GetImageIdForCheck(int checkerId);
    }
}
