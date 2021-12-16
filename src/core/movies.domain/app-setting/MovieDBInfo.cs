using System;
using System.Collections.Generic;
using System.Text;

namespace movies.domain.app_setting
{
    public class MovieDBInfo
    {
        public string MovieApiAccessPoint { get; set; }
        public string PersonApiAccessPoint { get; set; }
        public string TvShowsApiAccessPoint { get; set; }
        public string Api_Key { get; set; }
        public string MovieDetailApiAccessPoint { get; set; }
        public string PersonDetailApiAccessPoint { get; set; }
        public string TvShowsDetailApiAccessPoint { get; set; }
    }
}
