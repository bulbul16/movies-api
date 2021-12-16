using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using movies.api.Models.Search;
using movies.domain.app_setting;
using movies.domain.enums;
using movies.domain.service_interface;
using movies.domain.view_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace movies.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieDBInfo _movieDBInfo;
        private IUserSearchLogService _userSearchLogService;
        private IHttpClientService _httpClientService;
        public MovieController(IOptions<MovieDBInfo> movieInfo, IUserSearchLogService userSearchLogService, IHttpClientService httpClientService)
        {
            _movieDBInfo = movieInfo.Value;
            _userSearchLogService = userSearchLogService;
            _httpClientService = httpClientService;
        }

        [HttpPost]
        public async Task<string> Search(SearchParameter searchParameter)
        {
            try
            {
                var searchResult = string.Empty;

                var url = GenerateUrl(searchParameter);

                List<domain.models.UserSearchLog> userSearchLogList = _userSearchLogService.GetAllAsync().Where(c => c.RequestUrl == url && c.UserId == searchParameter.UserId).ToList();

                if (userSearchLogList.Count > 0)
                {
                    searchResult = userSearchLogList[0].SearchResult;
                }
                else
                {
                    searchResult = await _httpClientService.GetAsync(url);
                    _userSearchLogService.SaveAsync(searchResult, searchParameter.Query, searchParameter.UserId, SearchType.Movie.ToString(), url);
                }
                return searchResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("{id}")]
        public async Task<string> SearchById(int id, [FromBody] DetailSearchParameter searchParameter)
        {
            try
            {
                var searchResult = string.Empty;

                var url = GenerateUrlForMovieDetail(id, searchParameter);

                List<domain.models.UserSearchLog> userSearchLogList = _userSearchLogService.GetAllAsync().Where(c => c.RequestUrl == url && c.UserId == searchParameter.UserId).ToList();

                if (userSearchLogList.Count > 0)
                {
                    searchResult = userSearchLogList[0].SearchResult;
                }
                else
                {
                    searchResult = await _httpClientService.GetAsync(url);
                    _userSearchLogService.SaveAsync(searchResult, id.ToString(), searchParameter.UserId, SearchType.Movie.ToString(), url);
                }

                return searchResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GenerateUrl(SearchParameter searchParameter)
        {
            var url = string.Empty;
            if (searchParameter.Language == string.Empty)
                searchParameter.Language = "en-US";
            if (searchParameter.Page == 0)
                searchParameter.Page = 1;
            if (!searchParameter.Include_Adult.Value)
                searchParameter.Include_Adult = true;

            url = _movieDBInfo.MovieApiAccessPoint + $"?api_key={_movieDBInfo.Api_Key}&language={searchParameter.Language}&page={searchParameter.Page}&include_adult={searchParameter.Include_Adult}&query={searchParameter.Query}";
            return url;
        }

        private string GenerateUrlForMovieDetail(int movieId, DetailSearchParameter searchParameter)
        {
            var url = string.Empty;
            if (searchParameter.Language == string.Empty)
                searchParameter.Language = "en-US";

            url = _movieDBInfo.MovieDetailApiAccessPoint + movieId + $"?api_key={_movieDBInfo.Api_Key}&language={searchParameter.Language}";
            return url;
        }
    }
}

