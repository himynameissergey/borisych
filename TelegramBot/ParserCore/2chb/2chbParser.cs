using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore._2chb
{
    class _2chbParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));  //habr
            //var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("text"));    //nekdo
            var items = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("post__detailpart desktop")).Select(x => x.InnerHtml/*Children*/); //2ch
            //var items = document.QuerySelectorAll("img").Where(item => item.Attributes["data-src"] != null && item.Attributes["data-src"].Value.Contains("https://images.sex.com/images/pinporn")).Select(x => x.Attributes["data-src"].Value); //sex
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("b-list-item__link")).OfType<IHtmlAnchorElement>(); //lenta.ru
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("story__title-link")).OfType<IHtmlAnchorElement>(); //pikabu
            //var items = document.All.Where(item => item.LocalName != null && item.LocalName.Contains("img")).OfType<IHtmlImageElement>(); //stavklass
            if (items?.Any() != false)  // проверка на пустой items (если сайт не распарсился)
            {
                foreach (var item in items)
                {
                    //list.Add(item.Source); //habr, nekdo, stavklass
                    list.Add("https://2ch.hk" + item.Substring(9, item.Length - 20));   //2ch - вычленим строку с URL
                                                                                        //list.Add("https://m.lenta.ru" + item.PathName);	//lenta.ru
                                                                                        //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
                }
            }
            else 
            {
                list.Add("https://2ch.hk/b/ не распарсился. Проверь ASPNetTelegramBot.Models.ParserCore._2chb._2chbParser.cs");
            }
            return list.ToArray();
        }
    }
}
