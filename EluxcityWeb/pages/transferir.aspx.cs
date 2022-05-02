using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EluxcityWeb.pages
{
    public partial class transferir : System.Web.UI.Page
    {
        protected String username = "";
        protected String idUser = "";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            username = this.Request.Params.Get("userName");
            if (username == null)
            {
                username = "";
            }

            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            if (username.IndexOf(",") != -1)
            {
                username = username.Split(',')[0];
            }


        }


        protected void Page_Load(object sender, EventArgs e)
        {



            username = this.Request.Params.Get("userName");
            if (username == null)
            {
                username = "";
            }
            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            if (username.IndexOf(",") != -1)
            {
                username = username.Split(',')[0];
            }

        }
    }
}