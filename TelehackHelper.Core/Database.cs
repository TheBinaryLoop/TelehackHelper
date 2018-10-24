using System.Linq;
using SQLite;
using TelehackHelper.Core.Entities;

namespace TelehackHelper.Core
{
    public class Database
    {
        private SQLiteConnection _db;

        public SQLiteConnection Connection
        {
            get
            {
                if (_db == null)
                {
                    _db = new SQLiteConnection("TelehackHelper.db");
                }
                return _db;
            }
        }

        public Database()
        {
            Connection.RunInTransaction(() => {
                Connection.Execute("CREATE TABLE IF NOT EXISTS `AreaCode` ( `Id` integer NOT NULL PRIMARY KEY AUTOINCREMENT, `State` varchar NOT NULL, `Code` integer NOT NULL UNIQUE );");
                Connection.Execute("CREATE TABLE IF NOT EXISTS `BBS` ( `Id` integer NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` varchar, `AreaCodeId` integer NOT NULL, `Number` varchar ( 9 ) NOT NULL, `SysOP`	integer NOT NULL DEFAULT 0, CONSTRAINT `AreaCodeId` FOREIGN KEY(`Id`) REFERENCES `AreaCode` );");
            });
            Connection.RunInTransaction(() =>
            {
                AreaCode.AreaCodes.Select(ac => $"INSERT OR IGNORE INTO `AreaCode`(`State`, `Code`) VALUES ('{ac.State}', {ac.Code});").ToList().ForEach((string statement) => {
                    Connection.Execute(statement);
                });
            });
        }
    }
}
