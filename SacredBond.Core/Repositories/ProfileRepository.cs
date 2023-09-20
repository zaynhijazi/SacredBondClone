using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IProfileRepository : IBaseRepository<Profile>
    {

    }
}
