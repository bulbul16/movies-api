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
    public class UserSearchLogRepository : IUserSerachLogRepository
    {
        private MovieDBContext _context;

        public UserSearchLogRepository(MovieDBContext context)
        {
            _context = context;
        }

        public List<UserSearchLog> GetAllAsync()
        {
            return _context.UserSearchLogs.ToList();
        }

        public UserSearchLog SaveAsync(UserSearchLog userServiceLog)
        {
            var entity = _context.UserSearchLogs.Add(userServiceLog);
            _context.SaveChanges();
            return userServiceLog;

        }
    }
}
