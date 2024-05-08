using System.Windows.Forms;
using Views;
try
{
    ApplicationConfiguration.Initialize();
    Application.Run(new Login());
}
catch (System.Exception ex)
{
    MessageBox.Show(ex.Message);
}
