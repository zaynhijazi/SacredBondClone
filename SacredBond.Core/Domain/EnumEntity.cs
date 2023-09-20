namespace SacredBond.Core.Domain
{
    public abstract class EnumEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
