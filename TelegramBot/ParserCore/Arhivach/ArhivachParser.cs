using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore.Arhivach
{
    class ArhivachParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));  //habr
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("text"));    //nekdo
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("orange")).OfType<IHtmlAnchorElement>(); //2ch
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("b-list-item__link")).OfType<IHtmlAnchorElement>(); //lenta.ru
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("story__title-link")).OfType<IHtmlAnchorElement>(); //pikabu
            //var items = document.All.Where(item => item.LocalName != null && item.LocalName.Contains("img")).OfType<IHtmlImageElement>(); //stavklass
            //var items = document.QuerySelectorAll("a")/*.Where(item => item.Style == null && item.ClassName.Contains("thread_text"))*/.OfType<IHtmlAnchorElement>(); //arhivach
            var items = document.QuerySelectorAll("a").Where(item => item.Attributes["style"] != null).Select(x => x.Attributes["href"].Value); //arhivach еще
            foreach (var item in items)
            {
                //list.Add(item.TextContent); //habr, nekdo
                //list.Add(item.Source); //stavklass, pornpics
                //list.Add("https://2ch.hk" + item.PathName);   //2ch
                //list.Add("https://m.lenta.ru" + item.PathName);	//lenta.ru
                //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
                if (item.Contains("/thread/"))
                {
                    list.Add("http://arhivach.ng" + item);    //arhivach
                }
            }
            return list.ToArray();
        }
    }
}

//AngleSharp example
//var links= document.QuerySelectorAll("a.object-title-a.text-truncate").Where(item => item.Attributes["href"]!=null).Select(x=>x.item.Atributtes["href"].Value).ToList();