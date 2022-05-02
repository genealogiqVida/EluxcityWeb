using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EluxcityWeb.pages
{
    public partial class contactcenter : System.Web.UI.Page
    {

        protected String idUser = "";
        protected String url = "https://eluxcitysb-api.sabacloud.com";
        protected String usuario = "felipe.miranda";
        protected String senha = "elux123";
        protected String username = "";
        protected String equipe = "";
        protected String certificate = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            username = this.Request.Params.Get("username");
            if (username == null)
            {
                username = "";
            }

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }

            equipe = this.Request.Params.Get("equipe");
            if (equipe == null)
            {
                equipe = "";
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);



            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            username = this.Request.Params.Get("username");
            if (username == null)
            {
                username = "";
            }

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }

            equipe = this.Request.Params.Get("equipe");
            if (equipe == null)
            {
                equipe = "";
            }
        }
    }
}