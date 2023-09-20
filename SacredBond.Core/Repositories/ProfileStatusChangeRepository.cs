

using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Repositories
{
    public class ProfileStatusChangeRepository : BaseRepository<ProfileStatusChange>, IProfileStatusChangeRepository
    {
        public ProfileStatusChangeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IProfileStatusChangeRepository : IBaseRepository<ProfileStatusChange>
    {

    }
}