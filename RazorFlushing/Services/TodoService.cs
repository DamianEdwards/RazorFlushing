using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using RazorFlushing.Models;

namespace RazorFlushing.Services
{
    public class TodoService
    {
        private static readonly HttpClient _http = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") };
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public async Task<IEnumerable<Todo>> GetTodosAsync(int? userId)
        {
            var url = "todos";
            if (userId.HasValue)
            {
                url += "?userId=" + UrlEncoder.Default.Encode(userId.ToString());
            }

            var responseStream = await _http.GetStreamAsync(url);

            using (var sr = new StreamReader(responseStream))
            using (var jsonReader = new JsonTextReader(sr))
            {
                return _jsonSerializer.Deserialize<List<Todo>>(jsonReader);
            }
        }
    }
}
