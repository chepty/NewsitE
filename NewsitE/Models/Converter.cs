using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsitE.Models
{
    public class Converter
    {
        public static Models.ArticleModel ConvertBdModelToArticleModel(DBClasses.Article article)
        {
            var articleModel = new Models.ArticleModel{ };

            articleModel.Active = article.Active;
            articleModel.Author = article.Author;
            articleModel.Body = article.Body;
            articleModel.CreationTimestamp = article.CreationTimestamp;
            articleModel.Editor = article.Editor;
            articleModel.EditTimestamp = article.EditTimestamp;
            articleModel.ID = article.ID;
            articleModel.Title = article.Title;

            return articleModel;
        }

        public static DBClasses.Article ConvertArticleModelToBdModel(Models.ArticleModel article)
        {
            var articleDB = new DBClasses.Article { };

            articleDB.Active = article.Active;
            articleDB.Author = article.Author;
            articleDB.Body = article.Body;
            articleDB.CreationTimestamp = article.CreationTimestamp;
            articleDB.Editor = article.Editor;
            articleDB.EditTimestamp = article.EditTimestamp;
            articleDB.ID = article.ID;
            articleDB.Title = article.Title;

            return articleDB;
        }
    }
}