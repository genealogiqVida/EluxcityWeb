using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
    public class ModeloAction
    {

        private ModeloService service = null;


        public string salvarDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codProduto, string codPais,
            string username, string tipoArvore, string idioma)
        {
            this.getInstance();
            return service.salvarDados(codigo, nomePor, nomeEsp, nomeIng, codProduto, codPais, username, tipoArvore, idioma);


        }

        public bool excluirDados(string codigo)
        {
            this.getInstance();
            return service.excluirDados(codigo);


        }

        public string carregaDados(string idioma, string pais , string codLinha, string codProduto, string tipoArvore,
            string limit, string offset)
        {
            this.getInstance();
            return service.carregaDados(idioma, pais, codLinha, codProduto, tipoArvore, limit, offset);


        }

        public string getModelo(string codigo)
        {
            this.getInstance();
            return service.getModelo(codigo);


        }

        public string carregaComboProduto(string codigo, string idioma, string tipoArvore, string codPais)
        {
            this.getInstance();
            return service.carregaComboProduto(codigo, idioma, tipoArvore, codPais);


        }

        public string carregaComboProdutoUsuario(string codigo, string idioma, string tipoArvore, string codPais)
        {
            this.getInstance();
            return service.carregaComboProdutoUsuario(codigo, idioma, tipoArvore, codPais);


        }

        public string carregaComboLinha(string idioma, string tipoArvore, string codPais)
        {
            this.getInstance();
            return service.carregaComboLinha(idioma, tipoArvore, codPais);


        }

        public string carregaComboLinhaUsuario(string idioma, string tipoArvore, string codPais)
        {
            this.getInstance();
            return service.carregaComboLinhaUsuario(idioma, tipoArvore, codPais);


        }


        private void getInstance()
        {
            if (service == null)
            {
                service = new ModeloService();
            }
        }

    }
}
