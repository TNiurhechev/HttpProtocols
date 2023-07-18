using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpProtocols
{
    public class Response
    {
        public Data Data { get; set; }

        public static Response DeserializeResponse(string json)
        {
            return JsonConvert.DeserializeObject<Response>(json);
        }
    }
}
