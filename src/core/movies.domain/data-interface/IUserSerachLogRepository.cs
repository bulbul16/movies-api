using movies.domain.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.domain.data_interface
{
    public interface IUserSerachLogRepository
    {
        UserSearchLog SaveAsync(UserSearchLog userServiceLog);
        List<UserSearchLog> GetAllAsync();
    }
}
