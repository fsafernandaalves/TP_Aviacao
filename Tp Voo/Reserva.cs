using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Voos
{
    class Reserva
    {
        private Passageiro passageiro;
            
        public Reserva(Passageiro passageiro)
        {
            this.passageiro = passageiro;
        }

        /// <summary>
        /// Metodo para retornar o passageiro dessa reserva
        /// </summary>
        /// <returns>Passageiro da reserva</returns>
        public Passageiro getPassageiro()
        {
            return passageiro;
        }
    }
}
