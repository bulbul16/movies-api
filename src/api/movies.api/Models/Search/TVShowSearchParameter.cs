using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.api.Models.Search
{
    public class TVShowSearchParameter
    {
        public int UserId { get; set; }
        public string SearhText { get; set; }
    }
}
