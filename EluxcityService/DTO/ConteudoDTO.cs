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
       private String nameFolder;
       private DateTime updated_on;
 
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

       public String getNameFolder()
        {
            return this.nameFolder;
        }

        public void setNameFolder(string nameFolder)
        {
            this.nameFolder = nameFolder;
        }

        public String getUpdated_On()
        {
            return this.nameFolder;
        }

        public void setUpdated_On(DateTime updated_on)
        {
            this.updated_on = updated_on;
        }

    }
}
