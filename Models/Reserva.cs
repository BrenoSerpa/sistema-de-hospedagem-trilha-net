
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
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            
            if (hospedes.Count <= Suite.Capacidade && hospedes.Count > 0)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new ArgumentException ("A capacidade é menor do que a quantidade de hóspedes a serem recebidos.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            int quantidade = Hospedes.Count;
            return quantidade;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Caso os dias reservados forem maior ou igual a 10, é concedido um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor = valor - (valor * 0.10M);
                
                return valor;
            }

            return valor;   
        }
    }
}