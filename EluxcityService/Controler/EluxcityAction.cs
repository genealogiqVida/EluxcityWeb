using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;
using EluxcityWeb.DTO;

namespace EluxcityWeb.Controller
{
   public class EluxcityAction{

       private EluxcityService service = null;

       public string verificaPerfil(string cargo)
       {
           this.getInstance();
           return service.verificaPerfil(cargo);


       }


       public List<ConteudoDTO> carregaLancamentos(string username)
       {
           this.getInstance();
           return service.carregaLancamentos(username);


       }

       public List<ConteudoDTO> carregaCirculares(string username)
       {
           this.getInstance();
           return service.carregaCirculares(username);


       }

       public List<ConteudoDTO> carregaBoletins(string username)
       {
           this.getInstance();
           return service.carregaBoletins(username);


       }

       public List<ConteudoDTO> carregaManuais(string username)
       {
           this.getInstance();
           return service.carregaManuais(username);


       }

       public List<ConteudoDTO> carregaManualServico(string tipo, string username)
       {
           this.getInstance();
           return service.carregaManualServico(tipo, username);


       }

       public List<ConteudoDTO> carregaVideoServico(string tipo, string username)
       {
           this.getInstance();
           return service.carregaVideoServico(tipo, username);


       }

       public List<ConteudoDTO> carregaBoletimServico(string username)
       {
           this.getInstance();
           return service.carregaBoletimServico(username);


       }

       public List<ConteudoDTO> carregaPopular(string username)
       {
           this.getInstance();
           return service.carregaPopular(username);


       }
       public List<ConteudoDTO> carregaProvasPraVoce(string username)
       {
           this.getInstance();
           return service.carregaProvasPraVoce(username);


       }

       public List<ConteudoDTO> carregaTreinamentoEquipeTecnica(string username)
       {
           this.getInstance();
           return service.carregaTreinamentoEquipeTecnica(username);


       }

       public List<ConteudoDTO> carregaTreinamentoEquipeAdministrativa(string username)
       {
           this.getInstance();
           return service.carregaTreinamentoEquipeAdministrativa(username);


       }

       public List<ConteudoDTO> carregaTreinamento(string username)
       {
           this.getInstance();
           return service.carregaTreinamento(username);


       }

       public List<ConteudoDTO> carregaSugestao(string username)
       {
           this.getInstance();
           return service.carregaSugestao(username);


       }

       public List<ConteudoDTO> carregaHabilidade(string username, string habilidade)
       {
           this.getInstance();
           return service.carregaHabilidade(username, habilidade);


       }

       public List<ConteudoDTO> carregaRecente(string username)
       {
           this.getInstance();
           return service.carregaRecente(username);


       }
     

       private void getInstance(){
           if (service == null)
           {
               service = new EluxcityService();
           }
       }

    }
}
