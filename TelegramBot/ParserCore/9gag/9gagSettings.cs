﻿namespace TelegramBot.ParserCore._9gag
{
    class _9gagSettings : IParserSettings
    {
        public _9gagSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        //public string BaseUrl { get; set; } = "https://habrahabr.ru";
        //public string BaseUrl { get; set; } = "https://nekdo.ru";
        //public string BaseUrl { get; set; } = "https://2ch.hk/news/";
        //public string BaseUrl { get; set; } = "https://m.lenta.ru/";
        //public string BaseUrl { get; set; } = "https://pikabu.ru/hot";
        //public string BaseUrl { get; set; } = "http://stavklass.ru/images";
        //public string BaseUrl { get; set; } = "https://www.reddit.com/r/gifs";
        public string BaseUrl { get; set; } = "http://www.sex.com/gifs";
        //public string Prefix { get; set; } = "page{CurrentId}";   //habr
        //public string Prefix { get; set; } = "page/{CurrentId}";  //nekdo
        public string Prefix { get; set; } = "";    //2ch, lenta.ru, pikabu, stavklass, pornpics, reddit, 9gag
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
