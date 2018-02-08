using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.WinForms32.Standard
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        System.Windows.Forms.Timer _timer;
        string Username;
        SecureString Password;

        public Form1()
        {
            InitializeComponent();

            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 100;              // Timer will tick every 100 ms
            _timer.Enabled = true;                       // Enable the timer
            _timer.Start();

            AssignCredentials();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            lblTimeValue.Text = DateTime.Now.ToString("o");
        }

        private void btnSynchronousTask_Click(object sender, EventArgs e)
        {
            string url = "https://onebitdeveloper.sharepoint.com";

            using (ClientContext clientContext = new ClientContext(url))
            {
                SetContextCredentials(clientContext);

                // Load stuff with CSOM 
                clientContext.Load(clientContext.Web,
                    w => w.Title,
                    w => w.Lists,
                    w => w.RootFolder.Folders,
                    w => w.RootFolder);

                // synchronous ExecuteQuery blocks the thread
                clientContext.ExecuteQuery();

                System.Console.WriteLine("This line will show when the thread is unblocked."); // boom

                // show output and wait for exit
                System.Console.WriteLine("Title is: " + clientContext.Web.Title);
                System.Console.WriteLine("List count is: " + clientContext.Web.Lists.Count);
                System.Console.WriteLine("Folder count is: " + clientContext.Web.RootFolder.Folders.Count);
                System.Console.WriteLine("Application is ready. Press any key to exit.");
                System.Console.ReadLine();
            }
        }

        private async void btnAsynchronousTask_Click(object sender, EventArgs e)
        {
            await GetWebAddressAsync();

            ClientContext clientContext = new ClientContext("https://onebitdeveloper.sharepoint.com");
            SetContextCredentials(clientContext);
            await clientContext.ExecuteQueryAsync();

            for (int i = 0; i < 10; i++)
            {
                // Load stuff with CSOM 
                clientContext.Load(clientContext.Web,
                    w => w.Title,
                    w => w.Lists,
                    w => w.RootFolder.Folders,
                    w => w.RootFolder);

                // asynchronous ExecuteQueryAsync does not block the thread
                await clientContext.ExecuteQueryAsync(); 
            }
        }

        private async static Task<string> GetWebAddressAsync()
        {
            var httpClient = new HttpClient();
            var message = await httpClient.GetAsync("https://dev.office.com/pnp");
            var content = await message.Content.ReadAsStringAsync();
            return content;
        }


        #region Authentication code
        private void AssignCredentials()
        {
            Username = "admin@onebitdeveloper.onmicrosoft.com"; 
        }

        private void SetContextCredentials(ClientContext clientContext)
        {
            // Set client context credentials
            clientContext.Credentials = new SharePointOnlineCredentials(Username, Password);
        }
        #endregion
    }
}
