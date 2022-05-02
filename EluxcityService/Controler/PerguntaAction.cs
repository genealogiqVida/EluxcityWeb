using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
    public class PerguntaAction
    {

        private PerguntaService service = null;

        private void getInstance()
        {
            if (service == null)
            {
                service = new PerguntaService();
            }
        }


        public string salvarDados(string codigoPergunta, string codigoOcorrencia, string tipo, string ordem,
            string ordemProxSeSim, string ordemProxSeNao,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng,
            string respostaPor, string respostaEsp, string respostaIng, string codPais, string tipoArvore , string idioma, string codModelo)
        {
            this.getInstance();

            return service.salvarDados(codigoPergunta, codigoOcorrencia, tipo, ordem,
             ordemProxSeSim, ordemProxSeNao, redacaoPerguntaPor, redacaoPerguntaEsp, redacaoPerguntaIng,
             respostaPor, respostaEsp, respostaIng, codPais, tipoArvore, idioma, codModelo);
        }


        public void salvaValidacao(string codigoPesquisa, string tipo, string codigoPergunta, string redacao, string util,
            string usuario)
        {
            this.getInstance();
            service.salvaValidacao(codigoPesquisa, tipo, codigoPergunta, redacao, util, usuario);
        }


        public string carregaComentario(string codigoPesquisa, string codigoPergunta, string codComentario)
        {
            this.getInstance();
            return service.carregaComentario(codigoPesquisa, codigoPergunta, codComentario);
        }

        public bool excluirDados(string codigoPergunta, string codigoModelo)
        {
            this.getInstance();
            return service.excluirDados(codigoPergunta, codigoModelo);
        }


        public string carregaPerguntas(string codigoOcorrencia, string codigoPesquisa, string codPais,
            string tipoArvore, string idioma, string usuario, string codPergunta, string limit, string offset, string codModelo)
        {
            this.getInstance();
            return service.carregaPerguntas(codigoOcorrencia, codigoPesquisa, codPais, tipoArvore, idioma, usuario,
                codPergunta, limit, offset, codModelo);
        }

        public string getPergunta(string codigoPergunta)
        {
            this.getInstance();
            return service.getPergunta(codigoPergunta);
        }

        public string carregaResposta(string codigo, string idioma, string tipo)
        {
            this.getInstance();
            return service.carregaResposta(codigo, idioma, tipo);
        }

        public string carregaComboOrdem(string codigoOcorrencia, string codPais, string tipoArvore, string idioma)
        {
            this.getInstance();
            return service.carregaComboOrdem(codigoOcorrencia,   codPais,  tipoArvore,  idioma);
        }

        public string carregaNomeOcorrencia(string codigo, string idioma)
        {
            this.getInstance();
            return service.carregaNomeOcorrencia(codigo, idioma);
        }

        public string carregaNomeProduto(string codigo, string idioma)
        {
            this.getInstance();
            return service.carregaNomeProduto(codigo, idioma);
        }

        public string carregaNomeLinha(string codigo, string idioma)
        {
            this.getInstance();
            return service.carregaNomeLinha(codigo, idioma);
        }

        public string carregaNomeModelo(string codigo, string idioma)
        {
            this.getInstance();
            return service.carregaNomeModelo(codigo, idioma);
        }

        //public string carregaComboPergunta()
        //{
        //    return service.carregaComboOcorrencia();
        //}

    }
}
