using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsitE.DBClasses
{
    public class DBInitiator
    {
        public static void Initiator()
        {
            var art1Guid = Guid.NewGuid();
            var art2Guid = Guid.NewGuid();
            var art3Guid = Guid.NewGuid();

            var article1 = new Article
            {
                ID = art1Guid,
                Title = "Look, up in the sky! It's a Bird! It's a Plane!",
                Body = "It's Superman!",
                Author = "Witness",
                CreationTimestamp = Convert.ToDateTime("18.04.1938"),
                Editor = null,
                EditTimestamp = null
            };

            var article2 = new Article
            {
                ID = art2Guid,
                Title = "He's the Night!",
                Body = "He's Batman!",
                Author = "Witness",
                CreationTimestamp = Convert.ToDateTime("01.05.1939"),
                Editor = null,
                EditTimestamp = null
            };

            var article3 = new Article
            {
                ID = art3Guid,
                Title = "The fastest man alive is here!",
                Body = "Flash!",
                Author = "Witness",
                CreationTimestamp = Convert.ToDateTime("01.01.1940"),
                Editor = null,
                EditTimestamp = null
            };

            var log1 = new Log
            {
                ArticleID = art1Guid,
                Title = "Look, up in the sky! It's a Bird! It's a Plane!",
                Body = "It's Superman!",
                Author = "Witness",
                Action = "Generated",
                Timestamp = Convert.ToDateTime("18.04.1938")
            };

            var log2 = new Log
            {
                ArticleID = art2Guid,
                Title = "He's the Night!",
                Body = "He's Batman!",
                Author = "Witness",
                Action = "Generated",
                Timestamp = Convert.ToDateTime("01.05.1939")
            };

            var log3 = new Log
            {
                ArticleID = art3Guid,
                Title = "The fastest man alive is here!",
                Body = "Flash!",
                Author = "Witness",
                Action = "Generated",
                Timestamp = Convert.ToDateTime("01.01.1940")
            };

            DBWriter.writeArticle(article1);
            DBWriter.writeLog(log1);

            DBWriter.writeArticle(article2);
            DBWriter.writeLog(log2);

            DBWriter.writeArticle(article3);
            DBWriter.writeLog(log3);
        }
    }
}

