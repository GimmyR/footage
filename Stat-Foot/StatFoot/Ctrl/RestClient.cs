using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Ctrl {
    class RestClient {

        public RestClient() { }

        public String Post(String url, String json) {

            String result = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";

            using(StreamWriter writer = new StreamWriter(request.GetRequestStream())){

                writer.Write(json);
                writer.Flush();
                writer.Close();

            } HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using(StreamReader reader = new StreamReader(response.GetResponseStream())){

                result = reader.ReadToEnd();

            } return result;

        }

    }
}
