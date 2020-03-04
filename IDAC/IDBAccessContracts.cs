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
        int CreateDocument(string name, string project, string comment);
        bool AttachImageToDocument(int docId, byte[] image);
    }
}
