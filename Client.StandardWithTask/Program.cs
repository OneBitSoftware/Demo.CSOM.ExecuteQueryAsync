using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client.StandardWithTask
{
    class Program
    {
        static string Username;
        static SecureString Password;

        static void Main(string[] args)
        {
            #region Instantiate context and authenticate
            string url = "https://onebitdeveloper.sharepoint.com";
            ClientContext clientContext = new ClientContext(url);
            AssignCredentials(clientContext);
            clientContext.ExecuteQuery(); // <-- force authentication handshaking for demo 
            #endregion

            // call the async method, which creates, starts and returns a Task
                                Log("Calling Task...");

            Task taskObject = GetSharePointDataAsync(clientContext);

                                Log("Task instantiated...");

            taskObject.ContinueWith((str) => // register a callback
            {
                                Log("Task finished and the code continued through the callback.");
                                Log("Application is ready. Press any key to exit.");
            });

            // do more work here

                                Log("Task started and running, it will be waited now...");

            taskObject.Wait(); // <-- code flow is "waited" here until the Task and ContinueWith is complete

                                clientContext.Dispose();
                                Log("Application code completed.");
                                System.Console.ReadLine();
        }

        public async static Task GetSharePointDataAsync(ClientContext clientContext)
        {
            // Load stuff with CSOM
            clientContext.Load(clientContext.Web);
            clientContext.Load(clientContext.Web.Lists);
            clientContext.Load(clientContext.Web.RootFolder);
            clientContext.Load(clientContext.Web.RootFolder.Folders);

            // asynchronous ExecuteQueryAsync returns code flow
            await clientContext.ExecuteQueryAsync();

            Log("This line will show when the result is returned, but the thread will be unblocked.");

            // show output and wait for exit
            Log("Title is: " + clientContext.Web.Title);
            Log("List count is: " + clientContext.Web.Lists.Count);
            Log("Folder count is: " + clientContext.Web.RootFolder.Folders.Count);
        }

        private static void Log(string message)
        {
            System.Console.WriteLine(DateTime.Now.ToString("o") + ": " + message);
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
