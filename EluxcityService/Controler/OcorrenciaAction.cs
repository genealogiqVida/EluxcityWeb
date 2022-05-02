using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
    public class OcorrenciaAction
    {

        private OcorrenciaService service = null;


        public string salvarDados(string codigo, string descricaoPor, string descricaoIng, string descricaoEsp, string[] codModelos,
            string codPais, string tipoArvore, string idioma, string codLinha, string codProduto)
        {
            
            
            this.getInstance();
            return service.salvarDados(codigo, descricaoPor, descricaoIng, descricaoEsp, codModelos,
                 codPais,  tipoArvore,  idioma,codLinha, codProduto);


        }

        public string salvarDadosPesquisa(string codOcorrencia, string codUsuario, string nomeUsuario, string codModelo, string codLinha, string codProduto)
        {


            this.getInstance();
            return service.salvarDadosPesquisa(codOcorrencia, codUsuario, nomeUsuario, codModelo, codLinha, codProduto);


        }

        public bool excluirDados(string codigo, string tipoArvore)
        {
            this.getInstance();
            return service.excluirDados(codigo, tipoArvore);


        }


        public string carregaDados(string tipo, string[] codModelos, string idioma, string pais,
            string tipoArvore, string codLinha, string codProduto, string limit, string offset, string descOcorrencia)
        {
            this.getInstance();
            return service.carregaDados(tipo, codModelos, idioma, pais, tipoArvore, codLinha, codProduto, limit, offset, descOcorrencia);


        }

        public string getOcorrencia(string codigo)
        {
            this.getInstance();
            return service.getOcorrencia(codigo);


        }

        public string carregaComboOcorrencia()
        {
            this.getInstance();
            return service.carregaComboOcorrencia();


        }

        public string carregaComboLinha()
        {
            this.getInstance();
            return service.carregaComboLinha();


        }

        public string carregaComboProduto(string codigo)
        {
            this.getInstance();
            return service.carregaComboProduto(codigo);


        }

        public string carregaComboModelo(string codigo, string idioma, string tipoArvore, string pais)
        {
            this.getInstance();
            return service.carregaComboModelo(codigo, idioma, tipoArvore, pais);


        }

        private void getInstance()
        {
            if (service == null)
            {
                service = new OcorrenciaService();
            }
        }

    }
}
