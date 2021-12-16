using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movies.domain.service_interface
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url);
    }
}
