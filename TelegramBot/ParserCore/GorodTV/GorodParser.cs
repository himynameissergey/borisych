using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore.GorodTV
{
    class GorodParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));  //habr
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("text"));    //nekdo
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("orange")).OfType<IHtmlAnchorElement>(); //2ch
            //var items = document.QuerySelectorAll("article").Where(item => item.ClassName == "itemList-item").Select(x => x.Attributes["data-article-id"].Value); //bryansktoday.ru
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName == "col-lg-4 col-md-12 col-sm-12 article-block").Select(x => x.Attributes["data-id"].Value); //gorod-tv.com еще
            var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"] != null && item.Attributes["href"].Value.Contains("/news/")).Select(x => x.Attributes["href"].Value);//.Remove(0, 1)); //gorod-tv.com (Remove(0, 1) - удалим первый символ "/")
            //var items = document.QuerySelectorAll("a").Where(item => item.Attributes["src"].Value.Contains(".mp4")).Select(x => x.Attributes["src"].Value); //reddit - не работает
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("story__title-link")).OfType<IHtmlAnchorElement>(); //pikabu
            //var items = document.All.Where(item => item.LocalName != null && item.LocalName.Contains("img")).OfType<IHtmlImageElement>(); //stavklass
            foreach (var item in items)
            {
                //list.Add(item.Source); //habr, nekdo, stavklass
                //list.Add("https://2ch.hk" + item.PathName);   //2ch
                list.Add("https://gorod-tv.com" + item);	//gorod-tv.com
                //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
            }
            return list.ToArray();
        }
    }
}