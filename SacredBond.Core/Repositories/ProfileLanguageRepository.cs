using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Repositories
{
    public class ProfileLanguageRepository : BaseRepository<ProfileLanguage>, IProfileLanguageRepository
    {
        public ProfileLanguageRepository(ApplicationDbContext context) : base(context)
        {
        }

    }

    public interface IProfileLanguageRepository : IBaseRepository<ProfileLanguage>
    {

    }
}
