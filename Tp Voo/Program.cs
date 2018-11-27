using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Voos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "<Nome da Empresa>";
            Console.WriteLine(" <Nome Da Empresa>: Voos Disponiveis: \n");
            Console.Write(" 1) BH/Rio. \n 2) BH/SP. \n 3) BH/Recife. \n Qual Voo Deseja Observar as Opções: ");

            int opçao = int.Parse(Console.ReadLine());
            Aeroporto aeroporto = new Aeroporto();
            Voo vooEscolhido = aeroporto.searchVooAtivo(opçao);

            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine(" <Nome Da Empresa>: Voo: {0} \n Menu de Opções: \n", vooEscolhido.GetNome());
                Console.Write(" 1) Lista de Passageiros. \n 2) Pesquisar. \n 3) Cadastrar Passageiros. \n" +
                    " 4) Excluir Passageiro da Lista. \n 5) Mostrar Fila de Espera. \n 0) Sair ");
                Console.Write("\n Digite sua Opção: ");
                opçao = int.Parse(Console.ReadLine());

                switch (opçao)
                {
                    case 1:
                        {
                            Console.WriteLine(vooEscolhido);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("\n Digite o CPF do Passageiro: ");
                            int cpf = int.Parse(Console.ReadLine());
                            Console.Write("\n" + vooEscolhido.verificarPassageiro(cpf)); 
                            break;
                        }
                    case 3:
                        {
                            aeroporto.incluirReserva(vooEscolhido);
                            break;
                        }
                    case 4:
                        {
                            aeroporto.removerReserva(vooEscolhido);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine(vooEscolhido.MostrarFilaDeEspera());
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.Write("\n Valor Inexistente.");
                            break;
                        }
                }
                Console.ReadKey();
            }
            while (opçao != 0);
        }
    }
}

