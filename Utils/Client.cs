using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinLinesTest.Request;
using WinLinesTest.Results;
using static WinLinesTest.Utils.Enum;

namespace WinLinesTest.Utils
{
    public class Client : Configurations
    {
        protected Form1 form;

        public Client(Form1 form)
        {
            this.form = form;
            Method = Verbs.GET;
            ContentType = "application/JSON";
            PostData = "";
        }

        public Client(Verbs method, string postData)
        {

            Method = method;
            ContentType = "text/json";
            PostData = postData;
        }

        public void Request()
        {
            SpinRequest sRequest = new SpinRequest(form);
            // return sRequest.SRequest("");
        }
        public T SlotRequest<T>(string endpoint, string parameters)
        {
            var SpinRequest = (HttpWebRequest)WebRequest.Create(endpoint + parameters);
            SpinRequest.Method = Method.ToString();
            SpinRequest.ContentLength = 0;
            SpinRequest.ContentType = ContentType;
            using (var response = (HttpWebResponse)SpinRequest.GetResponse())
            {

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Failed: Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {

                            var responseValue = reader.ReadToEnd();
                            var result = JsonConvert.DeserializeObject<ResultWrapper<T>>(responseValue);

                            return result.Value;
                        }
                }
            }
            return default(T);
        }
    }
}
