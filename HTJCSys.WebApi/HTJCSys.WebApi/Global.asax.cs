using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HTJCSys.WebApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["Debug"].ToString().Trim().Equals("1"))
            {
                string url = this.Request.HttpMethod + "->" + this.Request.Url.AbsolutePath;
                string querystring = "";
                if (this.Request.HttpMethod.ToUpper() == "GET")
                {
                    foreach (string i in this.Request.QueryString)
                    {
                        querystring += string.Format("&{0}={1}", i, this.Request.QueryString[i].ToString());
                    }
                }
                else if (this.Request.HttpMethod.ToUpper() == "POST")
                {
                    foreach (string i in this.Request.Form)
                    {
                        querystring += string.Format("&{0}={1}", i, this.Request.Form[i].ToString());
                    }
                }
                if (querystring.Length > 1)
                {
                    querystring = querystring.Remove(0, 1);
                    querystring = "?" + querystring;
                }
                COM.CLog.WriteStationLog("Request", $"{this.Request.UserHostAddress},{url}{querystring}");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}