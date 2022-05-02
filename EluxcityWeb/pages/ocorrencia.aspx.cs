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
    

    public partial class ocorrencia : System.Web.UI.Page
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

      

        [WebMethod()]
        public static string salvarDados(string codigo, string descricaoPor, string descricaoIng, string descricaoEsp, string[] codModelos,
            string codPais, string tipoArvore, string idioma, string codLinha, string codProduto)
        {
            OcorrenciaAction action = new OcorrenciaAction();
            string result = action.salvarDados(codigo, descricaoPor, descricaoIng, descricaoEsp, codModelos,
                 codPais,  tipoArvore,  idioma, codLinha, codProduto);
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
        public static string salvarDadosPesquisa(string codOcorrencia, string codModelo, string codLinha, string codProduto, string codUsuario, string nomeUsuario)
        {

          

            OcorrenciaAction action = new OcorrenciaAction();
            return action.salvarDadosPesquisa(codOcorrencia, codUsuario, nomeUsuario, codModelo, codLinha, codProduto);
        }

        [WebMethod()]
        public static string excluirDados(string codigo, string tipoArvore)
        {
            OcorrenciaAction action = new OcorrenciaAction();
            bool bExcluiu = action.excluirDados(codigo, tipoArvore);
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
        public static string carregaOcorrencias(string limit, string offset, string tipo, string[] codModelos, string idioma, string pais, string tipoArvore, string codLinha, string codProduto, string descOcorrencia)
        {

            OcorrenciaAction action = new OcorrenciaAction();
            string dados = action.carregaDados(tipo, codModelos, idioma, pais, tipoArvore, codLinha, codProduto, limit, offset, descOcorrencia);
            return dados;

        }

        [WebMethod()]
        public static string getOcorrencia(string codigo)
        {

            OcorrenciaAction action = new OcorrenciaAction();
            string dados = action.getOcorrencia(codigo);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboOcorrencia()
        {

            OcorrenciaAction action = new OcorrenciaAction();
            string dados = action.carregaComboOcorrencia();
            return dados;

        }

        [WebMethod()]
        public static string carregaComboLinha()
        {

            OcorrenciaAction action = new OcorrenciaAction();
            string dados = action.carregaComboLinha();
            return dados;

        }

        [WebMethod()]
        public static string carregaComboProduto(string codigo)
        {

            OcorrenciaAction action = new OcorrenciaAction();
            string dados = action.carregaComboProduto(codigo);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboModelo(string codigo, string idioma, string tipoArvore, string pais)
        {

            OcorrenciaAction action = new OcorrenciaAction();
            string dados = action.carregaComboModelo(codigo, idioma, tipoArvore, pais);
            return dados;

        }


    }
}