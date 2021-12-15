using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using movies.api.Models.Search;
using movies.domain.app_setting;
using movies.domain.service_interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace movies.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private MovieDBInfo _movieDBInfo;
        private IUserSearchLogService _userSearchLogService;

        public PeopleController(IOptions<MovieDBInfo> movieInfo, IUserSearchLogService userSearchLogService)
        {
            _movieDBInfo = movieInfo.Value;
            _userSearchLogService = userSearchLogService;
        }

        [HttpPost]
        public async Task<string> Search(PeopleSearchParameter searchParameter)
        {
            string searchResult = "";
            List<domain.models.UserSearchLog> userSearchLogList = _userSearchLogService.GetAllAsync().Where(c => c.SearchText == searchParameter.SearhText && c.SearchType == "People").ToList();
            if (userSearchLogList.Count > 0)
            {
                searchResult = userSearchLogList[0].SearchResult;
            }
            else
            {
                searchResult = await SearchMoviesByHttpClient(searchParameter);

                var model = new domain.models.UserSearchLog()
                {
                    SearchDate = DateTime.Now,
                    SearchResult = searchResult,
                    SearchText = searchParameter.SearhText,
                    UserId = searchParameter.UserId,
                    SearchType = "People"

                };

                _userSearchLogService.SaveAsync(model);
            }
            return searchResult;
        }

        private async Task<string> SearchMoviesByHttpClient(PeopleSearchParameter searchParameter)
        {
            string url = _movieDBInfo.PersonApiAccessPoint + $"?api_key={_movieDBInfo.Api_Key}&language=en-US&page=1&include_adult=false&query={searchParameter.SearhText}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
