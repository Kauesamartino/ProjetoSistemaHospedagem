using System.Security.Cryptography.X509Certificates;

namespace DesafioProjetoHospedagem.Models
{
    
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite.Capacidade >= hospedes.Count)
            {
               Hospedes = hospedes;
            }
            else
            {
                Console.WriteLine("O numero de hospedes excede a capacidade.\n" +
                "O programa se encerrou");
                try
                {
                
                } 
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex}");
                }
                Environment.Exit(0);
                // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            int quantidade = Hospedes.Count;
            return quantidade;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                double valorTotal;
                valorTotal = Convert.ToDouble(valor) * .90;
                valor = Convert.ToDecimal(valorTotal);
            }

            return valor;
        }
    }
}