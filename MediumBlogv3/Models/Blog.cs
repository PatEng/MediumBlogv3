using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediumBlogv3.Models
{
    public class Blog
    {

        [Required]
        [Display(Name="Blog")]
        public int BlogID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}