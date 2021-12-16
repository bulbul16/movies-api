using movies.domain.view_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.api.Models.Search
{
    public class DetailSearchParameter
    {
        public int UserId { get; set; }
        public string Language { get; set; }
        public string Append_To_Response { get; set; }
    }
}
