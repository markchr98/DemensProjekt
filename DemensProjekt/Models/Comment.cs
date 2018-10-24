using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemensProjekt.Models
{
    public class Comment
    {
        public long CommentId { get; set; }       

        public DateTime Posted { get; set; }

        public string Author { get; set; }

        [Required]
        public string Body { get; set; }

        public long PostId { get; set; }

        
        public Post Post { get; set; }

        public Comment()
        {
            Post = new Post();
        }
    }

    
}
