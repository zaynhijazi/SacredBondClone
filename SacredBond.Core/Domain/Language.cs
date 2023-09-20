namespace SacredBond.Core.Domain
{
    public class Language : EnumEntity
    {
        public virtual ICollection<ProfileLanguage>? ProfileLanguages { get; set; }

    }
}
