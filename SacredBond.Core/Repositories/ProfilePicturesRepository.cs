using System;
using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;


namespace SacredBond.Core.Repositories
{
    public class ProfilePicturesRepository : BaseRepository<ProfilePicture>, IProfilePicturesRepository
    {
        public ProfilePicturesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IProfilePicturesRepository : IBaseRepository<ProfilePicture>
    {

    }
}

