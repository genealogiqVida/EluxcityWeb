using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EluxcityWeb.Controller;

namespace EluxcityWeb.pages
{
    public partial class linha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [WebMethod()]
        public static string salvarDados(string codigo, string nomePor, string nomeIng, string nomeEsp, string codPais,
            string tipoArvore)
        {
            LinhaAction action = new LinhaAction();

            string result = action.salvarDados(codigo, nomePor, nomeEsp, nomeIng, codPais, tipoArvore);
            if (result.Equals(""))
            {
                return "0";
            }
            else
            {
                return result;
            }
        }


        [WebMethod()]
        public static string rodaScript(string script)
        {
            LinhaAction action = new LinhaAction();

            string result = action.rodaScript(script);
            if (result.Equals(""))
            {
                return "Executado com sucesso.";
            }
            else
            {
                return result;
            }
        }

        [WebMethod()]
        public static string carregaComboPais()
        {

            LinhaAction action = new LinhaAction();
            string dados = action.carregaComboPais();
            return dados;

        }

        [WebMethod()]
        public static string excluirDados(string codigo)
        {
            LinhaAction action = new LinhaAction();
            bool bExcluiu = action.excluirDados(codigo);
            if (bExcluiu)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        [WebMethod()]
        public static string carregaLinhas(string limit, string offset, string tipoArvore, string idioma, string codPais)
        {

            LinhaAction action = new LinhaAction();
            string dados = action.carregaDados(tipoArvore, idioma, limit, offset, codPais);
            return dados;

        }

        [WebMethod()]
        public static string getLinha(string codigo)
        {

            LinhaAction action = new LinhaAction();
            string dados = action.getLinha(codigo);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboLinha()
        {

            LinhaAction action = new LinhaAction();
            string dados = action.carregaComboLinha();
            return dados;

        }


    }
}