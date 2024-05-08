using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views;

public partial class Challenge
{
    bool screenChanged = false;
    public void MakeRequest()
    {
        var http = new HttpClient();

        var result = http.GetAsync("http://localhost:8080/challenge").GetAwaiter().GetResult();
        var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        UserData.Current.JsonValues = JsonSerializer.Deserialize<Values>(resultContent);

        // MessageBox.Show(UserData.Current.JsonValues.TempoProva.ToString());
    }
}