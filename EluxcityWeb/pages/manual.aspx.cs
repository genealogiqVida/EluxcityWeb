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
    public partial class manual : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String url = "https://use-api.sabacloud.com";
        protected String usuario = "administrador";
        protected String senha = "elux123";
        protected String equipe = "N";
        protected String username = "";
        protected String certificate = "";

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

        protected String btnManualServicos = "Manual de Serviços";
        protected String btnBoletinsTecnicos = "Boletins técnicos";
        protected String btnVideos = "Vídeos";
        protected String msgCarrosselVazio = "Não existem conteúdos/cursos a serem exibidos aqui";
        protected String tituloGeladeiras = "Manuais de geladeiras";
        protected String tituloFogoes = "Manuais de fogões";
        protected String tituloLavadoras = "Manuais de lavadoras";
        protected String tituloSecadoras = "Manuais de secadoras";
        protected String tituloLavaLoucas = "Manuais de lava-louças";
        protected String tituloAspiradores = "Manuais de aspiradores";
        protected String tituloCooktops = "Manuais de cooktops";
        protected String tituloCoifas = "Manuais de coifas e depuradores";
        protected String tituloPurificadores = "Manuais de purificadores";

        protected String idioma = "";
        protected String pais = "";

        protected List<String> dominiosLatam = new List<string>()
        {
            "ARG - Consumer Care",
            "CHI - Consumer Care",
            "COL - Consumer Care",
            "ECU - Consumer Care",
            "PER - Consumer Care",
            "PUB - Consumer Care",
            "ARG - Service Center",
            "CHI - Service Center",
            "COL - Service Center",
            "ECU - Service Center",
            "PER - Service Center",
            "PUB - Service Center"
        };

        protected List<String> dominiosUWM = new List<string>()
        {
            "UWM - Consumer Care",
            "UWM - Service Center"
        };

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

            nomeCompleto = this.Request.Params.Get("nomeCompleto");
            if(nomeCompleto == null)
            {
                nomeCompleto = "";
            }

            if (dominiosLatam.Contains(dominio))
            {
                btnManualServicos = "Manual de Servicio";
                btnBoletinsTecnicos = "Boletines Tecnicos";
                btnVideos = "Vídeos";
                msgCarrosselVazio = "No hay contenidos/cursos para mostrar aquí";
                tituloGeladeiras = "Manuales de geladeiras";
                tituloFogoes = "Manuales de estufas";
                tituloLavadoras = "Manuales de lavadoras";
                tituloSecadoras = "Manuales de secadora";
                tituloLavaLoucas = "Manuales de Lavavajillas";
                tituloAspiradores = "Manuales de aspiradoras";
                tituloCooktops = "Manuales de cocinas";
                tituloCoifas = "Manuales de campanas y fregadoras";
                tituloPurificadores = "Manuales de limpieza";
    }
            else if (dominiosUWM.Contains(dominio))
            {
                btnManualServicos = "Service Manual";
                btnBoletinsTecnicos = "Technical Bulletins";
                btnVideos = "Videos";
                msgCarrosselVazio = "There are no contents/courses to display here";
                tituloGeladeiras = "Fridge Manuals";
                tituloFogoes = "Stove Manuals";
                tituloLavadoras = "Washer Manuals";
                tituloSecadoras = "Dryer Manuals";
                tituloLavaLoucas = "Dishwasher Manuals";
                tituloAspiradores = "Vacuum Cleaner Manuals";
                tituloCooktops = "Manuales de cocinas";
                tituloCoifas = "Manuales de campanas y fregadoras";
                tituloPurificadores = "Manuales de limpieza";
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
            List<ConteudoDTO> list = action.carregaManualServico("Refrigerado", username);
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

            //carrega carrossel lançamentos
            list = action.carregaManualServico("Fogões", username);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderProva.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderProva.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
                myStringBuilderProva.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderProva.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderProva.Append(" </div>");
            }


            myStringBuilderProva.Append("</div></div>");


            if (list.Count == 0) myStringBuilderProva = new StringBuilder();


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
            list = action.carregaManualServico("Lavadora", username);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderTreinamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderTreinamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
                myStringBuilderTreinamento.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderTreinamento.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderTreinamento.Append(" </div>");

            }


            myStringBuilderTreinamento.Append("</div></div>");


            if (list.Count == 0) myStringBuilderTreinamento = new StringBuilder();


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
            list = action.carregaManualServico("Secadora", username);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderSugestao.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderSugestao.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
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
            list = action.carregaManualServico("Lava-louça", username);
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
            list = action.carregaManualServico("Aspirador", username);
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
            list = action.carregaManualServico("Cooktop", username);
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
            list = action.carregaManualServico("Coifas", username);
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
            list = action.carregaManualServico("Purificador", username);
            foreach (ConteudoDTO conteudoDTO in list)
            {



                myStringBuilderTerceira.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                myStringBuilderTerceira.Append(" <img  loading=\"auto\" class=\"item-image\" src=" + conteudoDTO.getUrlImagem() + " />");
                myStringBuilderTerceira.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                myStringBuilderTerceira.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                myStringBuilderTerceira.Append(" </div>");

            }

            myStringBuilderTerceira.Append("</div></div>");

            if (list.Count == 0) myStringBuilderTerceira = new StringBuilder();


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

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }
        }



    }
}