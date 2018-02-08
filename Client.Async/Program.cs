using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client.Async
{
    class Program
    {
        static string Username;
        static SecureString Password;

        static async Task Main(string[] args)
        {
            using (ClientContext clientContext = new ClientContext("https://onebitdeveloper.sharepoint.com"))
            {
                AssignCredentials(clientContext);

                // Load stuff with CSOM 
                clientContext.Load(clientContext.Web,
                    w => w.Title,
                    w => w.Lists,
                    w => w.RootFolder.Folders,
                    w => w.RootFolder);

                // asynchronous ExecuteQueryAsync returns code flow
                await clientContext.ExecuteQueryAsync();

                Console.WriteLine(@"This line will show when the result is
                    returned, but the thread will be unblocked.");

                // show output and wait for exit
                Console.WriteLine("Title is: " + clientContext.Web.Title);
                Console.WriteLine("List count is: " + clientContext.Web.Lists.Count);
                Console.WriteLine("Folder count is: " + clientContext.Web.RootFolder.Folders.Count);
                Console.WriteLine("Application is ready. Press any key to exit.");
                Console.ReadLine();
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
        private static void AssignCredentials(ClientContext clientContext)
        {
            //System.Console.WriteLine("Enter username: ");
            Username = "admin@onebitdeveloper.onmicrosoft.com"; //System.Console.ReadLine();
            //System.Console.WriteLine("Enter password: ");
            //Password = GetPasswordFromConsoleInput();
            
            // Set client context credentials
            clientContext.Credentials = new SharePointOnlineCredentials(Username, Password);

            System.Console.WriteLine("User authenticated. Proceeding with synchronous CSOM code.");
        }
        #endregion
    }
}
