using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views;
public partial class Train
{
    bool screenChanged = false;
    public void MakeRequest()
    {
        var handler = new HttpClientHandler()
        {
            Proxy = new WebProxy("https://disrct:etstech31415@rb-proxy-ca1.bosch.com:8080"),
            UseProxy = true
        };

        var http = new HttpClient(handler);

        var result = http.GetAsync("https://server-balance.vercel.app/challenge").GetAwaiter().GetResult();
        var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        UserData.Current.JsonValues = JsonSerializer.Deserialize<Values>(resultContent);

        if(UserData.Current.JsonValues.ProvaLiberada && !screenChanged)
        {
            screenChanged = true;
            this.Hide();
            this.challenge = new();
            challenge.Show();
        }
    }
}