using DTI.Services.Interfaces;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DTI.Services.Implements
{
    public class ClientExternalRepository : IClientExternalRepository
    {
        private List<string> DymmyNumberAllowed = new List<string>()
        {
            "1111111111",
            "2222222222",
            "3333333333",
            "4444444444",
            "5555555555",
            "6666666666",
            "7777777777",
            "8888888888",
            "9999999999",
            "0000000000",
        };

        public async Task<bool> ValidateBPJS(string bpjsNumber)
        {
            string url = "https://api.bpjs-kesehatan.go.id/bpjs-kesehatan/v3/nokartu/" + bpjsNumber;
            //var result = await SendClient(url, null, true);

            var result = DymmyNumberAllowed.Any(i => i == bpjsNumber) ? true : false;

            return result;
        }

        public async Task<bool> ValidateDukcapil(string identityNumber, string IdentityFamilyNumber)
        {
            string url = "https://dukcapil.kemendagri.go.id/";
            //var result = await SendClient(url, null, true);
            var result = DymmyNumberAllowed.Any(i => i == identityNumber) && DymmyNumberAllowed.Any(i => i == IdentityFamilyNumber) ? true : false;
            return result;
        }

        public async Task<bool> ValidateTax(string taxNumber)
        {
            string url = "https://api.pajak.go.id/";
            //var result = await SendClient(url, null, true);
            var result = DymmyNumberAllowed.Any(i => i == taxNumber) ? true : false;
            return result;
        }

        public async Task<bool> ValidateTelco(string phone)
        {
            string url = "https://api.telco.com/";
            //var result = await SendClient(url, null, true);
            var result = DymmyNumberAllowed.Any(i => i == phone) ? true : false;
            return result;
        }

        private async Task<bool> SendClient(string url, object data, bool needAuth = false)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");


            HttpClient http = new HttpClient();
            http.BaseAddress = new System.Uri(url);

            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if (needAuth)
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "token");
            }

            var task = Task.Run(async () =>
            {
                return await http.PostAsync(url, content);
            });

            var response = task.Result.Content.ReadAsStringAsync().Result;

            JObject json = JObject.Parse(response); // untuk mengambil data dari response convert to object

            return task.Result.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }
    }
}
