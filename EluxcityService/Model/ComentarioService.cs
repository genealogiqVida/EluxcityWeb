using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;

namespace EluxcityWeb.Model
{

    public class ComentarioService
    {

        private ComentarioDAO dao = null;

        private void getInstance()
        {
            if (dao == null)
            {
                dao = new ComentarioDAO();
            }
        }

        public string carregaDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset)
        {
            this.getInstance();

            string total = "1";
            total = dao.carregaTotal(codigoUsuario, dataInicial, dataFinal);

            return dao.carregandoDados(codigoUsuario,dataInicial,dataFinal,  limit,  offset, total);
        }

        public string carregaDadosExcel(string codigoUsuario, string dataInicial, string dataFinal)
        {
            this.getInstance();
            return dao.carregandoDadosExcel(codigoUsuario, dataInicial, dataFinal);
        }

        public string carregaComentario(string codigo)
        {
            this.getInstance();
            return dao.carregaComentario(codigo);
        }
    }
}
