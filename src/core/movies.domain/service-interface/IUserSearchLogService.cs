using movies.domain.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.domain.service_interface
{
    public interface IUserSearchLogService
    {
        UserSearchLog SaveAsync(UserSearchLog userServiceLog);
        List<UserSearchLog> GetAllAsync();
    }
}
