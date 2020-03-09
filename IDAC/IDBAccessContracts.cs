using RWPictures.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.IDAC
{
    public interface IDBAccessContracts
    {
        IEnumerable<DocumentInfo> GetDocumentsInfo();
        IEnumerable<string> GetAllProjects();
        IEnumerable<string> GetAllPatterns();
        Dictionary<int, string> GetPatternFields(string pattern);
        int CreateDocument(string name, string project, string comment, string pattern);
        bool AttachImageToDocument(int docId, byte[] image);
        bool AddFieldToPattern(string pattern, string fieldName);
        bool RemovePatternField(string pattern, int fieldId);
        bool RemovePattern(string pattern);
        User GetUserByLoginAndPass(string login, string pass);
        bool AddUser(string login, string password, string fname, string lname, string patronymic);
        LinkImageDoc GetImageIdForWork(int user_id);
        byte[] GetImageById(int imageId);
        IEnumerable<string> GetImageFields(int docId);
        bool ApplyImageToPattern(int imageId, string pattern);
        bool AttachFieldToImage(int imageId, string field, string value);
        bool MoveImageToCheck(int imageId);
        IEnumerable<Field> GetFirstImageFieldsForCheck(int checkerId);
        int GetImageIdForCheck(int checkerId);

        bool SetVerdictForImage(int imageId, int checkerId, int verdict);
    }
}