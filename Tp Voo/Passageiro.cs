using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Voos
{
    class Passageiro
    {
        private int CPF, numPassagem, numVoo, numPoltrona;
        private string nome, sobrenome, endereco, telefone, horario, nomeVoo;

        public Passageiro(int CPF, string nome, string sobrenome, string endereco, string telefone, string horario, string nomeVoo,
            int numVoo)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.horario = horario;
            this.nomeVoo = nomeVoo;
            this.numVoo = numVoo;
        }
        
        /// <summary>
        /// Função para pegar o CPF do passageiro
        /// </summary>
        /// <returns>Uma string com o CPF do passageiro</returns>

        public int getCpf()
        {
            return CPF;
        }

        public void SetNumPassagem(int numPassagem)
        {
            this.numPassagem = numPassagem;
            numPoltrona = numPassagem;
        }

        public override string ToString()
        {
            return string.Format(" CPF: {0} \n Nome: {1} {2} \n Numero da Passagem: {3} \n Poltrona: {4}.", 
                CPF, nome, sobrenome, numPassagem, numPoltrona);
        }

        public string CadastroCompleto()
        {
            return string.Format(" CPF: {0} \n Nome: {1} {2} \n Endereço: {3} \n Telefone: {4} \n Horario: {5} " +
                "\n Numero da Passagem: {6} \n Poltrona: {7} ",
                CPF, nome, sobrenome, endereco, telefone, horario, numPassagem, numPoltrona);
        }
    }
}
