namespace TelehackHelper.Core.Entities
{
    public class BBS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AreaCode AreaCode { get; set; }
        public string Number { get; set; }
        public bool SysOP { get; set; } = false;
    }
}
