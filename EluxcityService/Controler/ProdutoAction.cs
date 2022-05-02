using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.Model;

namespace EluxcityWeb.Controller
{
   public class ProdutoAction{

       private ProdutoService service = null;


       public string salvarDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codLinha, string codPais,
           string tipoArvore)
       {
           this.getInstance();
           return service.salvarDados(codigo, nomePor, nomeEsp, nomeIng, codLinha, codPais, tipoArvore);
         
          
       }

       public bool excluirDados(string codigo)
       {
           this.getInstance();
           return service.excluirDados(codigo);


       }

       public string carregaDados(string tipoArvore, string idioma, string codLinha, string limit, string offset, string codPais)
       {
           this.getInstance();
           return service.carregaDados(tipoArvore, idioma, codLinha, limit, offset, codPais);


       }

       public string getProduto(string codigo)
       {
           this.getInstance();
           return service.getProduto(codigo);


       }

       public string carregaComboLinha()
       {
           this.getInstance();
           return service.carregaComboLinha();


       }


       private void getInstance(){
           if (service == null)
           {
               service = new ProdutoService();
           }
       }

    }
}
