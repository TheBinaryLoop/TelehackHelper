using SQLite;

namespace TelehackHelper.Core.Entities
{
    public class BBS
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [NotNull]
        public int AreaCodeId { get; set; }
        [Unique, MaxLength(9), NotNull]
        public string Number { get; set; }
        public bool SysOP { get; set; } = false;
    }
}
