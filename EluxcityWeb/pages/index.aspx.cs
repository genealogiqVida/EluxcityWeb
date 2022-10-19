using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EluxcityWeb.Controller;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Security.Authentication;
using RestSharp;
using System.Text;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;

namespace EluxcityWeb.pages
{
    public partial class index : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String username = "";
        protected String personNO = "";
        protected String url = "https://use-api.sabacloud.com";
        protected String usuario = "administrador";
        protected String senha = "elux123";
    
        protected String perfil = "administrador";
        protected String certificateLogin = "";


        protected String Adegas = "N";
        protected String Ar_condicionado = "N";
        protected String Aspirador = "N";
        protected String Conectados = "N";
        protected String Eletroportateis = "N";
        protected String Fogoes = "N";
        protected String Lavadora = "N";
        protected String Lavadora_alta_pressao = "N";
        protected String Lava_louca = "N";
        protected String Micro_ondas = "N";
        protected String Purificador = "N";
        protected String Refrigeracao = "N";
        protected String equipe = "N";
        protected String dominio = "";
        protected String nomeCompleto = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            if (idUser.IndexOf(',') != -1)
            {
                idUser = idUser.Split(',')[0];

            }

            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                ServicePointManager.SecurityProtocol = Tls12;

                
                var client1 = new RestClient(url + "/v1/login");
                var request1 = new RestRequest(Method.GET);
                request1.AddHeader("password", senha);
                request1.AddHeader("user", usuario);
                IRestResponse response1 = client1.Execute(request1);
                if (response1.StatusCode.Equals(HttpStatusCode.OK))
                {
                     string ret = response1.Content.ToString();
                     Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(ret);
                     String certificate = (String)token.SelectToken("certificate");
                     certificateLogin = certificate;

                     var client = new RestClient(url + "/v1/people/" + idUser + "?SabaCertificate=" + certificate);
                     var request = new RestRequest(Method.GET);
                     request.AddHeader("SabaCertificate", certificate);
                     IRestResponse response = client.Execute(request);

                    if (response.StatusCode.Equals(HttpStatusCode.OK))
                     {
                         ret = response.Content.ToString();

                         Newtonsoft.Json.Linq.JToken token1 = Newtonsoft.Json.Linq.JObject.Parse(ret);
                         personNO = (String)token1.SelectToken("person_no");
                         username = (String)token1.SelectToken("username");

                        Newtonsoft.Json.Linq.JToken securityDomain = token1.SelectToken("securityDomain");
                         dominio = (String)securityDomain.SelectToken("displayName");

                         Newtonsoft.Json.Linq.JToken token2 = token1.SelectToken("jobtype_id");
                         String displayName = (String)token2.SelectToken("displayName");

                        String fName = (String)token1.SelectToken("fname");
                        String lname = (String)token1.SelectToken("lname");

                        nomeCompleto = fName + " " + lname;

                        Newtonsoft.Json.Linq.JToken token3 = token1.SelectToken("customValues");
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom2 = (Boolean)token3.SelectToken("ExCustom2"); if (ExCustom2) Adegas = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom3 = (Boolean)token3.SelectToken("ExCustom3"); if (ExCustom3) Ar_condicionado = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom4 = (Boolean)token3.SelectToken("ExCustom4"); if (ExCustom4) Aspirador = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom5 = (Boolean)token3.SelectToken("ExCustom5"); if (ExCustom5) Conectados = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom6 = (Boolean)token3.SelectToken("ExCustom6"); if (ExCustom6) Eletroportateis = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom7 = (Boolean)token3.SelectToken("ExCustom7"); if (ExCustom7) Fogoes = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom8 = (Boolean)token3.SelectToken("ExCustom8"); if (ExCustom8) Lavadora = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom9 = (Boolean)token3.SelectToken("ExCustom9"); if (ExCustom9) Lavadora_alta_pressao = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom10 = (Boolean)token3.SelectToken("ExCustom10"); if (ExCustom10) Lava_louca = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom11 = (Boolean)token3.SelectToken("ExCustom11"); if (ExCustom11) Micro_ondas = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom12 = (Boolean)token3.SelectToken("ExCustom12"); if (ExCustom12) Purificador = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                          try { Boolean ExCustom13 = (Boolean)token3.SelectToken("ExCustom13"); if (ExCustom13) Refrigeracao = "S"; }
                          catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada

                         
                         
                         
                        
                       
                        
                         
                         
                         
                        
                        
                         


                           //verifica se tem equipe
                         client = new RestClient(url + "/v1/people/" + idUser + ":(teamInfo)?SabaCertificate=" + certificate);
                         request = new RestRequest(Method.GET);
                        request.AddHeader("SabaCertificate", certificate);
                         response = client.Execute(request);

                         if (response.StatusCode.Equals(HttpStatusCode.OK))
                        {
                             ret = response.Content.ToString();

                             token1 = Newtonsoft.Json.Linq.JObject.Parse(ret);
                             token2 = token1.SelectToken("teamInfo");

                            Newtonsoft.Json.Linq.JArray token4 = (Newtonsoft.Json.Linq.JArray)token2.SelectToken("directReports");

                            foreach (var c in token4)
                            {
                                equipe = "S";
                            }

                        }

                     


                         EluxcityAction action = new EluxcityAction();
                         perfil = action.verificaPerfil(displayName);
                     }
                }

            }
            catch (Exception ex)
            {

                String erro = ex.ToString();
                ex.StackTrace.ToString();
            }

            if (perfil.Equals("administrativo"))
            {
                Response.Redirect("administrador.aspx?idUser=" + idUser + "&username=" + username + "&personNO=" + personNO + "&certificate=" + certificateLogin + "&equipe=" + equipe + "&dominio=" + dominio + "&nomeCompleto=" + nomeCompleto);

            }
            else if (perfil.Equals("proprietário"))
            {
                Response.Redirect("proprietario.aspx?idUser=" + idUser + "&username=" + username + "&personNO=" + personNO + "&certificate=" + certificateLogin + "&equipe=" + equipe + "&dominio=" + dominio + "&nomeCompleto=" + nomeCompleto);
            }else{

                Response.Redirect("tecnico.aspx?idUser=" + idUser + "&username=" + username + "&personNO=" + personNO + "&certificate=" + certificateLogin
                   + "&Adegas=" + Adegas + "&Ar_condicionado=" + Ar_condicionado + "&Aspirador=" + Aspirador + "&Conectados=" + Conectados + "&Eletroportateis=" + Eletroportateis + "&Fogoes=" + Fogoes
                    + "&Lavadora=" + Lavadora + "&Lavadora_alta_pressao=" + Lavadora_alta_pressao + "&Lava_louca=" + Lava_louca + "&Micro_ondas=" + Micro_ondas + "&Purificador=" + Purificador + "&Refrigeracao=" + Refrigeracao + "&equipe=" + equipe + "&dominio=" + dominio + "&nomeCompleto=" + nomeCompleto);
            }
        }
    }
}