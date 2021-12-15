using movies.domain.data_interface;
using movies.domain.models;
using movies.domain.service_interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.service
{
    public class UserSearchLogService : IUserSearchLogService
    {
        private IUserSerachLogRepository _userSearchLogRepository;
        public UserSearchLogService(IUserSerachLogRepository userSearchLogRepository)
        {
            _userSearchLogRepository = userSearchLogRepository;
        }

        public List<UserSearchLog> GetAllAsync()
        {
            return _userSearchLogRepository.GetAllAsync();
        }

        public UserSearchLog SaveAsync(UserSearchLog userServiceLogModel)
        {
            return _userSearchLogRepository.SaveAsync(userServiceLogModel);
        }
    }
}
