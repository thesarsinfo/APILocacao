using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.Repository.Interfaces;

namespace APILocacao.Repository
{

    public class BaseRepository : IBaseRepository
    {

        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task <bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}