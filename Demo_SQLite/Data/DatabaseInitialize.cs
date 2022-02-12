using Demo_SQLite.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SQLite.Data
{
    class DatabaseInitialize
    {
        private DateTime date;

        public static bool CreateTables() {
           var conn = new SQLiteConnection("sqlitepcldemo.db");
            string sql = @"CREATE TABLE IF NOT EXISTS
                        PersonalTransaction (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                        Name VARCHAR( 140 ),
                        Description TEXT,
                        Detail TEXT,
                        Money DOUBLE,
                        CreatedDate DATETIME,
                        Category INT
                        );";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }
        public static bool SaveTables(PersonalTransaction personal)
        {
            var conn = new SQLiteConnection("sqlitepcldemo.db");
            using(var personalTransaction = conn.Prepare("INSERT INTO PersonalTransaction(Name, Description, Detail, Money, CreatedDate, Category) VALUES (?, ?, ?, ?, ?, ?)"))
            {
                personalTransaction.Bind(1, personal.Name);
                personalTransaction.Bind(2, personal.Description);
                personalTransaction.Bind(3, personal.Detail);
                personalTransaction.Bind(4, personal.Money);
                personalTransaction.Bind(5, personal.CreatedDate.ToString("yyyy-MM-dd"));
                personalTransaction.Bind(6, personal.Category);
                personalTransaction.Step();
            }
            return true;
        }
        public static List<PersonalTransaction> FindAll()
        {
            List<PersonalTransaction> list = new List<PersonalTransaction>();
            var conn = new SQLiteConnection("sqlitepcldemo.db");
            using (var personalTransaction = conn.Prepare("select * from PersonalTransaction"))
            {
                
               while(personalTransaction.Step() == SQLiteResult.ROW)
                {

                    PersonalTransaction personal = new PersonalTransaction()
                    {
                        Name = (string)personalTransaction["Name"],
                        Description = (string)personalTransaction["Description"],
                        Detail = (string)personalTransaction["Detail"],
                        Money = (double)personalTransaction["Money"]
                    };
                    var date = (string)personalTransaction["CreatedDate"];
                    var category = (Int64)personalTransaction["Category"];
                    personal.CreatedDate = DateTime.Parse(date);
                    personal.Category = (int)category;
                    list.Add(personal);
                }
                return list;
            }
        }
    }
}
