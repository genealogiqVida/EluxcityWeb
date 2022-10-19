using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EluxcityWeb.DTO
{
    public class ConteudoOrdenadoAnoDTO
    {
        private string ano;
        private List<ConteudoDTO> conteudos;

        public string getAno()
        {
            return this.ano;
        }

        public void setAno(string ano)
        {
            this.ano = ano;
        }

        public List<ConteudoDTO> getConteudos()
        {
            return this.conteudos;
        }

        public void setConteudos(List<ConteudoDTO> conteudos)
        {
            this.conteudos = conteudos;
        }
    }
}
