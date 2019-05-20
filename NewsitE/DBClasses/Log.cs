using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsitE.DBClasses
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid ArticleID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        [ForeignKey("ArticleID")]
        public virtual Article Article { get; set; }
    }
}