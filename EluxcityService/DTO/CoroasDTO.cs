using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EluxcityWeb.DTO
{
   public class CoroasDTO{

       private String descricao;
       private String quantidade;
       private String coroas;
    
 
       public string getDescricao()
       {
           return this.descricao;
       }

       public string getQuantidade()
       {
           return this.quantidade;
       }

       public string getCoroas()
       {
           return this.coroas;
       }


       public void setDescricao(string descricao)
       {
           this.descricao = descricao;
       }

       public void setQuantidade(string quantidade)
       {
           this.quantidade = quantidade;
       }


       public void setcoroas(string coroas)
       {
           this.coroas = coroas;
       }

      
   

    }
}
