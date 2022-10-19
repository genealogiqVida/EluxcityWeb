using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EluxcityWeb.DTO
{
    public class StringBuilderPorAnoDTO
    {
        private string ano;
        private StringBuilder stringBuilder;

        public string getAno()
        {
            return this.ano;
        }

        public void setAno(string ano)
        {
            this.ano = ano;
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
