using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace movies.domain.view_model
{
    public class SearchParameter
    {
        public int UserId { get; set; }
        public string Language { get; set; }
        public int? Page { get; set; }

        [Required]
        public string Query { get; set; }
        public bool? Include_Adult { get; set; }

    }
}
