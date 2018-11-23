using inverseyou.infra.PersistStoreModel;
using Microsoft.EntityFrameworkCore;

namespace inverseyou.infra.Repositories
{
    public class EFBaseRepository:DbContext
    {
        public EFBaseRepository(DbContextOptions<EFBaseRepository> options)
            :base(options)
        {
        }

        public DbSet<Inv_User> Inv_User { get; set; }
    }
}
