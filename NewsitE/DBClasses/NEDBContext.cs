using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsitE.DBClasses
{
    public class NEDBContext : DbContext
    {
        public NEDBContext() : base("NewsitEDB") { }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Log> LogEntries { get; set; }
    }
}