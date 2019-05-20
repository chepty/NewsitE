using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewsitE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var news = LoadNewsModel();
            return View(news);
        }

        public ActionResult DeleteNew(Guid guid)
        {

            DBClasses.DBWriter.DeleteArticle(guid);
            return RedirectToAction("Index", "Home");
        }

        private Models.NewsModel LoadNewsModel()
        {

            var news = new Models.NewsModel();
            news.articles = new List<Models.ArticleModel> { };
            using (var context = new DBClasses.NEDBContext())
            {

                if (!context.Database.Exists())
                {
                    DBClasses.DBInitiator.Initiator();
                }
                //news.articles
                    
                var list = (from s in context.Articles
                                 where s.Active
                                 orderby s.CreationTimestamp descending
                                 select s).ToList<DBClasses.Article>();
                foreach (var item in list)
                {
                    news.articles.Add(Models.Converter.ConvertBdModelToArticleModel(item));
                }
            }
            foreach (var art in news.articles)
            {
                if (art.Title.Length > 100)
                    art.Title = art.Title.Substring(0, 100) + "...";

                if (art.Body.Length > 200)
                    art.Body = art.Body.Substring(0, 200) + "...";
            }

            return news;
        }

        public ActionResult About()
        {
            ViewBag.Message = "NewsitE team.";

            return View();
        }

        public ActionResult Error(string error)
        {
            
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "NewsitE contact page.";

            return View();
        }


        public ActionResult ViewNew()
        {
            var article = new Models.ArticleModel { };
            var guid = new Guid(Request.Params["guid"]);
            using (var context = new DBClasses.NEDBContext())
            {
                article = Models.Converter.ConvertBdModelToArticleModel((from s in context.Articles
                           where s.ID.Equals(guid)
                           select s).FirstOrDefault());
            }
            return View(article);
        }


        public ActionResult EditNew()
        {

            var article = new Models.ArticleModel { };
            if (Request.Params["guid"] != null)
            {
                var guid = new Guid(Request.Params["guid"]);
                using (var context = new DBClasses.NEDBContext())
                {
                    article = Models.Converter.ConvertBdModelToArticleModel((from s in context.Articles
                                       where s.ID.Equals(guid)
                                       select s).FirstOrDefault());
                }
            }
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNew(Models.ArticleModel u)
        {
            if (ModelState.IsValid)
            {
                if (u.ID.Equals(Guid.Empty))
                {
                    u.ID = Guid.NewGuid();
                    u.Author = u.Author;
                    u.Editor = null;
                    u.CreationTimestamp = DateTime.Now;

                    var log = new DBClasses.Log { };
                    log.ID = Guid.NewGuid();
                    log.ArticleID = u.ID;
                    log.Author = u.Author;
                    log.Body = u.Body;
                    log.Timestamp = u.CreationTimestamp;
                    log.Title = u.Title;
                    log.Action = "Create";

                    DBClasses.DBWriter.writeArticle(Models.Converter.ConvertArticleModelToBdModel(u));
                    DBClasses.DBWriter.writeLog(log);

                    return RedirectToAction("ViewNew", "Home", new { guid = u.ID });
                }
                else
                {
                    var log = new DBClasses.Log { };
                    log.ID = Guid.NewGuid();
                    log.ArticleID = u.ID;
                    log.Author = u.Author;
                    log.Body = u.Body;
                    log.Timestamp = DateTime.Now;
                    log.Title = u.Title;
                    log.Action = "Edit";

                    DBClasses.DBWriter.writeArticle(Models.Converter.ConvertArticleModelToBdModel(u));
                    DBClasses.DBWriter.writeLog(log);

                    return RedirectToAction("ViewNew", "Home", new { guid = u.ID });
                }
            }
            return View(u);
        }
    }


}