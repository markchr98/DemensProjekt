using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemensProjekt.Models
{
    public class Post
    {        
        public long PostId { get; set; }

        [Display(Name = "Titel")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 1,
            ErrorMessage = "Titlen skal være mellem 1 til 20 karakterer lang")]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(1,
            ErrorMessage = "Dit opslag skal mindst være 1 karakter lang")]
        public string Body { get; set; }

        public DateTime Posted { get; set; }        

        [ForeignKey("PostId")]
        public ICollection<Comment> Comments { get; set; }     

        public Post()
        {
            this.Comments = new List<Comment>();
        }
    }
}
