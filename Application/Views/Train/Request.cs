using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Views;

public partial class Train
{
    bool screenChanged = false;
    public async Task MakeRequest()
    {
        using var http = new HttpClient();

        var response = await http.GetAsync("https://server-balance.vercel.app/challenge");

        if (response.IsSuccessStatusCode)
        {
            var resultContent = await response.Content.ReadAsStringAsync();
            UserData.Current.JsonValues = JsonSerializer.Deserialize<Values>(resultContent);

            if (UserData.Current.JsonValues.ProvaLiberada && !screenChanged)
            {
                screenChanged = true;
                this.Hide();
                this.challenge = new Challenge();
                challenge.Show();
            }
        }
    }
}