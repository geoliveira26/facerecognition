using Emgu.CV;
using Emgu.CV.Structure;
using facerecognition.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace facerecognition
{
    public static class Connection
    {
        private static object ExecuteScalar(string command)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();
                using (var comm = new SqlCommand(command, connection))
                    return comm.ExecuteScalar();
            }
        }

        public static void ConfigureDatabase()
        {
            ExecuteScalar(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='user_face' and xtype='U')
                CREATE TABLE user_face
                (

                    id int not null identity(1, 1) primary key,
		            name varchar(250) not null,
                    face varbinary(max) not null,
                    access int not null
                )
           ");
        }

        public static List<User> RetrieveUsers()
        {
            var users = new List<User>();

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            var cmd = new SqlCommand("select * from user_face", connection);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var user = new User((int)dr["id"], (string)dr["name"], null, (AccessLevel)dr["access"]);
                users.Add(user);
                var arr = (byte[])dr["face"];
                var image = new Image<Gray, byte>(100, 100);
                image.Bytes = arr;
                user.Face = image;
            }

            return users;
        }

        public static void InsertUser(User user)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();
                using (var comm = new SqlCommand($"insert into user_face(name, access, face) values('{user.Name}', {(int)user.Access}, @binary)", connection))
                {
                    comm.Parameters.Add("@binary", SqlDbType.VarBinary, user.Face.Bytes.Length).Value = user.Face.Bytes;
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}