using System.Data;
using System.Data.SQLite;
using log4net;

namespace TelehackHelper.Core
{
    public class Database
    {
        private readonly ILog Log;

        private SQLiteConnection _db;

        public SQLiteConnection Connection
        {
            get
            {
                if (_db == null)
                {
                    Log.Info("Opening SQLite database");
                    _db = new SQLiteConnection("TelehackHelper.db");
                }
                return _db;
            }
        }

        public Database()
        {
            Log = LogManager.GetLogger("TelehackHelper.Core.Database");

            //Log.Info("Starting database transaction");

            //    Log.Info("Creating AreaCode table if it doesn't exists");
            //    Connection.Execute("CREATE TABLE IF NOT EXISTS `AreaCode` ( `Id` integer NOT NULL PRIMARY KEY AUTOINCREMENT, `State` varchar NOT NULL, `Code` integer NOT NULL UNIQUE );");
            //    Log.Info("Creating BBS table if it doesn't exists");
            //    //Connection.Execute("CREATE TABLE IF NOT EXISTS `BBS` ( `Id` integer NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` varchar, `AreaCodeId` integer NOT NULL, `Number` varchar ( 8 ) NOT NULL, `SysOP`	integer NOT NULL DEFAULT 0, CONSTRAINT `AreaCodeId` FOREIGN KEY(`Id`) REFERENCES `AreaCode` );");
            //    Connection.Execute("CREATE TABLE IF NOT EXISTS `BBS` ( `Id` integer NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` varchar NOT NULL UNIQUE, `AreaCode` varchar ( 3 ) NOT NULL, `Number` varchar ( 8 ) NOT NULL UNIQUE, `SysOP` integer NOT NULL DEFAULT 0);");
            //    Log.Info("Creating OS table if it doesn't exists");
            //    Connection.Execute("CREATE TABLE IF NOT EXISTS `OS` (`Name` varchar ( 6 ) PRIMARY KEY NOT NULL UNIQUE);");

            //Connection.RunInTransaction(() =>
            //{
            //    Log.Info("Inserting default values into table AreaCode");
            //    AreaCode.AreaCodes.ForEach((AreaCode ac) =>
            //    {
            //        if (Connection.Query(Connection.GetMapping(typeof(AreaCode)), "SELECT * FROM AreaCode WHERE State=? AND Code=?;", ac.State, ac.Code).Count == 0)
            //        {
            //            try
            //            {
            //                Connection.Execute($"INSERT INTO `AreaCode`(State, Code) VALUES ('{ac.State}', '{ac.Code}');");
            //            }
            //            catch (Exception ex)
            //            {
            //                Log.Error(ex);
            //            }
            //        }
            //    });

            //    Log.Info("Inserting default values into table OS");
            //    OS.OSList.ForEach((OS os) =>
            //    {
            //        if (Connection.Query(Connection.GetMapping(typeof(OS)), "SELECT * FROM OS WHERE Name=?;", os.Name).Count == 0)
            //        {
            //            try
            //            {
            //                Connection.Execute($"INSERT INTO `OS`(Name) VALUES ('{os.Name}');");
            //            }
            //            catch (Exception ex)
            //            {
            //                Log.Error(ex);
            //            }
            //        }
            //    });
            //});

            //OS os = Connection.Get<OS>("AIX");
            //Connection.Query("SELECT * FROM `OS` WHERE Name=AIX;");
        }
    }
}
