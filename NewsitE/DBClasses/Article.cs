using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsitE.DBClasses
{
    [Table("Article")]
    public class Article
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime CreationTimestamp { get; set; }
        public string Editor { get; set; }
        public DateTime? EditTimestamp { get; set; }
        public bool Active { get; set; }


        public virtual ICollection<Log> LogEntries { get; set; }
    }
}