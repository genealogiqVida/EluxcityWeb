using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.DAO;
using EluxcityWeb.DTO;

namespace EluxcityWeb.Model
{

    public class EluxcityService
    {

        private EluxcityDAO dao = null;

        public string verificaPerfil(string cargo)
        {
            this.getInstance();
            return dao.verificandoPerfil(cargo);
        }

        public List<ConteudoDTO> carregaLancamentos(string username)
        {
            this.getInstance();
            return dao.carregandoLancamento(username);
        }
        public List<ConteudoOrdenadoAnoDTO> carregaCircularesOrdenadoAno(string username)
        {
            this.getInstance();
            return dao.carregandoCircularesOrdenadoAno(username);
        }

        public List<ConteudoDTO> carregaCirculares(string username)
        {
            this.getInstance();
            return dao.carregandoCirculares(username);
        }

        public List<ConteudoDTO> carregaBoletins(string username)
        {
            this.getInstance();
            return dao.carregandoBoletins(username);
        }

        public List<ConteudoDTO> carregaManuais(string username)
        {
            this.getInstance();
            return dao.carregandoManuais(username);
        }


        public List<ConteudoDTO> carregaPopular(string username)
        {
            this.getInstance();
            return dao.carregandoPopular(username);
        }

        public List<ConteudoDTO> carregaProvasPraVoce(string username)
        {
            this.getInstance();
            return dao.carregandoProvasPraVoce(username);
        }


        public List<ConteudoDTO> carregaTreinamento(string username)
        {
            this.getInstance();
            return dao.carregandoTreinamento(username);
        }

        public List<ConteudoDTO> carregaManualServico(string tipo, string username)
        {
            this.getInstance();
            return dao.carregandoManualServico(tipo, username);
        }

        public List<ConteudoDTO> carregaVideoServico(string tipo, string username)
        {
            this.getInstance();
            return dao.carregandoVideoServico(tipo, username);
        }

        public List<ConteudoOrdenadoAnoDTO> carregaBoletimServico(string username)
        {
            this.getInstance();
            return dao.carregandoBoletimServico(username);
        }

        public List<ConteudoDTO> carregaTreinamentoEquipeAdministrativa(string username)
        {
            this.getInstance();
            return dao.carregandoTreinamentoEquipeAdministrativa(username);
        }

        public List<ConteudoDTO> carregaTreinamentoEquipeTecnica(string username)
        {
            this.getInstance();
            return dao.carregandoTreinamentoEquipeTecnica(username);
        }

        public List<ConteudoDTO> carregaSugestao(string username)
        {
            this.getInstance();
            return dao.carregandoSugestao(username);
        }

        public List<ConteudoDTO> carregaHabilidade(string username, string habilidade)
        {
            this.getInstance();
            return dao.carregandoHabilidade(username, habilidade);
        }

        public List<ConteudoDTO> carregaRecente(string username)
        {
            this.getInstance();
            return dao.carregandoRecente(username);
        }

        private void getInstance()
        {
            if (dao == null)
            {
                dao = new EluxcityDAO();
            }
        }
    }
}
