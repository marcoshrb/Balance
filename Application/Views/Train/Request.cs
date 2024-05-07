using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
// using Newtonsoft.Json;

namespace Views;
public partial class Train
{
    bool screenChanged = false;
    public void MakeRequest()
    {
        var http = new HttpClient();

        var result = http.GetAsync("http://localhost:8080/challenge").GetAwaiter().GetResult();
        var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        
        UserData.Current.JsonValues = JsonSerializer.Deserialize<Values>(resultContent);
        // MessageBox.Show(UserData.Current.JsonValues.f1.ToString());

        if(UserData.Current.JsonValues.ProvaLiberada && !screenChanged)
        {
            // MessageBox.Show("Entrou");
            screenChanged = true;
            this.Hide();
            this.challenge = new();
            challenge.Show();
        }
    }
}