using System.Net;
using System.Net.Http;

namespace Internet {
    class Internet {
        public static string View(string url) {
            using (HttpClient client = new HttpClient()) {
                using (HttpResponseMessage response = client.GetAsync(url).Result) {
                    using (HttpContent content = response.Content) {
                        return content.ReadAsStringAsync().Result;
                    }
                }
            }
        }
    }
}