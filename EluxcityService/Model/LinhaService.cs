using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;

namespace EluxcityWeb.Model
{

    public class LinhaService
    {

        private LinhaDAO dao = null;

        public string rodaScript(string script)
        {
            this.getInstance();

            

            string result = "";
            result = dao.rodandoScript(script);

            return result;

        }

        public string salvarDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codPais, string tipoArvore)
        {
            this.getInstance();

            if (codPais.Equals(""))
            {
                codPais = "2";
            }

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


            string result = "";
            if (codigo.Equals("0"))
            {

                string cod = "0";
                if (!nomePor.Equals("")){
                    cod = dao.verificaExiste(nomePor, "", "", tipoArvore, codPais);
                }
                if (cod.Equals("0"))
                {
                    if (!nomeEsp.Equals(""))
                    {
                        cod = dao.verificaExiste("", nomeEsp, "", tipoArvore, codPais);
                    }
                }

                if (cod.Equals("0"))
                {
                    if (!nomeIng.Equals(""))
                    {
                        cod = dao.verificaExiste("", "", nomeIng, tipoArvore, codPais);
                    }
                }

                if (cod.Equals("0"))
                {

                    codigo = dao.getProximoRegistro();
                    result = dao.inserindoDados(codigo, nomePor, nomeEsp, nomeIng, codPais, tipoArvore);
                }
                else
                {
                    result = "1";
                }

               
            }
            else
            {
                result = dao.alterandoDados(codigo, nomePor, nomeEsp, nomeIng, codPais, tipoArvore);

            }

            return result;

        }


        public string carregaComboPais()
        {
            this.getInstance();
            return dao.carregaComboPais();
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
        }

        public string carregaDados(string tipoArvore, string idioma, string limit, string offset, string pais)
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
            total = dao.carregaTotal(tipoArvore, idioma, pais);

            return dao.carregandoDados(tipoArvore, idioma, limit, offset, total, pais);
        }


        public string getLinha(string codigo)
        {
            this.getInstance();
            return dao.carregaLinha(codigo);
        }

        public string carregaComboLinha()
        {
            this.getInstance();
            return dao.carregandoComboLinha();
        }


        private void getInstance()
        {
            if (dao == null)
            {
                dao = new LinhaDAO();
            }
        }
    }
}
