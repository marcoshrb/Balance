using System.Windows.Forms;
using Views;
using System.Net.Http;

HttpClient.DefaultProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

ApplicationConfiguration.Initialize();
Application.Run(new Login());
