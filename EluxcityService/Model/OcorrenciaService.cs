using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;

namespace EluxcityWeb.Model
{

    public class OcorrenciaService
    {

        private OcorrenciaDAO dao = null;

        public string salvarDados(string codigo, string descricaoPor, string descricaoIng, string descricaoEsp, string[] codModelos,
            string codPais, string tipoArvore, string idioma, string codLinha, string codProduto)
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


            if (codigo.Equals("0"))
            {
               


                //verfica se ja existe
                string cod = dao.verificaExiste(descricaoPor, descricaoEsp, descricaoIng, idioma, tipoArvore, codModelos,
                    codPais, codLinha, codProduto);
                if (cod.Equals("0"))
                {
                    codigo = dao.getProximoRegistro();
                    result = dao.inserindoDados(codigo, descricaoPor, descricaoIng, descricaoEsp, codModelos,
                         codPais, tipoArvore, idioma);
                }
                else
                {
                    result = "1";
                }


            }
            else
            {
                result = dao.alterandoDados(codigo, descricaoPor, descricaoIng, descricaoEsp, codModelos);

            }

            return result;

        }


        public string salvarDadosPesquisa(string codOcorrencia, string codUsuario, string nomeUsuario,
            string codModelo, string codLinha, string codProduto)
        {
            this.getInstance();
            string codigo = dao.getProximoRegistroPesquisa();
            dao.inserindoDadosPesquisa(codigo, codOcorrencia, codUsuario, nomeUsuario, codModelo, codLinha, codProduto);
            return codigo;

        }

        public bool excluirDados(string codigo, string tipoArvore)
        {
            this.getInstance();
            string cod = dao.verificaConsistencia(codigo, tipoArvore);
            if (cod.Equals("0"))
            {
                dao.excluindoDadosModelo(codigo);
                return dao.excluindoDados(codigo);
            }
            else
            {
                return false;
            }


            
        }

        public string carregaDados(string tipo, string[] codModelos, string idioma, string pais, string tipoArvore,
            string codLinha, string codProduto, string limit, string offset, string descOcorrencia)
        {
            this.getInstance();

            if (pais.Equals(""))
            {
                pais = "2";
            }

            if (pais.Equals("Brasil"))
            {
                pais = "2";
            }
            else if (pais.Equals("Brazil"))
            {
                pais = "2";
            }

            try
            {
                int icod = Int32.Parse(pais);
            }
            catch (Exception e)
            {
                pais = dao.carregaCodigoPais(pais);
            }
            string total = "1";
            total = dao.carregaTotal(tipo, codModelos, idioma, pais, tipoArvore, codLinha, codProduto, descOcorrencia);

            return dao.carregandoDados(tipo, codModelos, idioma, pais, tipoArvore, codLinha, codProduto, limit, offset, total, descOcorrencia);
        }


        public string getOcorrencia(string codigo)
        {
            this.getInstance();
            return dao.carregaOcorrencia(codigo);
        }

        public string carregaComboOcorrencia()
        {
            this.getInstance();
            return dao.carregandoComboOcorrencia();
        }

        public string carregaComboLinha()
        {
            this.getInstance();
            return dao.carregandoComboLinha();
        }

        public string carregaComboProduto(string codigo)
        {
            this.getInstance();
            return dao.carregandoComboProduto(codigo);
        }

        public string carregaComboModelo(string codigo, string idioma, string tipoArvore, string pais)
        {
            this.getInstance();

            if (pais.Equals("Brasil"))
            {
                pais = "2";
            }
            else if (pais.Equals("Brazil"))
            {
                pais = "2";
            }

            try
            {
                int codPais = Int32.Parse(pais);
            }
            catch (Exception e)
            {
                pais = dao.carregaCodigoPais(pais);
            }

            return dao.carregandoComboModelo(codigo, idioma, tipoArvore, pais);
        }

        private void getInstance()
        {
            if (dao == null)
            {
                dao = new OcorrenciaDAO();
            }
        }
    }
}
