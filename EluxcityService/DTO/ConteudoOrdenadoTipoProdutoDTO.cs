using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EluxcityWeb.DTO
{
    public class ConteudoOrdenadoTipoProdutoDTO
    {
        public string tipoProduto;
        private List<ConteudoDTO> conteudos;

        public string getTipoProduto()
        {
            return this.tipoProduto;
        }

        public void setTipoProduto(string tipoProduto)
        {
            this.tipoProduto = tipoProduto;
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
