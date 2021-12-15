
using movies.domain.data_interface;
using movies.domain.models;
using movies.domain.service_interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public User GetByIdAsync(int id)
        {
            return _userRepository.GetByIdAsync(id);
        }
    }
}
