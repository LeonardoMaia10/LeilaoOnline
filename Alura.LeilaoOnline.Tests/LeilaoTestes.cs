using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arranje = cenario de entrada
            var leilao = new Leilao("Van Gohn");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            //Act metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        [Fact]
        public static void LeilaoComApenasUmLance()
        {
            //Arranje = cenario de entrada
            var leilao = new Leilao("Van Gohn");
            var fulano = new Interessada("Fulano", leilao);


            leilao.RecebeLance(fulano, 800);

            //Act metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }

    }
}
