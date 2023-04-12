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
    public partial class principalLatam : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String url = "https://use-api.sabacloud.com";
        protected String usuario = "administrador";
        protected String senha = "elux123";
        protected String username = "";
        protected String personNO = "";
        protected String certificate = "";
        protected String nomeCompleto = "";

        protected StringBuilder myStringBuilderLancamento = new StringBuilder();
        protected StringBuilder myStringBuilderProva = new StringBuilder();
        protected StringBuilder myStringBuilderTreinamento = new StringBuilder();
        protected StringBuilder myStringBuilderSugestao = new StringBuilder();
        protected StringBuilder myStringBuilderRecente = new StringBuilder();
        protected StringBuilder myStringBuilderPopular = new StringBuilder();
        protected StringBuilder myStringBuilderPrimeira = new StringBuilder();
        protected StringBuilder myStringBuilderSegunda = new StringBuilder();
        protected StringBuilder myStringBuilderTerceira = new StringBuilder();

        protected StringBuilder myStringBuilder4 = new StringBuilder();
        protected StringBuilder myStringBuilder5 = new StringBuilder();
        protected StringBuilder myStringBuilder6 = new StringBuilder();
        protected StringBuilder myStringBuilder7 = new StringBuilder();
        protected StringBuilder myStringBuilder8 = new StringBuilder();
        protected StringBuilder myStringBuilder9 = new StringBuilder();
        protected StringBuilder myStringBuilder10 = new StringBuilder();
        protected StringBuilder myStringBuilder11 = new StringBuilder();
        protected StringBuilder myStringBuilder12 = new StringBuilder();

        protected String equipe = "N";

        protected int habilidades = 0;

        protected String dominio = "";
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
            if (personNO == null)
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


            myStringBuilderTreinamento.Append("<div id=\"carousel_3\"  class=\"container\">");
            myStringBuilderTreinamento.Append(" <div class=\"control-container\">");
            myStringBuilderTreinamento.Append(" <div id=\"left-scroll-button_3\" onclick=\"leftScrollClick_3()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderTreinamento.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
            myStringBuilderTreinamento.Append(" </div>");
            myStringBuilderTreinamento.Append(" <div id=\"right-scroll-button_3\" onclick=\"rightScrollClick_3()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
            myStringBuilderTreinamento.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
            myStringBuilderTreinamento.Append("</div>");
            myStringBuilderTreinamento.Append(" </div>");


            myStringBuilderTreinamento.Append("<div class=\"items\" id=\"carousel_3-items\"  >");

            //carrega carrossel treinamento
            list = action.carregaTreinamento(personNO);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderTreinamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaCurso('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderTreinamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
                myStringBuilderTreinamento.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderTreinamento.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderTreinamento.Append(" </div>");

            }


            myStringBuilderTreinamento.Append("</div></div>");

            if (list.Count == 0) myStringBuilderTreinamento = new StringBuilder();

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
            list = action.carregaBoletins(personNO);
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
            list = action.carregaManuais(personNO);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderSegunda.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderSegunda.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
                myStringBuilderSegunda.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderSegunda.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderSegunda.Append(" </div>");
            }


            myStringBuilderSegunda.Append("</div></div>");

            if (list.Count == 0) myStringBuilderSegunda = new StringBuilder();
        }

            protected void Page_Load(object sender, EventArgs e)
        {
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

            personNO = this.Request.Params.Get("personNO");
            if (personNO == null)
            {
                personNO = "";
            }

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }
        }
    }
}