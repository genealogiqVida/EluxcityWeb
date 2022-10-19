using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;
using EluxcityWeb.DTO;

namespace EluxcityWeb.Model
{

    public class CoroasService
    {

        private CoroasDAO dao = null;

        private void getInstance()
        {
            if (dao == null)
            {
                dao = new CoroasDAO();
            }
        }

        public List<CoroasDTO> carregaCoroas(string username)
        {
            this.getInstance();
            return dao.carregandoCoroas(username);
        }

        public List<CoroasEspeciaisDTO> carregaCoroasEspeciais(string username)
        {
            this.getInstance();
            return dao.carregandoCoroasEspeciais(username);
        }

        public String carregaDataAtualizacao(string username)
        {
            this.getInstance();
            return dao.carregandoDataAtualizacao(username);
        }

        public bool verificaPerfilAdministrador(string username)
        {
            this.getInstance();
            return dao.verificandoPerfilAdministrador(username);
        }



    }
}
