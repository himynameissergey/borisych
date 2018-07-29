using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegramBot.ParserCore
{
    class HtmlLoader
    {
        readonly HttpClient client;
        string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            //url = $"{settings.BaseUrl}/{settings.Prefix}/";   //habr, nekdo, vk
            url = $"{settings.BaseUrl}/{settings.Prefix}";   //2ch, pikabu, stavklass, pornpics, arhivach, reddit
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            if (url.Contains("vk.com/tip32/"))
            {
                url = url.Remove(url.Length - 1);
            }
            if (url.Contains("reddit.com/r/gifs//"))
            {
                url = url.Remove(url.Length - 2);
            }
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
