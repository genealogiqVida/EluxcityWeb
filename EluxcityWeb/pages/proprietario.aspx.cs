using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EluxcityWeb.Controller;
using EluxcityWeb.DTO;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Net.Mail;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Authentication;
using RestSharp;
using System.Text;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;

namespace EluxcityWeb.pages
{
    public partial class proprietario : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String url = "https://eluxcitysb-api.sabacloud.com";
        protected String usuario = "felipe.miranda";
        protected String senha = "elux123";
        protected String username = "";
     
        protected String userTecnico = "";
        protected String userAdministrativo = "";
        protected String virg1 = "";
        protected String virg2 = "";
        protected String certificate = "";

        protected String equipe = "N";

        protected StringBuilder myStringBuilderLancamento = new StringBuilder();
        protected StringBuilder myStringBuilderProva = new StringBuilder();
        protected StringBuilder myStringBuilderTreinamento = new StringBuilder();
        protected StringBuilder myStringBuilderSugestao = new StringBuilder();
        protected StringBuilder myStringBuilderRecente = new StringBuilder();
        protected StringBuilder myStringBuilderPopular = new StringBuilder();
        protected StringBuilder myStringBuilderPrimeira = new StringBuilder();
        protected StringBuilder myStringBuilderSegunda = new StringBuilder();
        protected StringBuilder myStringBuilderTerceira = new StringBuilder();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            equipe = this.Request.Params.Get("equipe");
            if (equipe == null)
            {
                equipe = "";
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

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;


            EluxcityAction action = new EluxcityAction();

            //carrega equipe do proprietario
            var client = new RestClient(url + "/v1/people/" + idUser + ":(teamInfo)?SabaCertificate=" + certificate);
            var request = new RestRequest(Method.GET);
            request.AddHeader("SabaCertificate", certificate);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.Equals(HttpStatusCode.OK)){
                       string  ret = response.Content.ToString();

                         Newtonsoft.Json.Linq.JToken token1 = Newtonsoft.Json.Linq.JObject.Parse(ret);
                         Newtonsoft.Json.Linq.JToken token2 = token1.SelectToken("teamInfo");

                         Newtonsoft.Json.Linq.JArray token3 = (Newtonsoft.Json.Linq.JArray)token2.SelectToken("directReports");

                         foreach (var c in token3)
                         {
                             String id = (String)c.SelectToken("id");

                             //carrega o cargo da pessoa
                             var client2 = new RestClient(url + "/v1/people/" + id + "?SabaCertificate=" + certificate);
                             var request2 = new RestRequest(Method.GET);
                             request2.AddHeader("SabaCertificate", certificate);
                             IRestResponse response2 = client2.Execute(request2);
                             if (response2.StatusCode.Equals(HttpStatusCode.OK))
                             {
                                 ret = response2.Content.ToString();

                                 token1 = Newtonsoft.Json.Linq.JObject.Parse(ret);
                                 String cpf = (String)token1.SelectToken("person_no");
                                 token2 = token1.SelectToken("jobtype_id");
                                 String displayName = (String)token2.SelectToken("displayName");
                                 String perfil = action.verificaPerfil(displayName);
                                 if (perfil.Equals("técnico"))
                                 {
                                     userTecnico = userTecnico + virg1 + "'" + cpf + "'";
                                     virg1 = ",";
                                 }

                                 if (perfil.Equals("administrativo"))
                                 {
                                     userAdministrativo = userAdministrativo + virg2 + "'" + cpf + "'";
                                     virg2 = ",";
                                 }
                             }

                         }
                      
                         
                     }
                


            

            int w = Screen.PrimaryScreen.Bounds.Width;



