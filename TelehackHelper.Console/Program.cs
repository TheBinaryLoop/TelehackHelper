using System.Data.SQLite;
using System.Text.RegularExpressions;
using TelehackHelper.Core.Repositories;
using CL = System.Console;

namespace TelehackHelper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CL.Write("Creating database...");
            BBSRepository bbsRepository = new BBSRepository("TelehackHelper.db");
            CL.WriteLine("Done");

            Regex bbsPattern = new Regex(@"^(?'bbs_name'.*) \.* (\(|)(?'area_code'\d{3})(\) |-| |)(?'phone_number'\d{3}(-|)\d{4})$", RegexOptions.Multiline);

            bool running = true;

            while (running)
            {
                CL.Write("BBS Line: ");
                string bbsLine = CL.ReadLine();
                if (bbsLine == "exit" || bbsLine == "quit" || bbsLine == "q")
                {
                    running = false;
                    continue;
                }
                GroupCollection groups = bbsPattern.Match(bbsLine).Groups;
                CL.WriteLine($"BBS Name: {groups["bbs_name"].Value}");
                CL.WriteLine($"BBS Area Code: {groups["area_code"].Value}");
                CL.WriteLine($"BBS Number: {groups["phone_number"].Value}");
                bbsRepository.ExecuteWithConnection(connection =>
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT OR IGNORE INTO BBS(Name,AreaCode,Number) VALUES (\"{groups["bbs_name"].Value}\", \"{groups["area_code"].Value}\", \"{groups["phone_number"].Value}\");";
                        CL.WriteLine(command.ExecuteNonQuery());
                    }
                });
            }

        }
    }
}
