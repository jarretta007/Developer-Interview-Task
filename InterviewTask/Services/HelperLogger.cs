using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace InterviewTask.Services
{
    public class HelperLogger
    {
        private static String ErrorlineNo, Errormsg, extype, exurl, ErrorLocation, info;

        internal static string GetIPAddress(Exception ex)
        {
            HttpContext context = HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            /*if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }*/

            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];
            }
            
            string getNow = DateTime.Now.ToString();
            var line = Environment.NewLine;

            if (ex != null)
            {                
                ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                Errormsg = ex.GetType().Name.ToString();
                extype = ex.GetType().ToString();
                exurl = context.Request.Url.ToString();
                ErrorLocation = ex.Message.ToString();
            }

            

            using (StreamWriter writer = new StreamWriter(@"C:\Temp\log.txt", true))
            {
                if (ex != null)
                {
                    info = "Date:" + " " + getNow + line + "IP Address:" + " " + ipAddress + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:"
                        + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation
                        + line + " Error Page Url:" + " " + exurl;
                }
                else
                {
                    info = "Date:" + " " + getNow + line + "IP Address:" + " " + ipAddress;
                }
                
                writer.WriteLine(info);
                
            }


            return ipAddress;

            //return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}