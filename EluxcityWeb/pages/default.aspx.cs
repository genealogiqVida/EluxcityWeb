using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EluxcityWeb.pages
{
     
    public partial class _default : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String url = "";
        protected String certificate = "";
        protected String usuario = "";
        protected String urlVolta = "";
        protected String idiomaLogin = "";
        protected String tipoArvore = ""; 

        protected void Page_Load(object sender, EventArgs e){}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            idiomaLogin = this.Request.Params.Get("idioma");
            if (idiomaLogin == null)
            {
                idiomaLogin = "";
            }

            if (idiomaLogin.IndexOf(',') != -1)
            {
                idiomaLogin = idiomaLogin.Split(',')[0];
            }

            tipoArvore = this.Request.Params.Get("tipoArvore");
            if (tipoArvore == null)
            {
                tipoArvore = "";
            }

            if (tipoArvore.IndexOf(',') != -1)
            {
                tipoArvore = tipoArvore.Split(',')[0];
            }

            HttpCookie cookieTipoArvore = new HttpCookie("tipoArvore");
            cookieTipoArvore.Value = tipoArvore;
            cookieTipoArvore.Domain = "use.sabacloud.com";
            Response.Cookies.Add(cookieTipoArvore);

            urlVolta = this.Request.Params.Get("urlVolta");
            if (urlVolta == null)
            {
                urlVolta = "";
            }

            if (urlVolta.IndexOf(',') != -1)
            {
                urlVolta = urlVolta.Split(',')[0];
            }

            usuario = this.Request.Params.Get("userName");
            if (usuario == null)
            {
                usuario = "";
            }else{
                if (usuario.IndexOf('.') != -1 && usuario.IndexOf('-') != -1)
                {
                    usuario = usuario.Replace(".", "");
                    usuario = usuario.Replace("-", "");
                }
            }

            if (usuario.IndexOf(',') != -1)
            {
                usuario = usuario.Split(',')[0];
            }

            url = this.Request.Params.Get("url");
            if (url == null)
            {
                url = "";
            }
            if (url.IndexOf(',') != -1)
            {
                url = url.Split(',')[0];
            }


            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }
            if (certificate.IndexOf(',') != -1)
            {
                certificate = certificate.Split(',')[0];
            }

            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }
            if (idUser.IndexOf(',') != -1)
            {
                idUser = idUser.Split(',')[0];
            }

        }
    }
}