using System;

namespace Estacionamento.Models
{
    public class Veiculo
    {
        public Veiculo()
        {

        }
        public Veiculo(string proprietario)
        {
            Proprietario = proprietario;
        }
        private string proprietario;
        public string Proprietario
        {
            get { return proprietario; }
            set
            {
                if (value.Length < 3)
                {
                    throw new System.FormatException("Nome de proprietário do veículo deve ter ao menos 3 caracteres");
                }
                proprietario = value;
            }
        }
        public string Cor { get; set; }
        public double Largura { get; set; }
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }

        private TipoVeiculo tipo;
        public TipoVeiculo Tipo { get => tipo; set => tipo = value; }

        private string placa;
        public string Placa
        {
            get
            {
                return placa;
            }
            set
            {
                if (value.Length != 8)
                {
                    //checa se o valor possui pelo menos 8 caracteres
                    throw new FormatException("A placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    //checa se os 3 primeiros caracteres são números
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }
                //checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4º caractere deve ser um hífen");
                }
                //checa se os 3 primeiros caracteres são números
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }
                placa = value;
            }
        }


        //Métodos
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }

        public void AlterarDados(Veiculo veiculoAlterado)
        {
            this.Proprietario = veiculoAlterado.Proprietario;
            this.Modelo = veiculoAlterado.Modelo;
            this.Largura = veiculoAlterado.Largura;
            this.Cor = veiculoAlterado.Cor;
        }

        public override string ToString()
        {
            return $"Ficha do Veículo:\n " +
                    $"Tipo do Veículo: {this.Tipo.ToString()}\n " +
                    $"Proprietário: {this.Proprietario}\n" +
                    $"Modelo: {this.Modelo}\n" +
                    $"Cor: {this.Cor}\n" +
                    $"Placa: {this.Placa}\n";
        }
    }
}
