using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EluxcityWeb.DTO
{
    public class StringBuilderPorProdutoDTO
    {
        private string tipoProduto;
        private StringBuilder stringBuilder;

        public string getTipoProduto()
        {
            return this.tipoProduto;
        }

        public void setTipoProduto(string tipoProduto)
        {
            this.tipoProduto = tipoProduto;
        }

        public StringBuilder GetStringBuilder()
        {
            return this.stringBuilder;
        }

        public void setStringBuilder(StringBuilder stringBuilder)
        {
            this.stringBuilder = stringBuilder;
        }
    }
}
