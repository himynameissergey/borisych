﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TelegramBot.ParserCore.KMP
{
    class KMPParser : IParser<string[]>
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
            //var items = document.QuerySelectorAll("p").Where(item => item.ClassName != null && item.ClassName.Contains("title")).OfType<IHtmlAnchorElement>(); //reddit
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("col-xs-12")); //KMP
            foreach (var item in items)
            {
                if ( !item.TextContent.Contains("Да ну, фигня (-)") && !item.TextContent.Contains("2174") && !(item.TextContent.Length<100))
                {
                    list.Add(item.TextContent); //habr, nekdo, KMP
                }
                //list.Add(item.Source); //stavklass, pornpics
                //list.Add("https://2ch.hk" + item.PathName);   //2ch
                //list.Add("https://m.lenta.ru" + item.PathName);	//lenta.ru
                //list.Add("https://pikabu.ru" + item.PathName);	//pikabu
                //list.Add(item.PathName);	//reddit
            }
            return list.ToArray();
        }
    }
}