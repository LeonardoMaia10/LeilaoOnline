using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou: {esperado}, obtido: {obtido}.");
            }
            Console.ForegroundColor = cor;

        }
        private static void LeilaoComVariosLances()
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
            Verifica(valorEsperado, valorObtido);
        }
    
        private static void LeilaoComApenasUmLance()
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

            Verifica(valorEsperado, valorObtido);

        }
    
    static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
