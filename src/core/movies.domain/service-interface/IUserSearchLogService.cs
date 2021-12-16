using movies.api.Models.Search;
using movies.domain.models;
using movies.domain.view_model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.domain.service_interface
{
    public interface IUserSearchLogService
    {
        UserSearchLog SaveAsync(string searchResult, string query, int userId, string SearchType, string url);
        List<UserSearchLog> GetAllAsync();
    }
}
