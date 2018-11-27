using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Voos
{
    class Voo
    {
        private Queue<Reserva> ListaDeEspera;
        private Dictionary<int, Reserva> Acentos;
        private Reserva ReservaASerAdicionada;
        private int Numero;
        private string nome, horario;

        public Voo(int Numero, string nome)
        {
            ListaDeEspera = new Queue<Reserva>(5);
            this.Numero = Numero;
            this.nome = nome;
            horario = string.Format("{0} : {1}", new Random().Next(0, 24).ToString(), new Random().Next(0, 60));
            inicializarAcentos();
        }

        /// <summary>
        /// Inicializa o voo com a quantidade permitida de acessos 
        /// e configura que um acento vazio deve ter o valor null
        /// </summary>
        private void inicializarAcentos()
        {
            Acentos = new Dictionary<int, Reserva>(10);

            for (int i = 1; i < 6; i++)
            {
                Acentos.Add(i, null);
            }

        }

        /// <summary>
        /// Metodo para adicionar uma reserva a este voo,
        /// levando em consideração os possiveis erros
        /// </summary>
        /// <param name="reserva">Objeto reserva a ser adicionada</param>
        public void adicionarReserva(Reserva reserva)
        {
            ReservaASerAdicionada = reserva;

            if (verificarDisponivel() && verificarPassageiroUnico())
            {
                int acentoEscolhido;

                Console.WriteLine("\n Acentos disponiveis");
                mostrarDisponiveis();


                Console.Write("\n Favor escolher um acento disponivel: ");
                acentoEscolhido = int.Parse(Console.ReadLine());
                addReserva(acentoEscolhido, reserva);                
            }

            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Vincula o acento escolhido a reserva a ser adicionada e oficializa 
        /// a adicção
        /// </summary>
        /// <param name="acentoEscolhido">Acento para ser escolhido para a reserva</param>
        private void addReserva(int acentoEscolhido, Reserva reserva)
        {
            if (Acentos.ContainsKey(acentoEscolhido) && Acentos.ElementAt((acentoEscolhido - 1)).Value == null)
            {
                Acentos.Remove(acentoEscolhido);
                Acentos.Add(acentoEscolhido, ReservaASerAdicionada);
                reserva.getPassageiro().SetNumPassagem(acentoEscolhido);
                Console.WriteLine("\n Reserva feita com sucesso");
            }

            else
            {
                Console.WriteLine("\n Acento nao disponivel ");
                Console.Write("\n Digite um Acento Valido: ");
                acentoEscolhido = int.Parse(Console.ReadLine());
                addReserva(acentoEscolhido, reserva);
            }
        }

        /// <summary>
        /// Caso os acentos estã cheios, inclui caso haja vaga
        /// a reserva na lista de espera
        /// </summary>
        private void incluirListaDeEspera()
        {
            if (ListaDeEspera.Count >= 5)
            {
                Console.WriteLine("\n Lista de espera cheia");
            }
            else
            {
                ListaDeEspera.Enqueue(ReservaASerAdicionada);
                Console.WriteLine("\n Acentos cheios, reserva adicionada a lista de espera");
            }
        }

        /// <summary>
        /// Verifica se há um acento livre para a adição
        /// de uma reserva, caso não haja automaticamente inclui
        /// na lista de espera
        /// </summary>
        /// <returns>True se ha disponivel e false se não há disponivel</returns>
        private bool verificarDisponivel()
        {
            if (Acentos.Count(acento => acento.Value == null) == 0)
            {
                incluirListaDeEspera();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Imprime na tela a relação de acentos disponiveis
        /// para a reserva ser adicionada
        /// </summary>
        private void mostrarDisponiveis()
        {
            var AcentosVagos = Acentos.Where(acento => acento.Value == null);
            Console.WriteLine(" ");
            foreach (var acento in AcentosVagos)
            {
                Console.Write($" |{acento.Key}|");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Verifica se o passageiro que esta na reserva é unico
        /// </summary>
        /// <returns>True se é unico, False se não é</returns>
        private bool verificarPassageiroUnico()
        {
            var reserva = Acentos.SingleOrDefault(acento => acento.Value != null && acento.Value.getPassageiro().getCpf() == ReservaASerAdicionada.getPassageiro().getCpf());
            if (reserva.Value != null)
            {
                Console.WriteLine("\n Passageiro ja existente");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Pega o numero do voo
        /// </summary>
        /// <returns>Inteiro com o numero do voo</returns>
        public int GetNumero()
        {
            return Numero;
        }

        /// <summary>
        /// Pega o nome do voo
        /// </summary>
        /// <returns>String com o nome do voo</returns>
        public string GetNome()
        {
            return nome;
        }

        /// <summary>
        /// Pega o nome do voo
        /// </summary>
        /// <returns>String com o nome do voo</returns>
        public string GetHorario()
        {
            return horario;
        }

        /// <summary>
        /// Metodo para remover uma reserva a este voo,
        /// levando em consideração os possiveis erros
        /// </summary>
        public void removerReserva()
        {
            int cpf;
            int reservaARemover;
            Console.Write("\n Digite o cpf do Passageiro: ");
            cpf = int.Parse(Console.ReadLine());
            reservaARemover = searchReserva(cpf);
            if (reservaARemover != -1)
            {
                Acentos[reservaARemover] = null;
                if (ListaDeEspera.Count > 0)
                {
                    adicionarReserva(ListaDeEspera.Dequeue());
                }
            }
            else
            {
                Console.WriteLine("\n Passageiro Inexistente");
                removerReserva();
            }
        }
        /// <summary>
        /// Metodo para verificar se existe, a pessoa no acento.
        /// <returns>A Key do Assento caso exista, -1 se não</returns>
        /// </summary>
        private int searchReserva(int cpf)
        {
            foreach (var i in Acentos)
            {
                if (i.Value != null && i.Value.getPassageiro().getCpf() == cpf)
                {
                    return i.Key;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            string passageiros = null;
            foreach (var i in Acentos)
            {
                if (i.Value != null)
                {
                    passageiros += i.Value.getPassageiro().ToString() + "\n";
                }
            }
            if (passageiros != null)
            {
                return "\n"+ passageiros;
            }
            return "\n Não Há Passageiros neste Voo.";
        }

        public string MostrarFilaDeEspera()
        {
            string passageiros = null;
            foreach (var i in ListaDeEspera)
            {
                if (i != null)
                {
                    passageiros += i.getPassageiro().ToString() + "\n";
                }
            }
            if (passageiros != null)
            {
                return "\n" + passageiros;
            }
            return "\n Não Há Passageiros na Lista de Espera deste Voo.";
        }
        public string verificarPassageiro(int cpf)
        {
            var reserva = Acentos.SingleOrDefault(acento => acento.Value != null && acento.Value.getPassageiro().getCpf() == cpf);
            if (reserva.Value == null)
            {
                return "\n Passageiro não localizado neste voo!";
            }
            else
            {
                return reserva.Value.getPassageiro().CadastroCompleto();
            }
        }
    }
}
