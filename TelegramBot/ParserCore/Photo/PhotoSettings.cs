namespace TelegramBot.ParserCore.Photo
{
    class PhotoSettings : IParserSettings
    {
        public PhotoSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        //public string BaseUrl { get; set; } = "https://habrahabr.ru";
        //public string BaseUrl { get; set; } = "https://nekdo.ru";
        //public string BaseUrl { get; set; } = "https://2ch.hk/news/";
        //public string BaseUrl { get; set; } = "https://m.lenta.ru/";
        //public string BaseUrl { get; set; } = "https://pikabu.ru/hot";
        public string BaseUrl { get; set; } = "https://reddit.com"; 
        //public string BaseUrl { get; set; } = "https://rt.pornhub.com/gifs?o=mv";
        //public string Prefix { get; set; } = "page{CurrentId}";   //habr
        //public string Prefix { get; set; } = "page/{CurrentId}";  //nekdo
        public string Prefix { get; set; } = "";    //2ch, lenta.ru, pikabu, stavklass, pornpics
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
