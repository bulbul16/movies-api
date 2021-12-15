using System;
using System.Collections.Generic;
using System.Text;

namespace movies.domain.view_model
{
    public class UserSearchLogViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SearchText { get; set; }
        public string SearchResult { get; set; }
        public DateTime? SearchDate { get; set; }
    }
}
