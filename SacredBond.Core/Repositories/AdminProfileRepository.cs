using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Repositories
{
    public class AdminProfileRepository : BaseRepository<AdminProfile>, IAdminProfileRepository
    {
        public AdminProfileRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }

    public interface IAdminProfileRepository:IBaseRepository<AdminProfile>
    {

    }
}
