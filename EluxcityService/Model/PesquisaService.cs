using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;

namespace EluxcityWeb.Model
{

    public class PesquisaService
    {

        private PesquisaDAO dao = null;

        public string carregaComboUsuarioDados()
        {
            this.getInstance();
            return dao.carregandoComboUsuarioDados();
        }

        public string carregaComboUsuario()
        {
            this.getInstance();
            return dao.carregandoComboUsuario();
        }


        private void getInstance()
        {
            if (dao == null)
            {
                dao = new PesquisaDAO();
            }
        }

        public string carregaDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset)
        {
            this.getInstance();
            string total = "1";
            total = dao.carregaTotal(codigoUsuario, dataInicial, dataFinal);

            return dao.carregandoDados(codigoUsuario,dataInicial,dataFinal,  limit,  offset, total);
        }


        public string carregaRelatorioDados(string codigoUsuario, string dataInicial, string dataFinal, 
            string limit, string offset, string idioma, string tipoArvore)
        {
            this.getInstance();
            string total = "1";
            total = dao.carregaTotalRelatorioDados(codigoUsuario, dataInicial, dataFinal, tipoArvore);

            return dao.carregandoRelatorioDados(codigoUsuario, dataInicial, dataFinal, limit, offset, total, idioma, tipoArvore);
        }


        public string carregaDadosExcel(string codigoUsuario, string dataInicial, string dataFinal)
        {
            this.getInstance();
            return dao.carregandoDadosExcel(codigoUsuario, dataInicial, dataFinal);
        }

        public string carregaRelatorioDadosExcel(string codigoUsuario, string dataInicial, string dataFinal, string idioma, string tipoArvore)
        {
            this.getInstance();
            return dao.carregandoRelatorioDadosExcel(codigoUsuario, dataInicial, dataFinal, idioma, tipoArvore);
        }
    }
}
