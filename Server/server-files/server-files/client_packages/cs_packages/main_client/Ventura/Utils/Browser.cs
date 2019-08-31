using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Ui;

namespace main_client.Ventura.Utils
{
    class Browser : Events.Script
    {
        public static Browser instance { get; set; }
        private Dictionary<string, HtmlWindow> browsers = new Dictionary<string, HtmlWindow>();
        
        public Browser()
        {
            instance = this;
            Events.Add("createBrowser", create_browser);
            Events.Add("executeFunction", execute_browser);
            Events.Add("destroyBrowser", delete_browser);
            Events.Add("changeBrowser", change_browser);
            Events.Add("CEFNotify", CEFNotify);
            Events.OnBrowserLoadingFailed += OnBrowserLoadingFailed;
        }

        private void change_browser(object[] args)
        {
            if (!browsers.ContainsKey((string)args[0]))
            {
                browsers.Add((string)args[0], new HtmlWindow(args[1].ToString()));
            } else if (browsers.ContainsKey((string)args[0]))
            {
                browsers[(string)args[0]].Url = (string)args[1];
            }
        }

        private void CEFNotify(object[] args)
        {
            string text = args[0].ToString();
            Constant.Constant.Notify(text);
        }

        private void OnBrowserLoadingFailed(HtmlWindow window)
        {
            Chat.Output("Error to load cef : "+window.Url+" "+window.Id);
            window.Reload(false);
        }

        public void create_browser(object[] args)
        {
            if (!browsers.ContainsKey((string)args[0]))
            {
                browsers.Add((string)args[0], new HtmlWindow(args[1].ToString()));
            }
        }

        public void execute_browser(object[] args)
        {

            if (args.Length < 2)
            {
                Chat.Output("Execute Browser fail args length < 2");
                return;
            }

            string input = string.Empty;
            string function = args[1].ToString();

            if (args.Length > 2)
            {
                for (int i = 2; i < args.Length; i++)
                {
                    input += input.Length > 0 ? (", '" + args[i].ToString() + "'") : ("'" + args[i].ToString() + "'");
                }
            }
            Constant.Constant.Notify(function + "(" + input + ");");
            if (browsers.ContainsKey((string)args[0]))
                browsers[(string)args[0]].ExecuteJs(function + "(" + input + ");");
        }

        public void delete_browser(object[] args)
        {
            if (browsers.ContainsKey((string)args[0]))
            {
                browsers[(string)args[0]].Active = false;
                browsers[(string)args[0]].Destroy();
                browsers.Remove((string)args[0]);
            }
        }

    }
}
