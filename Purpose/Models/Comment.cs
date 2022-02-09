using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purpose.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserName { get; set; }
        public DateTime DateTimeComment { get; set; }
        public string CommentText { get; set; }

    }
}
