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
        protected StringBuilder myStringBuilderCoroas = new StringBuilder();

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

            CoroasAction action = new CoroasAction();
            List<CoroasDTO> list = action.carregaCoroas(username);

            if(list.Count > 0) {
                 myStringBuilderCoroas.Append("<table style=\"width:100%\">");
                 myStringBuilderCoroas.Append("<tr><td style=\"padding: 0px 0px 0px 10px; height: 30px;\"><b>Atividade</b></td><td align=\"center\"><b>Quantidade</b></td><td align=\"center\"><b>Coroas</b></td></tr>");
            }

            int linha = 0;
            foreach (CoroasDTO coroasDTO in list)
            {
                if (linha == 0)
                {
                    myStringBuilderCoroas.Append("<tr style=\"font-size: 14px; line-height: 25px; background-color: #D4F6FF;\"><td style=\"padding:0px 0px 0px 10px;\">" + coroasDTO.getDescricao() + "</td><td align=\"center\">" + coroasDTO.getQuantidade() + "</td><td align=\"center\">" + coroasDTO.getCoroas() + "</td></tr>");

                }
                else
                {
                    linha = -1;
                    myStringBuilderCoroas.Append("<tr style=\"font-size: 14px; line-height: 25px; \"><td style=\"padding:0px 0px 0px 10px;\">" + coroasDTO.getDescricao() + "</td><td align=\"center\">" + coroasDTO.getQuantidade() + "</td><td align=\"center\">" + coroasDTO.getCoroas() + "</td></tr>");
     
                }
                linha++;
      
            }
            if (list.Count > 0)
            {
                myStringBuilderCoroas.Append("</table>");
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

          
        }
    }
}