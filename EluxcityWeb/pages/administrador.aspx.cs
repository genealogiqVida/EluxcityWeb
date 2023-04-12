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

namespace EluxcityWeb.pages
{
    public partial class administrador : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String username = "";
        protected String personNO = "";
        protected String certificate = "";

        protected String url = "https://use-api.sabacloud.com";
        protected String usuario = "administrador";
        protected String senha = "elux123";

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

        protected String dominio = "";

        protected String nomeCompleto = "";

        protected String idioma = "";
        protected String pais = "";

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dominio = this.Request.Params.Get("dominio");
            if (dominio == null)
            {
                dominio = "";
            }

            idioma = this.Request.Params.Get("idioma");
            if (idioma == null)
            {
                idioma = "";
            }

            pais = this.Request.Params.Get("pais");
            if (pais == null)
            {
                pais = "";
            }

            equipe = this.Request.Params.Get("equipe");
            if (equipe == null)
            {
                equipe = "";
            }

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

            personNO = this.Request.Params.Get("personNO");
            if(personNO == null)
            {
                personNO = "";
            }

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }

            nomeCompleto = this.Request.Params.Get("nomeCompleto");
            if (nomeCompleto == null)
            {
                nomeCompleto = "";
            }

            EluxcityAction action = new EluxcityAction();

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
            List<ConteudoDTO> list = action.carregaLancamentos(personNO);
            foreach (ConteudoDTO conteudoDTO in list)
            {
                myStringBuilderLancamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderLancamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
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
            list = action.carregaSugestao(personNO);
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

            //carrega carrossel circulares
            list = action.carregaCirculares(personNO);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderRecente.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderRecente.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
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
            list = action.carregaBoletins(personNO);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderPopular.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderPopular.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
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
            list = action.carregaManuais(personNO);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderPrimeira.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderPrimeira.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
                myStringBuilderPrimeira.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderPrimeira.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderPrimeira.Append(" </div>");

            }

            myStringBuilderPrimeira.Append("</div></div>");


            if (list.Count == 0) myStringBuilderPrimeira = new StringBuilder();



        
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            equipe = this.Request.Params.Get("equipe");
            if (equipe == null)
            {
                equipe = "";
            }

            idUser = this.Request.Params.Get("idUser");
            if (idUser == null)
            {
                idUser = "";
            }

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }

            username = this.Request.Params.Get("username");
            if (username == null)
            {
                username = "";
            }
        }



    }
}