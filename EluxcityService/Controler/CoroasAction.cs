using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EluxcityWeb.Model;
using EluxcityWeb.DTO;

namespace EluxcityWeb.Controller
{
    public class CoroasAction
    {
        private CoroasService service = null;


        public List<CoroasDTO> carregaCoroas(string username)
        {
            this.getInstance();
            return service.carregaCoroas(username);


        }

        public List<CoroasEspeciaisDTO> carregaCoroasEspeciais(string username)
        {
            this.getInstance();
            return service.carregaCoroasEspeciais(username);


        }

        public String carregaDataAtualizacao(string username)
        {
            this.getInstance();
            return service.carregaDataAtualizacao(username);
        }

        public bool verificaPerfilAdministrador(string username)
        {
            this.getInstance();
            return service.verificaPerfilAdministrador(username);
        }


        private void getInstance()
        {
            if (service == null)
            {
                service = new CoroasService();
            }
        }
    }
}
