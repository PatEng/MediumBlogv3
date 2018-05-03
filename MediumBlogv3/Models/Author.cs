using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediumBlogv3.Models
{
    public class Author
    {

        [Required]
        [Display(Name ="Author")]
        public int AuthorID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Email is not valid")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Zip Code")]
        [RegularExpression(@"\d{5}(-\d{4})?$")]
        public string CompanyZip { get; set; }
        
        [Required]
        [Display(Name = "Company City")]
        [StringLength(40, MinimumLength = 2)]
        public string CompanyCity { get; set; }

        [Required]
        [Display(Name = "Company State")]
        [StringLength(20, MinimumLength = 2)]
        public string CompanyState { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}