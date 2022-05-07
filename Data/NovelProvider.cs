using Novel2.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Novel2.Data
{
    public static class NovelProvider
    {
        private static string BaseUrl = "https://t3tmqp0w.directus.app/items";
        private static HttpClient httpClient = new HttpClient();

        public static async Task<List<Article>> GetArticles()
        {
            var response = await httpClient.GetStringAsync($"{BaseUrl}/article");
            var articles = JsonSerializer.Deserialize<Entry<List<Article>>>(response);

            return articles.Data;
        }

        public static async Task<List<Article>> GetArticles(List<string> fields)
        {
            var paramsString = string.Join(",", fields);

            var response = await httpClient.GetStringAsync($"{BaseUrl}/article?fields={paramsString}");
            var articles = JsonSerializer.Deserialize<Entry<List<Article>>>(response);

            return articles.Data;
        }

        public static async Task<Article> GetSingleArticle(int id)
        {
            var response = await httpClient.GetStringAsync($"{BaseUrl}/article/{id}");
            var article = JsonSerializer.Deserialize<Entry<Article>>(response);

            return article.Data;
        }
    }
}
