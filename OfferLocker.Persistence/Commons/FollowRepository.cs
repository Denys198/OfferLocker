using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons
{
    public interface IFollowRepository : IRepository<Follow>
    {
    }

    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        private readonly OffersContext _context;
        public FollowRepository(OffersContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
