// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   首页控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using System.Net;
using System.Text;

namespace Hao.WebSite.Toolkits.Helper
{
    /// <summary>
    ///  Http访问辅助类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 向指定的URL发送请求，并获取响应字符串（同步方式）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse(string url)
        {
            StreamReader reader = null;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            var str = reader.ReadToEnd();
            return str;
        }

        public static string GetResponse(string url, string postData)
        {
            // 设置编码格式
            var encoding = Encoding.UTF8;
            var data = encoding.GetBytes(postData);
            // 设置参数
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (postData != string.Empty)
            {
                request.ContentLength = data.Length;
                var outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
            }
            // 发送请求并获取相应回应数据
            var response = request.GetResponse() as HttpWebResponse;

            var instream = response.GetResponseStream();
            var sr = new StreamReader(instream, encoding);
            // 返回结果网页（html）代码
            return sr.ReadToEnd();
        }

        public static string GetResponsegs(string url, string postData,string authorization)
        {
            // 设置编码格式
            var encoding = Encoding.UTF8;
            var data = encoding.GetBytes(postData);
            // 设置参数
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (!string.IsNullOrWhiteSpace(authorization))
            {
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer "+ authorization);
            }

            request.Method = "POST";
            request.ContentType = "application/json";
            if (postData != string.Empty)
            {
                request.ContentLength = data.Length;
                var outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
            }
            // 发送请求并获取相应回应数据
            var response = request.GetResponse() as HttpWebResponse;

            var instream = response.GetResponseStream();
            var sr = new StreamReader(instream, encoding);
            // 返回结果网页（html）代码
            var content = sr.ReadToEnd();
            return content;
        }

        public enum HttpMethod
        {
            post,
            get
        }
    }

}
