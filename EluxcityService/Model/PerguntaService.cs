using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;

namespace EluxcityWeb.Model
{

    public class PerguntaService
    {

        private PerguntaDAO dao = null;

        public string salvarDados(string codigoPergunta, string codigoOcorrencia, string tipo, string ordem,
            string ordemProxSeSim, string ordemProxSeNao,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng,
            string respostaPor, string respostaEsp, string respostaIng, string codPais, string tipoArvore, string idioma, string codModelo)
        {
            this.getInstance();
            string result = "";

            if (codPais.Equals("Brasil"))
            {
                codPais = "2";
            }
            else if (codPais.Equals("Brazil"))
            {
                codPais = "2";
            }

            try
            {
                int icod = Int32.Parse(codPais);
            }
            catch (Exception e)
            {
                codPais = dao.carregaCodigoPais(codPais);
            }



            if (codigoPergunta.Equals(""))
            {
                codigoPergunta = "0";
            }
            if (codigoPergunta.Equals("0"))
            {
                codigoPergunta = dao.getProximoRegistro();
              //  if (codigoPergunta.Equals("") || codigoPergunta.Equals("0"))
                  //  return false;

                


                result = dao.inserindoDados(codigoPergunta, codigoOcorrencia, tipo, ordem,
                    ordemProxSeSim, ordemProxSeNao, redacaoPerguntaPor, redacaoPerguntaEsp,
                    redacaoPerguntaIng, respostaPor, respostaEsp, respostaIng, codPais, tipoArvore, idioma, codModelo);

                try
                {
                    dao.inserindoDadosModelo(codigoPergunta, codModelo);
                }
                catch (Exception e) { }

            }
            else
            {
                result = dao.alterandoDados(codigoPergunta, codigoOcorrencia, tipo, ordem,
                    ordemProxSeSim, ordemProxSeNao, redacaoPerguntaPor, redacaoPerguntaEsp,
                    redacaoPerguntaIng, respostaPor, respostaEsp, respostaIng, codPais, tipoArvore, idioma);

               // bSalvou = false;

            }
            return result;
        }


        public void salvaValidacao(string codigoPesquisa, string tipo, string codigoPergunta, string redacao, string util,
            string usuario)
        {
            this.getInstance();

            string codigoComentario = dao.verificaExisteComentario( codigoPesquisa,  codigoPergunta);

            if (codigoComentario.Equals("0"))
            {
                codigoComentario = dao.getProximoRegistroComentario();

                dao.inserindoDadosComentario(codigoPesquisa, tipo, codigoPergunta, codigoComentario, redacao, util);
            }
            else
            {
                dao.alterandoDadosComentario(codigoPesquisa, tipo, codigoPergunta, codigoComentario, redacao, util);

            }
            
        }

        public bool excluirDados(string codigoPergunta, string codigoModelo)
        {
            this.getInstance();
            dao.excluindoDadosModelo(codigoPergunta,  codigoModelo);
            return dao.excluindoDados(codigoPergunta);
        }

        public string carregaPerguntas(string codigoOcorrencia, string codigoPesquisa, string codPais,
            string tipoArvore, string idioma, string usuario, string codPergunta, string limit, string offset, string codModelo)
        {
            this.getInstance();

            if (codPais.Equals("Brasil"))
            {
                codPais = "2";
            }
            else if (codPais.Equals("Brazil"))
            {
                codPais = "2";
            }

            try
            {
                int icod = Int32.Parse(codPais);
            }
            catch (Exception e)
            {
                codPais = dao.carregaCodigoPais(codPais);
            }


        
            //esconde as condicionais
           // string codigo = dao.carregaCondicional(codigoOcorrencia);
            string codigo = "";

            string total = "1";
            total = dao.carregaTotal(codigoOcorrencia, codigoPesquisa, codPais, tipoArvore, idioma, usuario, codigo,
                codPergunta,codModelo);

            return dao.carregandoPerguntas(codigoOcorrencia, codigoPesquisa, codPais, tipoArvore, idioma, usuario, codigo,
                codPergunta, limit,  offset, total, codModelo);
        }

        public string getPergunta(string codigoPergunta)
        {
            this.getInstance();
            return dao.carregaPergunta(codigoPergunta);
        }

        public string carregaComentario(string codigoPesquisa, string codigoPergunta, string codComentario)
        {
            this.getInstance();
            return dao.carregaComentario(codigoPesquisa, codigoPergunta, codComentario);
        }

        public string carregaResposta(string codigo, string idioma, string tipo)
        {
            this.getInstance();
            return dao.carregaResposta(codigo, idioma, tipo);
        }

        public string carregaComboOrdem(string codigoOcorrencia, string codPais, string tipoArvore, string idioma)
        {
            this.getInstance();

            if (codPais.Equals("Brasil"))
            {
                codPais = "2";
            }
            else if (codPais.Equals("Brazil"))
            {
                codPais = "2";
            }

            try
            {
                int icod = Int32.Parse(codPais);
            }
            catch (Exception e)
            {
                codPais = dao.carregaCodigoPais(codPais);
            }

            return dao.carregaComboOrdem(codigoOcorrencia,   codPais,  tipoArvore,  idioma);
        }

        public string carregaNomeOcorrencia(string codigo, string idioma)
        {
            this.getInstance();
            return dao.carregaNomeOcorrencia(codigo, idioma);
        }

        public string carregaNomeProduto(string codigo, string idioma)
        {
            this.getInstance();
            return dao.carregaNomeProduto(codigo, idioma);
        }

        public string carregaNomeLinha(string codigo, string idioma)
        {
            this.getInstance();
            return dao.carregaNomeLinha(codigo, idioma);
        }

        public string carregaNomeModelo(string codigo, string idioma)
        {
            this.getInstance();
            return dao.carregaNomeModelo(codigo, idioma);
        } 

        private void getInstance()
        {
            if (dao == null)
            {
                dao = new PerguntaDAO();
            }
        }
    }
}
