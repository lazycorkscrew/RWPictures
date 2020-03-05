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
        bool RemovePatternField(string pattern, int fieldId);
        bool AddFieldToPattern(string pattern, string fieldName);
    }
}
