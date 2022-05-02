using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EluxcityWeb.Model;
using EluxcityWeb.DTO;

namespace EluxcityWeb.Controller
{
    public class CoroasAction
    {
        private CoroasService service = null;


        public List<CoroasDTO> carregaCoroas(string username)
        {
            this.getInstance();
            return service.carregaCoroas(username);


        }


        private void getInstance()
        {
            if (service == null)
            {
                service = new CoroasService();
            }
        }
    }
}
