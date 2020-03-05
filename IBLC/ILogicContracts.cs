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

    }
}
