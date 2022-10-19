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
    public partial class circulares : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String username = "";
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
        protected List<StringBuilderPorAnoDTO> listStringBuilderAno = new List<StringBuilderPorAnoDTO>();

        protected String dominio = "";
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

            EluxcityAction action = new EluxcityAction();

            int w = Screen.PrimaryScreen.Bounds.Width;






            //carrega circulares ordenados
            List<ConteudoOrdenadoAnoDTO> list = action.carregaCircularesOrdenadoAno(username);
            StringBuilderPorAnoDTO builderPorAnoDTO = new StringBuilderPorAnoDTO();
            string anoCorrente = "";
            for (var i = 0; i < list.Count; i++)
            {
                anoCorrente = list[i].getAno();
                var idCarousel = i + 1;
                string carousel = "carousel_" + idCarousel.ToString();
                string carouselItems = "carousel_" + idCarousel.ToString() + "-items";
                string leftScrollButton = "left-scroll-button_" + idCarousel.ToString();
                string rightScrollButton = "right-scroll-button_" + idCarousel.ToString();
                string leftScrollClick = "leftScrollClick()";
                string rightScrollClick = "rightScrollClick()";
                if (idCarousel != 1)
                {
                    leftScrollClick = "leftScrollClick" + idCarousel + "()";
                    rightScrollClick = "rightScrollClick" + idCarousel + "()";
                }
                myStringBuilderLancamento.Append("<div id=" + carousel + "  class=\"container\">");
                myStringBuilderLancamento.Append("<div class=\"control-container\">");
                myStringBuilderLancamento.Append(" <div id=" + leftScrollButton + " onclick=" + leftScrollClick + " class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilderLancamento.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilderLancamento.Append(" </div>");
                myStringBuilderLancamento.Append(" <div id=" + rightScrollButton + " onclick=" + rightScrollClick + " class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilderLancamento.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilderLancamento.Append("</div>");
                myStringBuilderLancamento.Append(" </div>");

                myStringBuilderLancamento.Append("<div class=\"items\" id=" + carouselItems + ">");

                List<ConteudoDTO> listConteudos = new List<ConteudoDTO>();
                listConteudos = list[i].getConteudos();

                string indDescId = "ind_desc" + idCarousel + "_" + idCarousel;
                for (var j = 0; j < listConteudos.Count; j++)
                {
                    myStringBuilderLancamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + listConteudos[j].getId() + "')\" >");
                    myStringBuilderLancamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + listConteudos[j].getUrlImagem() + " />");
                    myStringBuilderLancamento.Append("<div id=" + indDescId + " class=\"item-description opacity-none\"><div class=\"text\">" + listConteudos[j].getTitulo() + "</div></div>");
                    myStringBuilderLancamento.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + listConteudos[j].getProprietario() + "</span></div>");
                    myStringBuilderLancamento.Append(" </div>");
                }

                myStringBuilderLancamento.Append("</div></div>");
                builderPorAnoDTO.setAno(anoCorrente);
                builderPorAnoDTO.setStringBuilder(myStringBuilderLancamento);
                listStringBuilderAno.Add(builderPorAnoDTO);

                myStringBuilderLancamento = new StringBuilder();
                builderPorAnoDTO = new StringBuilderPorAnoDTO();
            }
            /*foreach (ConteudoOrdenadoAnoDTO conteudoDTO in list)
            {
                myStringBuilderLancamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderLancamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/circulares.png\" />");
                myStringBuilderLancamento.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderLancamento.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderLancamento.Append(" </div>");

            }*/



            if (list.Count == 0)
                myStringBuilderLancamento = new StringBuilder();


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

            equipe = this.Request.Params.Get("equipe");
            if (equipe == null)
            {
                equipe = "";
            }

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }
        }



    }
}