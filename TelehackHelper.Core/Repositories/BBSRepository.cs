using System.Data;
using log4net;
using TelehackHelper.Core.Entities;

namespace TelehackHelper.Core.Repositories
{
    public class BBSRepository : BaseRepository<BBS>
    {
        
        public BBSRepository(string filePath)
            : base(filePath)
        {
            Log = LogManager.GetLogger("TelehackHelper.Core.Repositories.BBSRepository");
            InitializeDb();
        }

        protected override void CreateSchemaIfNotExists(IDbCommand command)
        {
            //string query = "CREATE TABLE IF NOT EXISTS `BBS` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` VARCHAR, `AreaCodeId` INTEGER NOT NULL REFERENCES AreaCode(Id), `Number` VARCHAR ( 8 ) NOT NULL, `SysOP` INTEGER NOT NULL DEFAULT ( 0 ), CONSTRAINT `AreaCodeId` FOREIGN KEY(`Id`) REFERENCES `AreaCode` );"; 
            string query = "CREATE TABLE IF NOT EXISTS `BBS` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` VARCHAR, `AreaCode` VARCHAR ( 3 ) NOT NULL, `Number` VARCHAR ( 8 ) NOT NULL, `SysOP` INTEGER NOT NULL DEFAULT ( 0 ), UNIQUE (`AreaCode`, `Number`) );";
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        protected override void InsertDefaultValuesIfNotExists(IDbCommand command) { }

        public void Exists() => ExecuteWithConnectionInsideTransaction((connection, command) =>
        {

        });

        public override void Insert(BBS bbs) { }

        public override void Update(int id, BBS bbs)
        {
            throw new System.NotImplementedException();
        }


        public override void Delete(BBS bbs)
        {
            throw new System.NotImplementedException();
        }
    }
}
