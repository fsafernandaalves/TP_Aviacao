using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Voos
{
    class Aeroporto
    {
        private List<Voo> VoosAtivos;

        /// <summary>
        /// Criar um aeroporto, voos ativos devem ser adicionados na lista como mostra o exemplo
        /// </summary>

        public Aeroporto()
        {
            VoosAtivos = new List<Voo>();
            Voo BH_Rio = new Voo(1, "BH/Rio");
            Voo BH_SP = new Voo(2, "BH/SP");
            Voo BH_Recife = new Voo(3, "BH/Recife");

            VoosAtivos.Add(BH_Rio);
            VoosAtivos.Add(BH_SP);
            VoosAtivos.Add(BH_Recife);
        }


        /// <summary>
        /// Procura se o voo existe
        /// </summary>
        /// <param name="Numero">Numero do voo a ser procurado</param>
        /// <returns>Retorna o voo procurado caso ache, caso não joga uma excessão</returns>
        public Voo searchVooAtivo(int Numero)
        {
            bool vooEncontrado = false;
            Voo vooSelecionado = null;

            while (vooEncontrado == false)
            {
                try
                {
                    vooSelecionado = VoosAtivos.Single(voo => voo.GetNumero() == Numero);
                    vooEncontrado = true;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Voo não encontrado!");
                    Console.WriteLine("Por favor inserir um numero de voo valido");
                    Numero = int.Parse(Console.ReadLine());
                }
            }
            return vooSelecionado;
        }

        /// <summary>
        /// Inclui uma reserva em um determinado voo
        /// </summary>
        public void incluirReserva(Voo vooSelecionado)
        {
            int CPF, numVoo;
            string nome, sobrenome, endereco, telefone, horario, nomeVoo;

            Console.Write("\n Por favor inserir o CPF do passageiro: ");
            CPF = int.Parse(Console.ReadLine());
            Console.Write("\n Por favor inserir o Nome do passageiro: ");
            nome = Console.ReadLine();
            Console.Write("\n Por favor inserir o Sobrenome do passageiro: ");
            sobrenome = Console.ReadLine();
            Console.Write("\n Por favor inserir o Endereço do passageiro: ");
            endereco = Console.ReadLine();
            Console.Write("\n Por favor inserir o Telefone do passageiro: ");
            telefone = Console.ReadLine();
            numVoo = vooSelecionado.GetNumero();
            horario = vooSelecionado.GetHorario();
            nomeVoo = vooSelecionado.GetNome();
            Passageiro passageiro = new Passageiro(CPF,nome, sobrenome, endereco, telefone, horario, nomeVoo, numVoo);
            Reserva reserva = new Reserva(passageiro);
            vooSelecionado.adicionarReserva(reserva);
        }

        /// <summary>
        /// Remove uma reserva em um determinado voo
        /// </summary>
        public void removerReserva(Voo vooSelecionado)
        {
            vooSelecionado.removerReserva();
        }
    }
}
