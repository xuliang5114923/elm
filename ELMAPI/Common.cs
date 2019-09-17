using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Linq;

namespace ELMAPI
{
    public class Common
    {
        public static string CallWebAPI(string apiurl, string method, string contentype, string body, string Authorization = "")
        {
            HttpWebRequest request = null;
            request = (HttpWebRequest)WebRequest.Create(apiurl);

            request.Method = method;//默认就是GET
            //request.Timeout = 50000;//8秒超时
            if (Authorization != "")
            {
                request.Headers.Add("Authorization", "Basic  " + Authorization);
            }
            request.ContentType = contentype;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(body);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public static string base64_Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64_Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string MD5EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }

        public static long DateTimeToUnix(DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public static string GetBodyData(JObject jparams,string action,string token)
        {
            JObject jBody = new JObject();
            jBody.Add(new JProperty("nop", "1.0.0"));
            jBody.Add(new JProperty("id", System.Guid.NewGuid().ToString()));
            //metas
            JObject jmetas = new JObject();
            jmetas.Add(new JProperty("app_key", Config.app_key));
            jmetas.Add(new JProperty("timestamp", DateTimeToUnix(System.DateTime.Now)));
            jBody.Add(new JProperty("metas", jmetas));

            jBody.Add(new JProperty("action", action));
            jBody.Add(new JProperty("token", token));
            //params
            jBody.Add(new JProperty("params", jparams));

            List<string> tmp = new List<string>();
            foreach (var item in jmetas)
            {
                tmp.Add(item.Key + "=" + item.Value.ToString(Formatting.None));
            }

            foreach (var item in jparams)
            {
                tmp.Add(item.Key + "=" + item.Value.ToString(Formatting.None));
            }

            List<string> tmpASC = tmp.OrderBy(o => o).ToList();
            tmp = null;

            StringBuilder sb = new StringBuilder();
            foreach (var item in tmpASC)
            {
                sb.Append(item);
            }
            //签名
            string str = action + token + sb.ToString() + Config.secret;
            str = MD5EncryptString(str).ToUpper();

            jBody.Add(new JProperty("signature", str));
            jBody.Add(new JProperty("secret", Config.secret));

            return jBody.ToString(Formatting.None);
        }

    }
}
