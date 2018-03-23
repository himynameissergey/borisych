namespace TelegramBot.ParserCore.Arhivach
{
    class ArhivachSettings : IParserSettings
    {
        public ArhivachSettings(int start, int end)
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
        public string BaseUrl { get; set; } = "http://arhivach.org";
        //public string Prefix { get; set; } = "page{CurrentId}";   //habr
        //public string Prefix { get; set; } = "page/{CurrentId}";  //nekdo
        public string Prefix { get; set; } = "";    //2ch, lenta.ru, pikabu, stavklass, pornpics, arhivach
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}