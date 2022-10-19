using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EluxcityWeb.DTO
{
    public class CoroasEspeciaisDTO
    {
        private String idUsuario;
        private String data;
        private String justificativa;
        private String nomeAdministrador;
        private String valor;
        private String idDebito_Credito;

        public string getIdUsuario()
        {
            return this.idUsuario;
        }

        public void setIdUsuario(string idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public string getData()
        {
            return this.data;
        }

        public void setData(string data)
        {
            this.data = data;
        }

        public string getNomeAdministrador()
        {
            return this.nomeAdministrador;
        }

        public void setNomeAdministrador(string nomeAdministrador)
        {
            this.nomeAdministrador = nomeAdministrador;
        }

        public string getJustificativa()
        {
            return this.justificativa;
        }

        public void setJustificativa(string justificativa)
        {
            this.justificativa = justificativa;
        }

        public string getValor()
        {
            return this.valor;
        }

        public void setValor(string valor)
        {
            this.valor = valor;
        }

        public string getIdDebitoCredito()
        {
            return this.idDebito_Credito;
        }

        public void setIdDebitoCredito(string idDebitoCredito)
        {
            this.idDebito_Credito = idDebitoCredito;
        }
    }
}
