using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Domain
{
    public class ProfileLanguage
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int LanguageId { get; set; }

        public virtual Profile Profile { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }

}
