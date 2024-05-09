using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Views
{
    public partial class Challenge
    {
        bool screenChanged = false;
        
        public async Task MakeRequest()
        {
            var http = new HttpClient();

            var result = await http.GetAsync("https://server-balance.vercel.app/challenge");

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                UserData.Current.JsonValues = JsonSerializer.Deserialize<Values>(resultContent);

                if (UserData.Current.JsonValues.ProvaLiberada && !screenChanged)
                {
                    screenChanged = true;
                    // Substitua este trecho de código pelo que você deseja fazer quando a prova é liberada
                }
            }
            else
            {
                // Tratar erro de solicitação HTTP aqui, se necessário
            }
        }
    }
}
