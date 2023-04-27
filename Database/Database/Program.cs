using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.Connect();
            Console.WriteLine("connected");

            Console.WriteLine(Database.GetIDSchool("HAK"));
            Database.InsertSchool("Bafep");
            Database.UpdateSchool(Database.GetIDSchool("AHS"), "Gymnasium");
            Database.DeleteSchool(Database.GetIDSchool("HAK"));

            foreach(int i in Database.GetSchools())
            {
                Console.WriteLine(i + " " + Database.GetSchoolDesc(i));
            }
        }
    }
}
