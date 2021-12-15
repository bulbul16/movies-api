using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.api.Models.Search
{
    public class MovieSearchParameter
    {
        
        public int UserId { get; set; }
        public string SearhText { get; set; }

        //public string api_key { get; set; }
        //public string language { get; set; }
        //public string query { get; set; }
        //public int? page { get; set; }
        //public bool? include_adult { get; set; }
        //public string region { get; set; }
        //public int year { get; set; }
        //public int primary_release_year { get; set; }
    }
}
