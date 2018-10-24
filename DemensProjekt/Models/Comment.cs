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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long CommentId { get; set; }       

        public DateTime Posted { get; set; }

        public string Author { get; set; }

        [Required]
        [MinLength(1)]
        public string Body { get; set; }

        public long PostId { get; set; }
    }    
}
