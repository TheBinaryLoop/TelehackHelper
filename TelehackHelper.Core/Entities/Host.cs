namespace TelehackHelper.Core.Entities
{
    public class Host
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public Types.OS OS{ get; set; }
    }
}
