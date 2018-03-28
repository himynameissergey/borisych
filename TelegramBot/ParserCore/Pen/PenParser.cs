using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore.Pen
{
    class PenParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));  //habr
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("text"));    //nekdo
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("orange")).OfType<IHtmlAnchorElement>(); //2ch
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("b-list-item__link")).OfType<IHtmlAnchorElement>(); //lenta.ru
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("story__title-link")).OfType<IHtmlAnchorElement>(); //pikabu
            //var items = document.All.Where(item => item.LocalName != null && item.LocalName.Contains("img")).OfType<IHtmlImageElement>(); //stavklass, pornpics
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName == "thumb_container").Select(x => x.Attributes["data-previewvideo"].Value); //xhamster
            //var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"] != null && item.Attributes["href"].Value.Contains("/wall-")).Select(x => x.Attributes["href"].Value.Remove(0, 1)); //vk (Remove(0, 1) - удалим первый символ "/")
            var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"] != null && item.Attributes["rel"] != null && item.Attributes["href"].Value.Contains("http://penitto.ru/?p=")).Select(x => x.Attributes["href"].Value); //penitto.ru
            foreach (var item in items)
            {
                //if (item.Source.Length < 100)
                //{
                //    list.Add(item.Source); //stavklass, pornpics
                //}
                list.Add(item); //xhamster, penitto.ru
                //list.Add(item.TextContent); //habr, nekdo
                //list.Add("https://2ch.hk" + item.PathName);   //2ch
                //list.Add("https://m.lenta.ru" + item.PathName);	//lenta.ru
                //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
                //list.Add("https://vk.com/tip32?w=" + item); //vk
            }
            return list.ToArray();
        }
    }
}

//AngleSharp example
//var links= document.QuerySelectorAll("a.object-title-a.text-truncate").Where(item => item.Attributes["href"]!=null).Select(x=>x.item.Atributtes["href"].Value).ToList();