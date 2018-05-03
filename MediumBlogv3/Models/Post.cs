using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediumBlogv3.Models
{
    public class Post
    {

        [Required]
        public int PostID { get; set; }

        [Required]
        public Tag Tag { get; set; }

        [Required]
        [Display(Name = "Featured Image URL")]
        public string FeaturedImageURL { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        [Display(Name = "Blog")]
        public int BlogID { get; set; }

        public virtual Blog Blog { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string Date { get; set; }
    }
}