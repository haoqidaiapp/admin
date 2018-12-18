//------------------------------------------------------------
// <copyright file="Log.cs" company="Stluciabj">
//     Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <date>2015/4/23 18:48:23</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

using System;
using System.IO;

namespace Hao.WebSite.Toolkits
{
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
        /// <summary>
        /// The lockerlogwrite.
        /// </summary>
        private static readonly object Lockerlogwrite = new object();

        /// <summary>
        /// WriteLine
        /// </summary>
        /// <param name="message">message</param>
        public static void WriteLine(string message)
        {
            lock (Lockerlogwrite)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "log/系统异常";
                string fullpath = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.AppendAllText(fullpath, message + "\r\n      -----" + DateTime.Now + "\r\n");
            }
        }

        /// <summary>
        /// WriteLine
        /// </summary>
        /// <param name="exception">exception</param>
        public static void WriteLine(Exception exception)
        {
            lock (Lockerlogwrite)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "log/系统异常";
                var fullpath = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var message = string.Format(
                        "OnException {0}:\r\n{1}",
                        exception.Message,
                        exception.StackTrace);

                File.AppendAllText(fullpath, message + "\r\n      -----" + DateTime.Now + "\r\n");

                if (exception.InnerException != null)
                {
                    WriteLine(exception.InnerException);
                }
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="directoryName">文件夹名称</param>
        /// <param name="message">日志内容</param>
        public static void WriteLine(string directoryName, string message)
        {
            lock (Lockerlogwrite)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "log/" + directoryName;
                string fullpath = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.AppendAllText(fullpath, message + "\r\n      -----" + DateTime.Now + "\r\n");
            }
        }
    }
}
