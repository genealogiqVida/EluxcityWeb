using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
   public class LinhaAction {

       private LinhaService service = null;



       public string salvarDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codPais, string tipoArvore)
       {
           this.getInstance();
           return service.salvarDados(codigo, nomePor, nomeEsp, nomeIng, codPais, tipoArvore);


       }

       public string rodaScript(string script)
       {
           this.getInstance();
           return service.rodaScript(script);


       }

       public string carregaComboPais()
       {
           this.getInstance();
           return service.carregaComboPais();


       }

       public bool excluirDados(string codigo)
       {
           this.getInstance();
          return service.excluirDados(codigo);


       }


       public string carregaDados(string tipoArvore, string idioma, string limit, string offset, string codPais)
       {
           this.getInstance();
           return service.carregaDados(tipoArvore, idioma, limit, offset, codPais);


       }

       public string getLinha(string codigo)
       {
           this.getInstance();
           return service.getLinha(codigo);


       }

       public string carregaComboLinha()
       {
           this.getInstance();
           return service.carregaComboLinha();


       }

       private void getInstance(){
           if (service == null)
           {
               service = new LinhaService();
           }
       }

    }
}
