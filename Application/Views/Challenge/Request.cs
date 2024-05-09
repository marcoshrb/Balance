using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Views;

public partial class Challenge
{
    bool screenChanged = false;
    public void MakeRequest()
    {
        var http = new HttpClient();

        var result = http.GetAsync("https://server-balance.vercel.app/challenge").GetAwaiter().GetResult();
        var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        // MessageBox.Show(resultContent.ToString());

        UserData.Current.JsonValues = JsonSerializer.Deserialize<Values>(resultContent);

        // MessageBox.Show(UserData.Current.JsonValues.ToString());
    }
}