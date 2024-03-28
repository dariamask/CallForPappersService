using CallForPappersService.Data;
using CallForPappersService.Interfaces;
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
        public bool AuthorExists(Guid authorId)
        {
            return false;
        }
    }
}
