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

        public bool AddFieldToPattern(string pattern, string fieldName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddFieldToPattern", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pattern_name", pattern);
                command.Parameters.AddWithValue("@field_name", fieldName);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool AddUser(string login, string password, string fname, string lname, string patronymic)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@patronymic", patronymic);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool ApplyImageToPattern(int imageId, string pattern)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ApplyImageToPattern", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@image_id", imageId);
                command.Parameters.AddWithValue("@pattern", pattern);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool AttachFieldToImage(int imageId, string field, string value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AttachFieldToImage", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@image_id", imageId);
                command.Parameters.AddWithValue("@field_name", field);
                command.Parameters.AddWithValue("@field_value", value);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

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

        public int CreateDocument(string name, string project, string comment, string pattern)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateDocument", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@project", project);
                command.Parameters.AddWithValue("@comment", comment);
                command.Parameters.AddWithValue("@pattern", pattern);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return (int)reader["Id"];
                }

                return 0;
            }
        }

        public IEnumerable<string> GetAllPatterns()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllPatterns", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> projects = new List<string>();
                while (reader.Read())
                {
                    projects.Add((string)reader["PatternName"]);
                }

                return projects;
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

        public IEnumerable<Field> GetFirstImageFieldsForCheck(int checkerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetFirstImageFieldsForCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@checker_id", checkerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Field> fields = new List<Field>();
                while (reader.Read())
                {
                    fields.Add(new Field { Name = (string)reader["field_name"], Value = (string)reader["field_value"] });
                }

                return fields;
            }
        }

        public byte[] GetImageById(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetImageById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@image_id", imageId);
                connection.Open();
                SqlDataReader reader = null;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return (byte[])reader["Image"];
                }

                return null;
            }
        }

        public IEnumerable<string> GetImageFields(int docId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetImageFields", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@doc_id", docId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> fields = new List<string>();
                while (reader.Read())
                {
                    fields.Add((string)reader["FieldName"]);
                }

                return fields;
            }
        }

        public int GetImageIdForCheck(int checkerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetImageIdForCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@checker_id", checkerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    return (int)reader["Id"];
                }

                return 0;
            }
        }

        public LinkImageDoc GetImageIdForWork(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetImageIdForWork", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();
                SqlDataReader reader = null;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new LinkImageDoc { ImageId = (int)reader["id"], DocumentId = (int)reader["doc_id"] };
                }

                return null;
            }
        }

        public Dictionary<int, string> GetPatternFields(string pattern)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetPatternFields", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pattern_name", pattern);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Dictionary<int, string> patterns = new Dictionary<int, string>();
                while (reader.Read())
                {
                    patterns.Add((int)reader["Id"], (string)reader["FieldName"]);
                }

                return patterns;
            }
        }

        public User GetUserByLoginAndPass(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUserByLoginAndPass", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    return null;
                }

                if (reader.Read())
                {
                    return new User
                    {
                        Id = (int)reader["Id"],
                        Fname = (string)reader["Fname"],
                        Lname = (string)reader["Lname"],
                        Patronymic = (string)reader["Patronymic"],
                        Description = reader.IsDBNull(4) ? null : (string)reader["Description"],
                        Rights = (int)reader["Rights"]
                    };
                }

                return null;
            }
        }

        public bool MoveImageToCheck(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("MoveImageToCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@image_id", imageId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool RemovePattern(string pattern)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RemovePattern", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pattern_name", pattern);
                connection.Open();
                bool a = command.ExecuteNonQuery() >= 1;
                return a;
            }
        }

        public bool RemovePatternField(string pattern, int fieldId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RemovePatternField", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pattern_name", pattern);
                command.Parameters.AddWithValue("@field_id", fieldId);
                connection.Open();
                bool a = command.ExecuteNonQuery() == 1;
                return a;
            }
        }

        public bool SetVerdictForImage(int imageId, int checkerId, int verdict)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SetVerdictForImage", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@image_id", imageId);
                command.Parameters.AddWithValue("@checker_id", checkerId);
                command.Parameters.AddWithValue("@verdict", verdict);
                connection.Open();
                return command.ExecuteNonQuery() >= 1;
            }
        }
    }
}