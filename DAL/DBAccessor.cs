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

        public bool AttachImageToDocument(int docId, byte[] image)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AttachImageToDocument", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@doc_id", docId);
                command.Parameters.AddWithValue("@image", image);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public int CreateDocument(string name, string project, string comment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateDocument", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@project", project);
                command.Parameters.AddWithValue("@comment", comment);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return (int)reader["Id"];
                }

                return 0;
            }
        }

        public IEnumerable<string> GetAllProjects()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllProjects", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> projects = new List<string>();
                while (reader.Read())
                {
                    projects.Add((string)reader["Project"]);
                }

                return projects;
            }
        }

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
