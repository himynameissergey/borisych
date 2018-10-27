using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore.Porn   //будем брать NSFW с reddit.com
{
    class PornParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            //var list = new List<string>();
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));  //habr
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("text"));    //nekdo
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("orange")).OfType<IHtmlAnchorElement>(); //2ch
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("b-list-item__link")).OfType<IHtmlAnchorElement>(); //lenta.ru
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("story__title-link")).OfType<IHtmlAnchorElement>(); //pikabu
            //var items = document.All.Where(item => item.LocalName != null && item.LocalName.Contains("img")).OfType<IHtmlImageElement>(); //stavklass, pornpics
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName == "thumb_container").Select(x => x.Attributes["data-previewvideo"].Value); //xhamster
            //var items = document.QuerySelectorAll("video").Where(item => item.ClassName == "gifVideo js-gifVideo").Select(x => x.Attributes["data-mp4"].Value); //pornhub
            //var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"].Value.Contains("gfycatporn.com/oilporn")).Select(x => x.Attributes["href"].Value); //gfycatporn
            //foreach (var item in items)
            //{
                //if (item.Source.Length < 100)
                //{
                //    list.Add(item.Source); //stavklass, pornpics
                //}
             //   list.Add(item); //xhamster
                //list.Add(item.TextContent); //habr, nekdo
                //list.Add("https://2ch.hk" + item.PathName);   //2ch
                //list.Add("https://m.lenta.ru" + item.PathName);	//lenta.ru
                //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
            //}
            
            List<string> reddit_uri = new List<string>();   //список uri на NSFW видео
            //string giant = "";
            var reddit = new RedditSharp.Reddit();
            List<string> lines = ReadingTextFile.GetLinesOfTextFile();     //читаем из файла логин и пароль для reddit.com (безопасность, блеать :))
            var user = reddit.LogIn(lines[3], lines[4]);
            //var subreddit = reddit.GetSubreddit("/r/60fpsporn");
            var subreddit = reddit.GetSubreddit("/r/NSFW_GIF");

            foreach (var post in subreddit.Hot.Take(50))
            {
                //if (post.Url.AbsoluteUri.Contains("imgur"))
                //{
                    reddit_uri.Add(post.Url.AbsoluteUri);
                //}
                //if (post.Url.AbsoluteUri.Contains("gfycat"))
                //{
                //    giant = post.Url.AbsoluteUri.Insert(8, "giant.");
                //    reddit_uri.Add(giant + ".mp4");
                //}
            }
            return reddit_uri.ToArray();
        }
    }
}

//AngleSharp example
//var links= document.QuerySelectorAll("a.object-title-a.text-truncate").Where(item => item.Attributes["href"]!=null).Select(x=>x.item.Atributtes["href"].Value).ToList();