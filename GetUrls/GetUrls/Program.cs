using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetUrls
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonGetter = new GetJson();
            //jsonGetter.GetJsonFile();
            //jsonGetter.GetJsonWebClient();
            
            //jsonGetter.GetGitUrls();



        }
    }
}
  


