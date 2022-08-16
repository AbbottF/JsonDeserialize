
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserializeTest
{
    public static class KboAjaxGenie
    {
        private static AjaxBookGenieParams _ajaxBookGenieParams;
        public static void RunAjaxGenie()
        {
            string dirname = Directory.GetCurrentDirectory();
            string json = File.ReadAllText(dirname + "\\sAjaxParams.json");
            _ajaxBookGenieParams = Newtonsoft.Json.JsonConvert.DeserializeObject<AjaxBookGenieParams>(json);
           
            Console.WriteLine("I'm here");
            var responce = Console.ReadLine();
        }

       
    }
}
