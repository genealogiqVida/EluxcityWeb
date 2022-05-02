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
    public partial class pergunta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [WebMethod()]
        public static void salvaValidacao(string usuario, string codigoPesquisa, string tipo, string util, string codigoPergunta, string redacao)
        {

            PerguntaAction action = new PerguntaAction();
            action.salvaValidacao(codigoPesquisa, tipo, codigoPergunta, redacao, util, usuario);
        }

        [WebMethod()]
        public static string carregaComentario(string codigoPesquisa, string codigoPergunta, string codComentario)
        {



            PerguntaAction action = new PerguntaAction();
            return action.carregaComentario(codigoPesquisa, codigoPergunta, codComentario);
        }

        [WebMethod()]
        public static string salvarDados(string codigoPergunta, string codigoOcorrencia, string tipo, string ordem,
            string ordemProxSeSim, string ordemProxSeNao,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng,
            string respostaPor, string respostaEsp, string respostaIng, string codPais, string tipoArvore, string idioma,string codModelo)
        {
            PerguntaAction action = new PerguntaAction();
            string result = action.salvarDados(codigoPergunta, codigoOcorrencia, tipo, ordem,
                ordemProxSeSim,ordemProxSeNao,
                redacaoPerguntaPor,redacaoPerguntaEsp,redacaoPerguntaIng,
                respostaPor,respostaEsp,respostaIng, codPais, tipoArvore, idioma, codModelo);
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
        public static string excluirDados(string codigo, string codModelo)
        {
            PerguntaAction action = new PerguntaAction();
            bool bExcluiu = action.excluirDados(codigo, codModelo);
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
        public static string carregaPerguntas(string limit, string offset, string usuario, string codPergunta, string codigoOcorrencia, string codigoPesquisa, string codPais, string tipoArvore, string idioma, string codModelo)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaPerguntas(codigoOcorrencia, codigoPesquisa, codPais, tipoArvore, idioma, usuario,
                codPergunta, limit,  offset, codModelo);
            return dados;

        }

        [WebMethod()]
        public static string getPergunta(string codigo)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.getPergunta(codigo);
            return dados;

        }

        [WebMethod()]
        public static string carregaResposta(string codigo, string idioma, string tipo)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaResposta(codigo, idioma, tipo);            
            return dados;

        }

        [WebMethod()]
        public static string carregaNomeOcorrencia(string codigo, string idioma)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaNomeOcorrencia(codigo, idioma);
            return dados;

        }

          [WebMethod()]
        public static string carregaNomeProduto(string codigo, string idioma)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaNomeProduto(codigo, idioma);
            return dados;

        }

          [WebMethod()]
        public static string carregaNomeLinha(string codigo, string idioma)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaNomeLinha(codigo, idioma);
            return dados;

        }

          [WebMethod()]
        public static string carregaNomeModelo(string codigo, string idioma)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaNomeModelo(codigo, idioma);
            return dados;

        }

        [WebMethod()]
        public static string carregaComboOrdem(string codigoOcorrencia, string codPais, string tipoArvore, string idioma)
        {

            PerguntaAction action = new PerguntaAction();
            string dados = action.carregaComboOrdem(codigoOcorrencia,   codPais,  tipoArvore,  idioma);
            return dados;

        }


    }
}