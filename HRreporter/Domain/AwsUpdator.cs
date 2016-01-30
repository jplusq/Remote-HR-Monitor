using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.IotData;
using Amazon.IotData.Model;
using System.Configuration;
using System.IO;

namespace Q.IoT.Exercises.HR
{
    //{"state":{"reported": {"HeartRate":72}}}
    public class AwsUpdator
    {
        private AmazonIotDataClient _client = new AmazonIotDataClient(ConfigurationManager.AppSettings["AccessKeyID"],
                                           ConfigurationManager.AppSettings["SecretAccessKey"], ConfigurationManager.AppSettings["AwsIoTEndPoint"]);
        private const string UPDATE_JSON_TEMPLATE = "{{\"state\":{{\"reported\": {{\"HeartRate\":{0}}}}}}}";
        public string Report(int rate, string devName)
        {
            string jsonStr = string.Format(UPDATE_JSON_TEMPLATE, rate);
            UpdateThingShadowRequest req = new UpdateThingShadowRequest();
            req.ThingName = devName;
            req.Payload = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr));
            UpdateThingShadowResponse res = _client.UpdateThingShadow(req);
            return Encoding.UTF8.GetString(res.Payload.ToArray());
        }
    }
}
