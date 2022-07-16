using Estacionamento.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;
        public VeiculoTestes(ITestOutputHelper _testOutputHelper)
        {
            saidaConsoleTeste = _testOutputHelper;
            veiculo = new Veiculo();
        }

        [Fact(DisplayName = "Teste n� 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange - Cen�rio
            var veiculo = new Veiculo();
            //Act - M�todos
            veiculo.Acelerar(10);
            //Assert - Verificar Resultado esperado com o resultado obtido
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n� 2")]
        [Trait("Funcinalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange - Cen�rio
            var veiculo = new Veiculo();
            //Act - M�todos
            veiculo.Frear(10);
            //Assert - Resultado
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var carro = new Veiculo();
            veiculo.Proprietario = "Relinton Pinheiro Franco";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
        );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ABCD8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }
}
