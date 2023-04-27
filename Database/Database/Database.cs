using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Database
    {
        private static readonly string CONN_SERVER;
        private static readonly string CONN_DATABASE;
        private static readonly string CONN_USER;
        private static readonly string CONN_PASSWORD;

        private static SqlConnection conn;

        static Database()
        {
            string line;
            string[] parts;

            StreamReader sr = new StreamReader("C:\\temp\\config.txt");

            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_SERVER = parts[1];
            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_DATABASE = parts[1];
            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_USER = parts[1];
            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_PASSWORD = parts[1];

            sr.Close();
        }

        private Database()
        {

        }

        private static SqlConnection GetSqlConnection()
        {
            if(conn == null)
            {
                conn = new SqlConnection();
                conn.ConnectionString =
                    "server=" + CONN_SERVER + ";" +
                    "database=" + CONN_DATABASE + ";" +
                    //"user id=" + CONN_USER + ";" +
                    //"password=" + CONN_PASSWORD + "; MultipleActiveResultSets=True";
                    " MultipleActiveResultSets=True; Integrated Security=True;";
            }
            return conn;
        }

        public static SqlConnection Connect()
        {
            GetSqlConnection();
            conn.Open();
            return conn;
        }

        public static void Disconnect()
        {
            if (conn != null) conn.Close();
        }

        public static int GetIDSchool(string description)
        {
            int id = -1;
            SqlDataReader reader;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select id from school where \"desc\"='" + description + "'";

            reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                id = (int)reader["id"];
            }
            reader.Close();
            return id;
        }

        public static List<int> GetSchools() 
        {
            List<int> result = new List<int>();
            SqlDataReader reader;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select id from school;";

            reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                result.Add((int)reader["id"]);
            }
            reader.Close();
            return result;
        }

        public static string GetSchoolDesc(int id)
        {
            string desc = "";
            SqlDataReader reader;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select \"desc\" from school where id=" + id + ";";

            reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                desc = (string)reader["desc"];
            }
            reader.Close();
            return desc;
        }

        public static void InsertSchool(string desc)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Insert into school(\"desc\") values ('" + desc + "');";

            int count = cmd.ExecuteNonQuery();
            Console.WriteLine(count + " rows inserted");
        }

        public static void UpdateSchool(int id, string desc)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update school set \"desc\"='" + desc + "' where id=" + id + ";";

            int count = cmd.ExecuteNonQuery();
            Console.WriteLine(count + " rows updated");
        }

        public static void DeleteSchool(int id)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from teaches where id_school=" + id + ";" +
                                "Delete from teacher where id_school=" + id + ";" +
                                "Delete from student where id_school=" + id + ";" +
                                "Delete from class where id_school=" + id + ";" +
                                "Delete from school where id=" + id + ";";
            
            int count = cmd.ExecuteNonQuery();
            Console.WriteLine(count + " rows deleted");

        }
    }
}