            myStringBuilderLancamento.Append("<div id=\"carousel_1\"  class=\"container\">");
            myStringBuilderLancamento.Append("<div class=\"control-container\">");
            myStringBuilderLancamento.Append(" <div id=\"left-scroll-button_1\" onclick=\"leftScrollClick()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderLancamento.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderLancamento.Append(" </div>");
            myStringBuilderLancamento.Append(" <div id=\"right-scroll-button_1\" onclick=\"rightScrollClick()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderLancamento.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderLancamento.Append("</div>");
            myStringBuilderLancamento.Append(" </div>");

            myStringBuilderLancamento.Append("<div class=\"items\" id=\"carousel_1-items\"  >");


            //carrega carrossel lançamentos
            List<ConteudoDTO> list = action.carregaLancamentos(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {
                myStringBuilderLancamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderLancamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                myStringBuilderLancamento.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderLancamento.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderLancamento.Append(" </div>");

            }

            myStringBuilderLancamento.Append("</div></div>");


            if (list.Count == 0) myStringBuilderLancamento = new StringBuilder();



            myStringBuilderSugestao.Append("<div id=\"carousel_4\"  class=\"container\">");
            myStringBuilderSugestao.Append(" <div class=\"control-container\">");
            myStringBuilderSugestao.Append(" <div id=\"left-scroll-button_4\" onclick=\"leftScrollClick_4()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderSugestao.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderSugestao.Append(" </div>");
            myStringBuilderSugestao.Append(" <div id=\"right-scroll-button_4\" onclick=\"rightScrollClick_4()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderSugestao.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderSugestao.Append("</div>");
            myStringBuilderSugestao.Append(" </div>");

            myStringBuilderSugestao.Append("<div class=\"items\" id=\"carousel_4-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaSugestao(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderSugestao.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaCurso('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderSugestao.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"" + conteudoDTO.getUrlImagem() + "\" />");
                myStringBuilderSugestao.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderSugestao.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderSugestao.Append(" </div>");
            }


            myStringBuilderSugestao.Append("</div></div>");

            if (list.Count == 0) myStringBuilderSugestao = new StringBuilder();


            myStringBuilderRecente.Append("<div id=\"carousel_5\"  class=\"container\">");
            myStringBuilderRecente.Append(" <div class=\"control-container\">");
            myStringBuilderRecente.Append(" <div id=\"left-scroll-button_5\" onclick=\"leftScrollClick_5()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderRecente.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderRecente.Append(" </div>");
            myStringBuilderRecente.Append(" <div id=\"right-scroll-button_5\" onclick=\"rightScrollClick_5()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderRecente.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderRecente.Append("</div>");
            myStringBuilderRecente.Append(" </div>");

            myStringBuilderRecente.Append("<div class=\"items\" id=\"carousel_5-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaRecente(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderRecente.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderRecente.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                myStringBuilderRecente.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderRecente.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderRecente.Append(" </div>");

            }


            myStringBuilderRecente.Append("</div></div>");

            if (list.Count == 0) myStringBuilderRecente = new StringBuilder();


            myStringBuilderPopular.Append("<div id=\"carousel_6\"  class=\"container\">");
            myStringBuilderPopular.Append(" <div class=\"control-container\">");
            myStringBuilderPopular.Append(" <div id=\"left-scroll-button_6\" onclick=\"leftScrollClick_6()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderPopular.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderPopular.Append(" </div>");
            myStringBuilderPopular.Append(" <div id=\"right-scroll-button_6\" onclick=\"rightScrollClick_6()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderPopular.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderPopular.Append("</div>");
            myStringBuilderPopular.Append(" </div>");

            myStringBuilderPopular.Append("<div class=\"items\" id=\"carousel_6-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaCirculares(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderPopular.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderPopular.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/circulares.png\" />");
                myStringBuilderPopular.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderPopular.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderPopular.Append(" </div>");
            }


            myStringBuilderPopular.Append("</div></div>");

            if (list.Count == 0) myStringBuilderPopular = new StringBuilder();


            myStringBuilderPrimeira.Append("<div id=\"carousel_7\"  class=\"container\">");
            myStringBuilderPrimeira.Append(" <div class=\"control-container\">");
            myStringBuilderPrimeira.Append(" <div id=\"left-scroll-button_7\" onclick=\"leftScrollClick_7()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderPrimeira.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderPrimeira.Append(" </div>");
            myStringBuilderPrimeira.Append(" <div id=\"right-scroll-button_7\" onclick=\"rightScrollClick_7()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderPrimeira.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderPrimeira.Append("</div>");
            myStringBuilderPrimeira.Append(" </div>");

            myStringBuilderPrimeira.Append("<div class=\"items\" id=\"carousel_7-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaBoletins(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderPrimeira.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderPrimeira.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                myStringBuilderPrimeira.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderPrimeira.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderPrimeira.Append(" </div>");

            }

            myStringBuilderPrimeira.Append("</div></div>");

            if (list.Count == 0) myStringBuilderPrimeira = new StringBuilder();


            myStringBuilderSegunda.Append("<div id=\"carousel_8\"  class=\"container\">");
            myStringBuilderSegunda.Append(" <div class=\"control-container\">");
            myStringBuilderSegunda.Append(" <div id=\"left-scroll-button_8\" onclick=\"leftScrollClick_8()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderSegunda.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderSegunda.Append(" </div>");
            myStringBuilderSegunda.Append(" <div id=\"right-scroll-button_8\" onclick=\"rightScrollClick_8()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderSegunda.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderSegunda.Append("</div>");
            myStringBuilderSegunda.Append(" </div>");


            myStringBuilderSegunda.Append("<div class=\"items\" id=\"carousel_8-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaManuais(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderSegunda.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderSegunda.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/manuais.png\" />");
                myStringBuilderSegunda.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderSegunda.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderSegunda.Append(" </div>");
            }


            myStringBuilderSegunda.Append("</div></div>");

            if (list.Count == 0) myStringBuilderSegunda = new StringBuilder();


            myStringBuilderTerceira.Append("<div id=\"carousel_9\"  class=\"container\">");
            myStringBuilderTerceira.Append(" <div class=\"control-container\">");
            myStringBuilderTerceira.Append(" <div id=\"left-scroll-button_9\" onclick=\"leftScrollClick_9()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderTerceira.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderTerceira.Append(" </div>");
            myStringBuilderTerceira.Append(" <div id=\"right-scroll-button_9\" onclick=\"rightScrollClick_9()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderTerceira.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderTerceira.Append("</div>");
            myStringBuilderTerceira.Append(" </div>");

            myStringBuilderTerceira.Append("<div class=\"items\" id=\"carousel_9-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaTreinamentoEquipeTecnica(userTecnico);
            foreach (ConteudoDTO conteudoDTO in list)
            {



                myStringBuilderTerceira.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaCurso('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderTerceira.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"https://static-na1.sabacloud.com/assets/s/1h7ilvlhtpjxu/spf/skin/wireframe/media/images/Course_280x140.png\" />");
                myStringBuilderTerceira.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderTerceira.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderTerceira.Append(" </div>");

            }

            myStringBuilderTerceira.Append("</div></div>");

            if (list.Count == 0) myStringBuilderTerceira = new StringBuilder();

            myStringBuilderProva.Append("<div id=\"carousel_2\"  class=\"container\">");
            myStringBuilderProva.Append(" <div class=\"control-container\">");
            myStringBuilderProva.Append(" <div id=\"left-scroll-button_2\" onclick=\"leftScrollClick_2()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderProva.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderProva.Append(" </div>");
            myStringBuilderProva.Append(" <div id=\"right-scroll-button_2\" onclick=\"rightScrollClick_2()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderProva.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderProva.Append("</div>");
            myStringBuilderProva.Append(" </div>");

            myStringBuilderProva.Append("<div class=\"items\" id=\"carousel_2-items\"  >");

            //carrega carrossel sugestao
            list = action.carregaTreinamentoEquipeAdministrativa(userAdministrativo);
            foreach (ConteudoDTO conteudoDTO in list)
            {



                myStringBuilderProva.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaCurso('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderProva.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"https://static-na1.sabacloud.com/assets/s/1h7ilvlhtpjxu/spf/skin/wireframe/media/images/Course_280x140.png\" />");
                myStringBuilderProva.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderProva.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderProva.Append(" </div>");
      

            }

            myStringBuilderProva.Append("</div></div>");

            if (list.Count == 0) myStringBuilderProva = new StringBuilder();


        }


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



    }
}