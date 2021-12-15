using movies.domain.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.domain.service_interface
{
    public interface IUserService
    {
        List<User> GetAllAsync();
        User GetByIdAsync(int id);
    }
}
