using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Repositories
{
    public class ProfileMatchStatusChangeRepository : BaseRepository<ProfileMatchStatusChange>, IProfileMatchStatusChangeRepository
    {
        public ProfileMatchStatusChangeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IProfileMatchStatusChangeRepository : IBaseRepository<ProfileMatchStatusChange>
    {

    }
}