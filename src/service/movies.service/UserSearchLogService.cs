using movies.api.Models.Search;
using movies.domain.data_interface;
using movies.domain.models;
using movies.domain.service_interface;
using movies.domain.view_model;
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

        public UserSearchLog SaveAsync(string searchResult, string query, int userId, string SearchType, string url)
        {
            var model = new domain.models.UserSearchLog()
            {
                SearchDate = DateTime.Now,
                SearchResult = searchResult,
                SearchText = query,
                UserId = userId,
                SearchType = SearchType,
                RequestUrl = url
            };

            return _userSearchLogRepository.SaveAsync(model);
        }
    }
}
