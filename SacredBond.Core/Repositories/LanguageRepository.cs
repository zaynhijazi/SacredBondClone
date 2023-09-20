using SacredBond.Common.Enums;
using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Repositories
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface ILanguageRepository : IBaseRepository<Language>
    {

    }
}
