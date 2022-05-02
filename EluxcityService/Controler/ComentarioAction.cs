using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
    public class ComentarioAction
    {

        private ComentarioService service = null;


        public string carregaDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset)
        {
            this.getInstance();
            return service.carregaDados(codigoUsuario, dataInicial, dataFinal, limit, offset);


        }

        public string carregaDadosExcel(string codigoUsuario, string dataInicial, string dataFinal)
        {
            this.getInstance();
            return service.carregaDadosExcel(codigoUsuario, dataInicial, dataFinal);


        }

        public string carregaComentario(string codigo)
        {
            this.getInstance();
            return service.carregaComentario(codigo);


        }

        private void getInstance()
        {
            if (service == null)
            {
                service = new ComentarioService();
            }
        }

    }
}
