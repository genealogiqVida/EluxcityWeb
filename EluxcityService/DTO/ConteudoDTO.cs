using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EluxcityWeb.DTO
{
   public class ConteudoDTO{

       private String id;
       private String titulo;
       private String urlImagem;
       private String proprietario;
     
 
       public string getProprietario()
       {
           return this.proprietario;
       }

       public string getUrlImagem()
       {
           return this.urlImagem;
       }

       public string getId()
       {
           return this.id;
       }
     
       public string getTitulo()
       {
           return this.titulo;
       }

     
       public void setProprietario(string proprietario)
       {
           this.proprietario = proprietario;
       }

       public void setUrlImagem(string urlImagem)
       {
           this.urlImagem = urlImagem;
       }
     

       public void setId(string id)
       {
           this.id = id;
       }

      
       public void setTitulo(string titulo)
       {
           this.titulo = titulo;
       }

    }
}
