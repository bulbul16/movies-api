using movies.data.dbContext;
using movies.domain.data_interface;
using movies.domain.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace movies.data
{
    public class UserRepository : IUserRepository
    {
        private MovieDBContext _context;
        public UserRepository(MovieDBContext context)
        {
            _context = context;
        }
        public List<User> GetAllAsync()
        {
            return _context.Users.ToList();
        }

        public User GetByIdAsync(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
