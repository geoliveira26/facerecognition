using Emgu.CV;
using Emgu.CV.Structure;
using facerecognition.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='photo_user' and xtype='U')
                CREATE TABLE photo_user
                (
                    id int not null identity(1, 1) primary key,
		            name varchar(250) not null
                )
           ");

            ExecuteScalar(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='photo' and xtype='U')
                CREATE TABLE photo
                (
                    id int not null identity(1, 1) primary key,
		            user_id int not null,
                    photo varbinary(max),
                    foreign key (user_id) references photo_user(id)
                )
           ");
        }

        public static List<User> RetrieveUsers()
        {
            var users = new List<User>();

            var command = @"
               select u.id as user_id, u.name as user_name, p.photo as photo
               from photo_user u inner join photo p on u.id = p.user_id
            ";
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(command, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                User user;
                if(!users.Any(u => u.Id == (int)dr["user_id"]))
                {
                    user = new User((int)dr["user_id"], (string)dr["user_name"]);
                    users.Add(user);
                }
                else
                {
                    user = users.First(u => u.Id == (int)dr["user_id"]);
                }

                var arr = (byte[])dr["photo"];
                var image = new Image<Gray, byte>(200, 200);
                image.Bytes = arr;
                user.Photos.Add(image);
            }

            return users;
        }

        public static void InsertPhoto(int userId, Image<Gray, byte> image)
        {
            var resized = image.Resize(200, 200, Emgu.CV.CvEnum.Inter.Cubic);
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();
                using (var comm = new SqlCommand($"insert into photo values({userId}, @binary)", connection))
                {
                    comm.Parameters.Add("@binary", SqlDbType.VarBinary, resized.Bytes.Length).Value = resized.Bytes;
                    comm.ExecuteNonQuery();
                }
            }
        }

        public static void InsertUser(User user)
        {
            var id = (int)ExecuteScalar($@"
                insert into photo_user(name)
                output inserted.id
                values('{user.Name}')
            ");

            user.Photos.ForEach(i => InsertPhoto(id, i));
        }
    }
}