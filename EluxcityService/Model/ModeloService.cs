using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;

namespace EluxcityWeb.Model
{

    public class ModeloService
    {

        private ModeloDAO dao = null;

        public string salvarDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codProduto, string codPais,
            string username, string tipoArvore, string idioma)
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
                string cod = dao.verificaExiste(nomePor, nomeEsp, nomeIng, idioma, codProduto, tipoArvore, codPais);
                if (cod.Equals("0"))
                {
                    codigo = dao.getProximoRegistro();
                    result = dao.inserindoDados(codigo, nomePor, nomeEsp, nomeIng, codProduto, codPais, username, tipoArvore);
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                result = dao.alterandoDados(codigo, nomePor, nomeEsp, nomeIng, codProduto, codPais, username, tipoArvore);

            }

            return result;

        }

        public bool excluirDados(string codigo)
        {
            this.getInstance();
            if (codigo.Equals("")) codigo = "0";
            string cod = dao.verificaConsistencia(codigo);
            if (cod.Equals("0"))
            {
                bool bexcluir = dao.excluindoDados(codigo);
                return bexcluir;
            }
            else
            {
                return false;
            }


           
           // OcorrenciaDAO ocorrenciaDAO = new OcorrenciaDAO();
            //ocorrenciaDAO.excluiOcorrencia();
           
        }

        public string carregaDados(string idioma, string pais, string codLinha, string codProduto, string tipoArvore, string limit, string offset)
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

            string total = "1";
            total = dao.carregaTotal(idioma, pais, codLinha, codProduto, tipoArvore);

            return dao.carregandoDados(idioma, pais, codLinha, codProduto, tipoArvore, limit, offset, total);
        }

        public string getModelo(string codigo)
        {
            this.getInstance();
            return dao.carregaModelo(codigo);
        }

        public string carregaComboProduto(string codigo, string idioma, string tipoArvore, string pais)
        {
            this.getInstance();

            if (pais.Equals("admin"))
            {
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


                return dao.carregandoComboProduto(codigo, idioma, tipoArvore, pais);
            }
            else
            {
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

                return dao.carregandoComboProduto(codigo, idioma, tipoArvore, pais);
            }

           
        }


        public string carregaComboProdutoUsuario(string codigo, string idioma, string tipoArvore, string pais)
        {
            this.getInstance();

            if (pais.Equals("admin"))
            {
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


                return dao.carregandoComboProdutoUsuario(codigo, idioma, tipoArvore, pais);
            }
            else
            {
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

                return dao.carregandoComboProdutoUsuario(codigo, idioma, tipoArvore, pais);
            }


        }



        public string carregaComboLinha(string idioma, string tipoArvore, string pais)
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

            return dao.carregandoComboLinha(idioma, tipoArvore, pais);
        }


        public string carregaComboLinhaUsuario(string idioma, string tipoArvore, string pais)
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

            return dao.carregandoComboLinhaUsuario(idioma, tipoArvore, pais);
        }

        private void getInstance()
        {
            if (dao == null)
            {
                dao = new ModeloDAO();
            }
        }
    }
}
