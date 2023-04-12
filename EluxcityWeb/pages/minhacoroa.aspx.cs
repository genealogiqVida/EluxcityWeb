using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EluxcityWeb.Controller;
using EluxcityWeb.DTO;

namespace EluxcityWeb.pages
{
    public partial class minhacoroa : System.Web.UI.Page
    {
        protected String username = "";
        protected String idUser = "";
        protected String nomeCompleto = "";
        protected String certificate = "";
        protected String equipe = "";
        protected StringBuilder myStringBuilderCoroas = new StringBuilder();
        protected StringBuilder myStringBuilderCoroasEspeciais = new StringBuilder();
        protected int saldo = 0;
        protected String dataAtualizacao = "";
        protected bool isAdmin = false;
        protected String dominio = "";
        protected String personNO = "";

        protected List<String> dominiosOcultarLinkExtrato = new List<String>();
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

            if (username.IndexOf("-") != -1 && username.IndexOf(".") != -1)
            {
                username = username.Replace(".", "");
                username = username.Replace("-", "");
            }

            nomeCompleto = this.Request.Params.Get("nomeCompleto");
            if (nomeCompleto == null)
            {
                nomeCompleto = "";
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

            dominio = this.Request.Params.Get("dominio");
            if (dominio == null)
            {
                dominio = "";
            }

            dominiosOcultarLinkExtrato.Add("BRA - Service Center");
            dominiosOcultarLinkExtrato.Add("BRA - Consumer Care");

            CoroasAction action = new CoroasAction();

            dataAtualizacao = action.carregaDataAtualizacao(username);

            List <CoroasDTO> list = action.carregaCoroas(username);

            if(list.Count > 0) {
                 myStringBuilderCoroas.Append("<table style=\"width:100%\">");
                 myStringBuilderCoroas.Append("<tr><td style=\"padding: 0px 0px 0px 10px; height: 30px;\"><b>Atividade</b></td><td align=\"center\"><b>Quantidade</b></td><td align=\"center\"><b>Coroas</b></td></tr>");
            }

            int linha = 0;
            foreach (CoroasDTO coroasDTO in list)
            {
                if (coroasDTO.getCoroas() != "")
                {
                    saldo = saldo + int.Parse(coroasDTO.getCoroas());
                }
                if (linha == 0)
                {
                    if(coroasDTO.getDescricao() == "Avaliações com Êxito")
                    {
                        myStringBuilderCoroas.Append("<tr style=\"font-size: 14px; line-height: 25px; background-color: #D4F6FF;\"><td style=\"padding:0px 0px 0px 10px;\">" + coroasDTO.getDescricao() + "</td><td align=\"center\">" + coroasDTO.getQuantidade() + "</td><td align=\"center\">" + coroasDTO.getCoroas() + "</td><td><img title=\"As coroas de 'Avaliações com Êxito' possuem o seguinte cálculo: Nota da prova * 100\" style=\"height: 15px; \" src=\"../includes/icons/info-solid.svg\"></td></tr>");
                    }
                    else
                    {
                        myStringBuilderCoroas.Append("<tr style=\"font-size: 14px; line-height: 25px; background-color: #D4F6FF;\"><td style=\"padding:0px 0px 0px 10px;\">" + coroasDTO.getDescricao() + "</td><td align=\"center\">" + coroasDTO.getQuantidade() + "</td><td align=\"center\">" + coroasDTO.getCoroas() + "</td></tr>");
                    }

                }
                else
                {
                    linha = -1;
                    if(coroasDTO.getDescricao() == "Avaliações com Êxito")
                    {
                        myStringBuilderCoroas.Append("<tr style=\"font-size: 14px; line-height: 25px; \"><td style=\"padding:0px 0px 0px 10px;\">" + coroasDTO.getDescricao() + "</td><td align=\"center\">" + coroasDTO.getQuantidade() + "</td><td align=\"center\">" + coroasDTO.getCoroas() + "</td><td><img title=\"As coroas de 'Avaliações com Êxito' possuem o seguinte cálculo: Nota da prova * 100\" style=\"height: 15px; \" src=\"../includes/icons/info-solid.svg\"></td></tr>");

                    }
                    else
                    {
                        myStringBuilderCoroas.Append("<tr style=\"font-size: 14px; line-height: 25px; \"><td style=\"padding:0px 0px 0px 10px;\">" + coroasDTO.getDescricao() + "</td><td align=\"center\">" + coroasDTO.getQuantidade() + "</td><td align=\"center\">" + coroasDTO.getCoroas() + "</td></tr>");
                    }
     
                }
                linha++;
      
            }
            if (list.Count > 0)
            {
                myStringBuilderCoroas.Append("</table>");
            }

            List<CoroasEspeciaisDTO> listEspeciais = action.carregaCoroasEspeciais(username);

            if (listEspeciais.Count > 0)
            {
                myStringBuilderCoroasEspeciais.Append("<table style=\"width:100%; margin-bottom: 50px;\">");
                myStringBuilderCoroasEspeciais.Append("<tr><td style=\"padding: 0px 0px 0px 10px; height: 30px; \"><b>Data</b></td><td><b>Administrador</b></td><td><b>Motivo</b></td><td><b>Pontos</b></td></tr>");
            }

            int linha2 = 0;
            foreach (CoroasEspeciaisDTO coroasEspeciaisDTO in listEspeciais)
            {
                saldo = saldo + int.Parse(coroasEspeciaisDTO.getValor());
                if (linha2 == 0)
                {
                    myStringBuilderCoroasEspeciais.Append("<tr style=\"font - size: 14px; line - height: 25px; background-color: #CED2DD \"><td style=\"padding: 0px 0px 0px 10px; \">" + coroasEspeciaisDTO.getData() + "</td><td>" + coroasEspeciaisDTO.getNomeAdministrador() + "</td><td>" + coroasEspeciaisDTO.getJustificativa() + "</td><td>" + coroasEspeciaisDTO.getValor() + "</td></tr>");

                }
                else
                {
                    linha2 = -1;
                    myStringBuilderCoroasEspeciais.Append("<tr style=\"font - size: 14px; line - height: 25px; \"><td style=\"padding: 0px 0px 0px 10px; \">" + coroasEspeciaisDTO.getData() + "</td><td>" + coroasEspeciaisDTO.getNomeAdministrador() + "</td><td>" + coroasEspeciaisDTO.getJustificativa() + "</td><td>" + coroasEspeciaisDTO.getValor() + "</td></tr>");

                }
                linha2++;

            }
            if (listEspeciais.Count > 0)
            {
                myStringBuilderCoroasEspeciais.Append("</table>");
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


            if (username.IndexOf("-") != -1 && username.IndexOf(".") != -1)
            {
                username = username.Replace(".", "");
                username = username.Replace("-", "");
            }

            CoroasAction action = new CoroasAction();

            isAdmin = action.verificaPerfilAdministrador(username);


        }
    }
}