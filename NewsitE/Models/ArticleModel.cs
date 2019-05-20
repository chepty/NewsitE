using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsitE.Models
{
    public class ArticleModel
    {

        public Guid ID { get; set; }

        [Required(ErrorMessage = "Title can not be empty!", AllowEmptyStrings = false)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Article can not be empty!", AllowEmptyStrings = false)]
        [Display(Name = "Article")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Author can not be empty!", AllowEmptyStrings = false)]
        [Display(Name = "Every hero needs a name.Who are you?")]
        public string Author { get; set; }

        public DateTime CreationTimestamp { get; set; }
        public string Editor { get; set; }
        public DateTime? EditTimestamp { get; set; }
        public bool Active { get; set; }

    }
}