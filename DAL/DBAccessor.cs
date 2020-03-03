using RWPictures.Entities;
using RWPictures.IDAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.DAL
{
    public class DBAccessor : IDBAccessContracts
    {
        public static string connectionString = "Data Source=ХИМИК-ПК\\SQLEXPRESS; Initial Catalog=RewritePictures; Integrated Security=True";// False; User Id=; Password=" 

        public IEnumerable<DocumentInfo> GetDocumentsInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetDocumentsInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<DocumentInfo> documentsInfo = new List<DocumentInfo>();
                while (reader.Read())
                {
                    DocumentInfo docInfo = new DocumentInfo();
                    docInfo.Id = (int)reader["Id"];
                    docInfo.Name = (string)reader["Name"];
                    docInfo.Project = reader.IsDBNull(2) ? null : (string)reader["Project"];
                    documentsInfo.Add(docInfo);
                }

                return documentsInfo;
            }
        }
    }
}
