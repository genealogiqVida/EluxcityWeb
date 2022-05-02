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
    public partial class produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [WebMethod()]
        public static string salvarDados(string nomePor, string nomeEsp, string nomeIng, string codLinha, string codigo, string codPais ,
            string tipoArvore)
        {
            ProdutoAction action = new ProdutoAction();
            string result = action.salvarDados(codigo, nomePor, nomeEsp, nomeIng, codLinha, codPais, tipoArvore);
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
            ProdutoAction action = new ProdutoAction();
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
        public static string carregaProdutos(string limit, string offset, string tipoArvore , string idioma, string codLinha, string codPais)
        {

            ProdutoAction action = new ProdutoAction();
            string dados = action.carregaDados(tipoArvore, idioma, codLinha, limit, offset, codPais);
            return dados;
            
        }

        [WebMethod()]
        public static string getProduto(string codigo)
        {

            ProdutoAction action = new ProdutoAction();
            string dados = action.getProduto(codigo);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboLinha()
        {

            ProdutoAction action = new ProdutoAction();
            string dados = action.carregaComboLinha();
            return dados;

        }



       
    }
}