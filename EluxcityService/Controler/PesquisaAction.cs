using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
    public class PesquisaAction
    {

        private PesquisaService service = null;


        public string carregaComboUsuario()
        {
            this.getInstance();
            return service.carregaComboUsuario();


        }

        public string carregaComboUsuarioDados()
        {
            this.getInstance();
            return service.carregaComboUsuarioDados();


        }

        public string carregaDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset)
        {

           
            
            this.getInstance();
            return service.carregaDados(codigoUsuario, dataInicial, dataFinal, limit, offset);


        }


        public string carregaRelatorioDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset,
            string idioma, string tipoArvore)
        {



            this.getInstance();
            return service.carregaRelatorioDados(codigoUsuario, dataInicial, dataFinal, limit, offset, idioma, tipoArvore);


        }

        public string carregaDadosExcel(string codigoUsuario, string dataInicial, string dataFinal)
        {



            this.getInstance();
            return service.carregaDadosExcel(codigoUsuario, dataInicial, dataFinal);


        }

        public string carregaRelatorioDadosExcel(string codigoUsuario, string dataInicial, string dataFinal, string idioma, string tipoArvore)
        {



            this.getInstance();
            return service.carregaRelatorioDadosExcel(codigoUsuario, dataInicial, dataFinal,idioma, tipoArvore);


        }

        private void getInstance()
        {
            if (service == null)
            {
                service = new PesquisaService();
            }
        }

    }
}
