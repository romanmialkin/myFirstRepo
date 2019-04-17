using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace GetUrls
{
    public class GetJson
    {
        public string Url { get; private set; } =
            $@"link";

        private IWebDriver driver;

        public string TextJsonFromUrl { get; set; }

        public void GetJsonFile()
        {
            var options = new ChromeOptions();
            options.AddArgument(@"--user-data-dir=C:/Users/RomanM/AppData/Local/Google/Chrome/User Data");
            options.AddArguments("disable-infobars"); // disabling infobars
            options.AddArgument("--disable-extensions"); // disabling extensions
            options.AddArgument("--disable-gpu"); // applicable to windows os only
            options.AddArgument("--disable-dev-shm-usage"); // overcome limited resource problems

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Url);
            var text = driver.FindElement(By.TagName("pre")).Text;
            //Console.WriteLine(text);

            TextJsonFromUrl = text;

            if(!File.Exists(@"..\..\Data\fromWeb.json"))
                SaveJson(text);


            driver.Quit();

        }

        public void GetGitUrls()
        {
            if (TextJsonFromUrl != null)
            {
                var json = JObject.Parse(TextJsonFromUrl);
                GetUrls(json);
            }
            else if (File.Exists(@"..\..\Data\fromWeb.json"))
            {
                using (var file = File.OpenText(@"..\..\Data\fromWeb.json"))
                using (var reader = new JsonTextReader(file))
                {
                    var json = JToken.ReadFrom(reader);
                    GetUrls(json);
                }
            }
            else
            {
                Console.WriteLine("Data is not found");
            }
        }

        public void GetUrls(JObject json)
        {
            var jUrls = json.SelectTokens("value[*].webUrl");

            foreach (var jUrl in jUrls)
            {
                Console.WriteLine(jUrl);
            }
        }
        public void GetUrls(JToken json)
        {
            var jUrls = json.SelectTokens("value[*].webUrl");

            foreach (var jUrl in jUrls)
            {
                Console.WriteLine(jUrl);
            }
        }

        public void SaveJson(string text)
        {
            File.AppendAllText(@"..\..\Data\fromWeb.json", text);
        }

        public void GetJsonWebClient()
        {
            using (var wc  = new HttpClient())
            {
                var personalaccesstoken = "token";

                wc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(
                            string.Format($":{personalaccesstoken}"))));


                var json = wc.GetStringAsync(Url).Result;

                TextJsonFromUrl = json;

            }
                

            
        }
    }
}

