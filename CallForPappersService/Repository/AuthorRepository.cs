using CallForPappersService.Data;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AuthorExistsAsync(Guid authorId)
        {
            return await _context.Authors.AnyAsync(a => a.Id == authorId);
        }
    }
}
