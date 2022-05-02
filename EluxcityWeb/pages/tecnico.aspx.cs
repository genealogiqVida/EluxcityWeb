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
    public partial class tecnico : System.Web.UI.Page
    {
        protected String idUser = "";
        protected String url = "https://eluxcitysb-api.sabacloud.com";
        protected String usuario = "felipe.miranda";
        protected String senha = "elux123";
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

        protected StringBuilder myStringBuilder4 = new StringBuilder();
        protected StringBuilder myStringBuilder5 = new StringBuilder();
        protected StringBuilder myStringBuilder6 = new StringBuilder();
        protected StringBuilder myStringBuilder7 = new StringBuilder();
        protected StringBuilder myStringBuilder8 = new StringBuilder();
        protected StringBuilder myStringBuilder9 = new StringBuilder();
        protected StringBuilder myStringBuilder10 = new StringBuilder();
        protected StringBuilder myStringBuilder11 = new StringBuilder();
        protected StringBuilder myStringBuilder12 = new StringBuilder();


        protected String Adegas = "N";
         protected String    Ar_condicionado = "N";
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
      
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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

            certificate = this.Request.Params.Get("certificate");
            if (certificate == null)
            {
                certificate = "";
            }


            Adegas = this.Request.Params.Get("Adegas");
            Ar_condicionado = this.Request.Params.Get("Ar_condicionado");
            Aspirador = this.Request.Params.Get("Aspirador");
            Conectados = this.Request.Params.Get("Conectados");
            Eletroportateis = this.Request.Params.Get("Eletroportateis");
            Fogoes = this.Request.Params.Get("Fogoes");
            Lavadora = this.Request.Params.Get("Lavadora");
            Lavadora_alta_pressao = this.Request.Params.Get("Lavadora_alta_pressao");
            Lava_louca = this.Request.Params.Get("Lava_louca");
            Micro_ondas = this.Request.Params.Get("Micro_ondas");
            Purificador = this.Request.Params.Get("Purificador");
            Refrigeracao = this.Request.Params.Get("Refrigeracao");

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
            list = action.carregaProvasPraVoce(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderProva.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaCurso('"+conteudoDTO.getId()+"')\" >");
                myStringBuilderProva.Append(" <img  loading=\"auto\" class=\"item-image\" src=\""+conteudoDTO.getUrlImagem()+"\" />");
                myStringBuilderProva.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">"+conteudoDTO.getTitulo()+"</div></div>");
                myStringBuilderProva.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">"+conteudoDTO.getProprietario()+"</span></div>");
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
            list = action.carregaTreinamento(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {

                myStringBuilderTreinamento.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaCurso('"+conteudoDTO.getId()+"')\" >");
                myStringBuilderTreinamento.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"https://static-na1.sabacloud.com/assets/s/1h7ilvlhtpjxu/spf/skin/wireframe/media/images/Course_280x140.png\" />");
                myStringBuilderTreinamento.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">"+conteudoDTO.getTitulo()+"</div></div>");
                myStringBuilderTreinamento.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">"+conteudoDTO.getProprietario()+"</span></div>");
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


                myStringBuilderRecente.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('"+conteudoDTO.getId()+"')\" >");
                myStringBuilderRecente.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                myStringBuilderRecente.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">"+conteudoDTO.getTitulo()+"</div></div>");
                myStringBuilderRecente.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">"+conteudoDTO.getProprietario()+"</span></div>");
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
            list = action.carregaPopular(username);
            foreach (ConteudoDTO conteudoDTO in list)
            {


                myStringBuilderPopular.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('"+conteudoDTO.getId()+"')\" >");
                myStringBuilderPopular.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                myStringBuilderPopular.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">"+conteudoDTO.getTitulo()+"</div></div>");
                myStringBuilderPopular.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">"+conteudoDTO.getProprietario()+"</span></div>");
                myStringBuilderPopular.Append(" </div>");
            }
          

            myStringBuilderPopular.Append("</div></div>");

            if (list.Count == 0) myStringBuilderPopular = new StringBuilder();


            if (Adegas.Equals("S"))
            {
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
                list = action.carregaHabilidade(username, "1");
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
               

            }





            if (Ar_condicionado.Equals("S"))
            {

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
                list = action.carregaHabilidade(username, "2");
                foreach (ConteudoDTO conteudoDTO in list)
                {

                    myStringBuilderSegunda.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilderSegunda.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilderSegunda.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilderSegunda.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilderSegunda.Append(" </div>");
                }


                myStringBuilderSegunda.Append("</div></div>");

                if (list.Count == 0) myStringBuilderSegunda = new StringBuilder();

            }

            if (Aspirador.Equals("S"))
            {

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
                list = action.carregaHabilidade(username, "3");
                foreach (ConteudoDTO conteudoDTO in list)
                {



                    myStringBuilderTerceira.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilderTerceira.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilderTerceira.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilderTerceira.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilderTerceira.Append(" </div>");

                }

                myStringBuilderTerceira.Append("</div></div>");

                if (list.Count == 0) myStringBuilderTerceira = new StringBuilder();
            }

            if (Conectados.Equals("S"))
            {

                myStringBuilder4.Append("<div id=\"carousel_20\"  class=\"container\">");
                myStringBuilder4.Append(" <div class=\"control-container\">");
                myStringBuilder4.Append(" <div id=\"left-scroll-button_20\" onclick=\"leftScrollClick_20()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder4.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder4.Append(" </div>");
                myStringBuilder4.Append(" <div id=\"right-scroll-button_20\" onclick=\"rightScrollClick_20()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder4.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder4.Append("</div>");
                myStringBuilder4.Append(" </div>");

                myStringBuilder4.Append("<div class=\"items\" id=\"carousel_20-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "4");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder4.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder4.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder4.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder4.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder4.Append(" </div>");
                }

                myStringBuilder4.Append("</div></div>");

                if (list.Count == 0) myStringBuilder4 = new StringBuilder();

            }

            if (Eletroportateis.Equals("S"))
            {

                myStringBuilder5.Append("<div id=\"carousel_21\"  class=\"container\">");
                myStringBuilder5.Append(" <div class=\"control-container\">");
                myStringBuilder5.Append(" <div id=\"left-scroll-button_21\" onclick=\"leftScrollClick_21()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder5.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder5.Append(" </div>");
                myStringBuilder5.Append(" <div id=\"right-scroll-button_21\" onclick=\"rightScrollClick_21()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder5.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder5.Append("</div>");
                myStringBuilder5.Append(" </div>");

                myStringBuilder5.Append("<div class=\"items\" id=\"carousel_21-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "5");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder5.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder5.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder5.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder5.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder5.Append(" </div>");
                }

                myStringBuilder5.Append("</div></div>");

                if (list.Count == 0) myStringBuilder5 = new StringBuilder();

            }

            if (Fogoes.Equals("S"))
            {

                myStringBuilder6.Append("<div id=\"carousel_22\"  class=\"container\">");
                myStringBuilder6.Append(" <div class=\"control-container\">");
                myStringBuilder6.Append(" <div id=\"left-scroll-button_22\" onclick=\"leftScrollClick_22()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder6.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder6.Append(" </div>");
                myStringBuilder6.Append(" <div id=\"right-scroll-button_22\" onclick=\"rightScrollClick_22()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder6.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder6.Append("</div>");
                myStringBuilder6.Append(" </div>");

                myStringBuilder6.Append("<div class=\"items\" id=\"carousel_22-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "6");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder6.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder6.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder6.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder6.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder6.Append(" </div>");
                }

                myStringBuilder6.Append("</div></div>");

                if (list.Count == 0) myStringBuilder6 = new StringBuilder();

            }

            if (Lavadora.Equals("S"))
            {

                myStringBuilder7.Append("<div id=\"carousel_23\"  class=\"container\">");
                myStringBuilder7.Append(" <div class=\"control-container\">");
                myStringBuilder7.Append(" <div id=\"left-scroll-button_23\" onclick=\"leftScrollClick_23()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder7.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder7.Append(" </div>");
                myStringBuilder7.Append(" <div id=\"right-scroll-button_23\" onclick=\"rightScrollClick_23()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder7.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder7.Append("</div>");
                myStringBuilder7.Append(" </div>");

                myStringBuilder7.Append("<div class=\"items\" id=\"carousel_23-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "7");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder7.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder7.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder7.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder7.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder7.Append(" </div>");
                }

                myStringBuilder7.Append("</div></div>");

                if (list.Count == 0) myStringBuilder7 = new StringBuilder();

            }

            if (Lavadora_alta_pressao.Equals("S"))
            {

                myStringBuilder8.Append("<div id=\"carousel_24\"  class=\"container\">");
                myStringBuilder8.Append(" <div class=\"control-container\">");
                myStringBuilder8.Append(" <div id=\"left-scroll-button_24\" onclick=\"leftScrollClick_24()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder8.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder8.Append(" </div>");
                myStringBuilder8.Append(" <div id=\"right-scroll-button_24\" onclick=\"rightScrollClick_24()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder8.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder8.Append("</div>");
                myStringBuilder8.Append(" </div>");

                myStringBuilder8.Append("<div class=\"items\" id=\"carousel_24-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "8");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder8.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder8.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder8.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder8.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder8.Append(" </div>");
                }

                myStringBuilder8.Append("</div></div>");

                if (list.Count == 0) myStringBuilder8 = new StringBuilder();

            }

            if (Lava_louca.Equals("S"))
            {

                myStringBuilder9.Append("<div id=\"carousel_25\"  class=\"container\">");
                myStringBuilder9.Append(" <div class=\"control-container\">");
                myStringBuilder9.Append(" <div id=\"left-scroll-button_25\" onclick=\"leftScrollClick_25()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder9.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder9.Append(" </div>");
                myStringBuilder9.Append(" <div id=\"right-scroll-button_25\" onclick=\"rightScrollClick_25()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder9.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder9.Append("</div>");
                myStringBuilder9.Append(" </div>");

                myStringBuilder9.Append("<div class=\"items\" id=\"carousel_25-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "9");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder9.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder9.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder9.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder9.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder9.Append(" </div>");
                }

                myStringBuilder9.Append("</div></div>");

                if (list.Count == 0) myStringBuilder9 = new StringBuilder();

            }

            if (Micro_ondas.Equals("S"))
            {

                myStringBuilder10.Append("<div id=\"carousel_26\"  class=\"container\">");
                myStringBuilder10.Append(" <div class=\"control-container\">");
                myStringBuilder10.Append(" <div id=\"left-scroll-button_26\" onclick=\"leftScrollClick_26()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder10.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder10.Append(" </div>");
                myStringBuilder10.Append(" <div id=\"right-scroll-button_26\" onclick=\"rightScrollClick_26()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder10.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder10.Append("</div>");
                myStringBuilder10.Append(" </div>");

                myStringBuilder10.Append("<div class=\"items\" id=\"carousel_26-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "10");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder10.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder10.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder10.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder10.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder10.Append(" </div>");
                }

                myStringBuilder10.Append("</div></div>");

                if (list.Count == 0) myStringBuilder10 = new StringBuilder();

            }

            if (Purificador.Equals("S"))
            {
                myStringBuilder11.Append("<div id=\"carousel_27\"  class=\"container\">");
                myStringBuilder11.Append(" <div class=\"control-container\">");
                myStringBuilder11.Append(" <div id=\"left-scroll-button_27\" onclick=\"leftScrollClick_27()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder11.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder11.Append(" </div>");
                myStringBuilder11.Append(" <div id=\"right-scroll-button_27\" onclick=\"rightScrollClick_27()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder11.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder11.Append("</div>");
                myStringBuilder11.Append(" </div>");

                myStringBuilder11.Append("<div class=\"items\" id=\"carousel_27-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "11");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder11.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder11.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder11.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder11.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder11.Append(" </div>");
                }

                myStringBuilder11.Append("</div></div>");

                if (list.Count == 0) myStringBuilder11 = new StringBuilder();
            }

            if (Refrigeracao.Equals("S"))
            {
                myStringBuilder12.Append("<div id=\"carousel_28\"  class=\"container\">");
                myStringBuilder12.Append(" <div class=\"control-container\">");
                myStringBuilder12.Append(" <div id=\"left-scroll-button_28\" onclick=\"leftScrollClick_28()\" class=\"left-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder12.Append("  <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>");
                myStringBuilder12.Append(" </div>");
                myStringBuilder12.Append(" <div id=\"right-scroll-button_28\" onclick=\"rightScrollClick_28()\" class=\"right-scroll button scroll\" style=\"cursor:pointer; opacity:1;\">");
                myStringBuilder12.Append(" <i class=\"fa fa-chevron-right\" aria-hidden=\"true\"></i>");
                myStringBuilder12.Append("</div>");
                myStringBuilder12.Append(" </div>");

                myStringBuilder12.Append("<div class=\"items\" id=\"carousel_28-items\"  >");

                //carrega carrossel sugestao
                list = action.carregaHabilidade(username, "12");
                foreach (ConteudoDTO conteudoDTO in list)
                {
                    myStringBuilder12.Append("<div class=\"item\"  style=\"cursor:pointer;\"  onclick=\"carregaConteudo('" + conteudoDTO.getId() + "')\" >");
                    myStringBuilder12.Append(" <img  loading=\"auto\" class=\"item-image\" src=\"../includes/images/img_defaul.png\" />");
                    myStringBuilder12.Append("<div id=\"ind_desc1_1\" class=\"item-description opacity-none\"><div class=\"text\">" + conteudoDTO.getTitulo() + "</div></div>");
                    myStringBuilder12.Append("<div style=\"top: 7px;position: relative;\"><img src=\"../includes/images/proprietario.png\" style=\"width: 12px;margin-right: 5px;\"><span style=\"font-size: 10;font-family: Arial;color: #92999f;\">" + conteudoDTO.getProprietario() + "</span></div>");
                    myStringBuilder12.Append(" </div>");
                }

                myStringBuilder12.Append("</div></div>");

                if (list.Count == 0) myStringBuilder12 = new StringBuilder();

            }


  
        }


        protected void Page_Load(object sender, EventArgs e) {

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

            Adegas = this.Request.Params.Get("Adegas");
            Ar_condicionado = this.Request.Params.Get("Ar_condicionado");
            Aspirador = this.Request.Params.Get("Aspirador");
            Conectados = this.Request.Params.Get("Conectados");
            Eletroportateis = this.Request.Params.Get("Eletroportateis");
            Fogoes = this.Request.Params.Get("Fogoes");
            Lavadora = this.Request.Params.Get("Lavadora");
            Lavadora_alta_pressao = this.Request.Params.Get("Lavadora_alta_pressao");
            Lava_louca = this.Request.Params.Get("Lava_louca");
            Micro_ondas = this.Request.Params.Get("Micro_ondas");
            Purificador = this.Request.Params.Get("Purificador");
            Refrigeracao = this.Request.Params.Get("Refrigeracao");


        }

           
        
    }
}