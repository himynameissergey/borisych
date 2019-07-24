using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore.Reddit
{
    class RedditParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            //var list = new List<string>();
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));  //habr
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("text"));    //nekdo
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("orange")).OfType<IHtmlAnchorElement>(); //2ch
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("b-list-item__link")).OfType<IHtmlAnchorElement>(); //lenta.ru
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("story__title-link")).OfType<IHtmlAnchorElement>(); //pikabu
            //var items = document.All.Where(item => item.LocalName != null && item.LocalName.Contains("img")).OfType<IHtmlImageElement>(); //stavklass
            //var items = document.QuerySelectorAll("p").Where(item => item.ClassName != null && item.ClassName.Contains("title")).OfType<IHtmlAnchorElement>(); //reddit
            //var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"]!=null && item.Attributes["href"].Value.Contains("gifv"));//.Select(x => x.Attributes["href"].Value); //reddit еще

            //foreach (var item in items)
            //{
            //    //list.Add(item.TextContent); //habr, nekdo
            //    //list.Add(item.Source); //stavklass, pornpics
            //    //list.Add("https://2ch.hk" + item.PathName);   //2ch
            //    //list.Add("https://m.lenta.ru" + item.PathName);	//lenta.ru
            //    //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
            //    //list.Add(item.Attributes["href"].Value.Replace("gifv", "mp4"));	//reddit
            //    list.Add(item.Attributes["href"].Value);
            //}
            //return list.ToArray();

            List<string> reddit_uri = new List<string>();   //список uri на mp4 и gif

            var reddit = new RedditSharp.Reddit();
            List<string> lines = ReadingTextFile.GetLinesOfTextFile();     //читаем из файла логин и пароль для reddit.com (безопасность, блеать :))
            var user = reddit.LogIn(lines[3], lines[4]);
            //var subreddit = reddit.GetSubreddit("/r/60fpsporn");
            var subreddit = reddit.GetSubreddit("/r/gifs");

            foreach (var post in subreddit.Hot.Take(50))
            {
                if (post.Url.AbsoluteUri.Contains(".gif"))
                {
                    if (post.Url.AbsoluteUri.Contains(".gifv"))
                    {
                        reddit_uri.Add(post.Url.AbsoluteUri.Replace("gifv", "mp4"));
                        continue;
                    }
                    reddit_uri.Add(post.Url.AbsoluteUri);
                }
            }
            return reddit_uri.ToArray();
        }
    }
}

//AngleSharp example
//var links= document.QuerySelectorAll("a.object-title-a.text-truncate").Where(item => item.Attributes["href"]!=null).Select(x=>x.item.Atributtes["href"].Value).ToList();