using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NewsitE.DBClasses
{
    public class DBWriter
    {
        public static bool writeArticle(Article art)
        {
            try
            {
                art.Active = true;
                using (var context = new DBClasses.NEDBContext())
                {
                    var article = (from s in context.Articles
                                   where s.ID.Equals(art.ID)
                                   select s).FirstOrDefault();
                    if (article != null)
                    {
                        article.Title = art.Title;
                        article.Body = art.Body;
                        article.EditTimestamp = DateTime.Now;
                        article.Editor = art.Editor;

                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        context.Articles.Add(art);
                        context.SaveChanges();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                string filePath = @"C:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                return false;
            }
        }

        public static bool DeleteArticle(Guid guid)
        {
            try
            {
                using (var context = new DBClasses.NEDBContext())
                {
                    var article = (from s in context.Articles
                                   where s.ID.Equals(guid)
                                   select s).FirstOrDefault();

                    article.Active = false;

                    var log = new DBClasses.Log { };
                    log.ID = Guid.NewGuid();
                    log.ArticleID = article.ID;
                    log.Author = "Someone very bad";
                    log.Title = article.Title;
                    log.Body = article.Body;
                    log.Timestamp = DateTime.Now;
                    log.Action = "Delete";
                    writeLog(log);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                string filePath = @"C:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                return false;
            }
        }

        public static bool writeLog(Log log)
        {
            try
            {
                using (var context = new DBClasses.NEDBContext())
                {
                    log.ID = Guid.NewGuid();
                    context.LogEntries.Add(log);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                string filePath = @"C:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                return false;
            }
        }

    }
}