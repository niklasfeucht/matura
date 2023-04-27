using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetzwerkDB
{
    internal class Database
    {
        private static SqlConnection conn;

        private static readonly string CONN_Server;
        private static readonly string CONN_Database;
        private static readonly string CONN_User;
        private static readonly string CONN_Password;

        static Database()
        {
            string[] parts;
            string line;
            StreamReader sr = new StreamReader("C:\\temp\\config.txt");

            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_Server = parts[1];
            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_Database = parts[1];
            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_User = parts[1];
            line = sr.ReadLine();
            parts = line.Split('=');
            CONN_Password = parts[1];

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
                    "server=" + CONN_Server + ";" +
                    "database=" + CONN_Database + ";" +
                    "MultipleActiveResultSets=True; Integrated Security=True;";

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
            if(conn!=null) conn.Close();
        }

        public static string GetSchoolDesc(int id)
        {
            string result = null;
            SqlDataReader reader;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select \"desc\" from school where id=" + id + ";";

            reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                result = (string)reader["desc"];
            }
            return result;
        }

        public static List<int> GetSchools()
        {
            List<int> result = new List<int>();
            SqlDataReader reader;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select id from school;";

            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                result.Add((int)reader["id"]);
            }
            return result;
        } 

        public static int InsertSchool(string desc)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into school(\"desc\") values ('" + desc + "');";

            return cmd.ExecuteNonQuery();
        }

        public static int UpdateSchool(int id, string desc)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update school set \"desc\"='" + desc + "' where id=" + id + ";";

            return cmd.ExecuteNonQuery();
        }

        public static int DeleteSchool(int id)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "delete teaches where id_school=" + id + "; " +
                                "delete teacher where id_school=" + id + "; " +
                                "delete student where id_school=" + id + "; " +
                                "delete class where id_school=" + id + "; " +
                                "delete school where id=" + id + ";";

            return cmd.ExecuteNonQuery();
        }
    }
}
