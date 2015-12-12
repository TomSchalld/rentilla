using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Rentilla.Controllers
{
    public class FBLoginHelper
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            var fb = new FacebookClient();

            dynamic token = fb.Get("oauth/access_token", new
            {
                client_id = "appid",
                client_secret = "appsecret",
                redirect_uri = url,
                code = Request.QueryString["code"]
            });



        }

    }
}