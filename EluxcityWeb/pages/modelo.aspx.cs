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
    public partial class modelo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [WebMethod()]
        public static string salvarDados(string nomePor, string nomeEsp, string nomeIng, string codProduto, string codigo, string codPais,
            string username, string tipoArvore, string idioma)
        {
            ModeloAction action = new ModeloAction();
            string result = action.salvarDados(codigo, nomePor, nomeEsp, nomeIng, codProduto, codPais, username, tipoArvore, idioma);
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
        public static string excluirDados(string codigo)
        {
            ModeloAction action = new ModeloAction();
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
        public static string carregaModelos(string limit, string offset, string idioma, string pais, string codLinha, string codProduto, string tipoArvore)
        {

            ModeloAction action = new ModeloAction();
            string dados = action.carregaDados(idioma, pais, codLinha, codProduto, tipoArvore, limit, offset);
            return dados;

        }

        [WebMethod()]
        public static string getModelo(string codigo)
        {

            ModeloAction action = new ModeloAction();
            string dados = action.getModelo(codigo);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboProduto(string codigo, string idioma, string tipoArvore, string codPais)
        {

            ModeloAction action = new ModeloAction();
            string dados = action.carregaComboProduto(codigo, idioma, tipoArvore, codPais);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboProdutoUsuario(string codigo, string idioma, string tipoArvore, string codPais)
        {

            ModeloAction action = new ModeloAction();
            string dados = action.carregaComboProdutoUsuario(codigo, idioma, tipoArvore, codPais);
            return dados;

        }


        [WebMethod()]
        public static string carregaComboLinha(string idioma, string tipoArvore, string codPais)
        {

            ModeloAction action = new ModeloAction();
            string dados = action.carregaComboLinha(idioma, tipoArvore, codPais);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboLinhaUsuario(string idioma, string tipoArvore, string codPais)
        {

            ModeloAction action = new ModeloAction();
            string dados = action.carregaComboLinhaUsuario(idioma, tipoArvore, codPais);
            return dados;

        }

    }
}