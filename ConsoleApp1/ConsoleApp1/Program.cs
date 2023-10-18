namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //funcionamento no console
            Pneu meuPneu = new Pneu(17, "Michelin", 33, 38, 25, 240, 500);
            Pneu troca;

            Carro carro = new Carro("Chevrolet", "Sedan", "Vermelho", 1984, "KHF-3215", 50, 100, 240);
            carro.Ligar();
            carro.Acelerar(5);
            carro.Acelerar(15);
            carro.Acelerar(5);
            carro.Desligar();
            carro.PneuDianteiroEsquerdo = meuPneu;
            carro.Ligar();
            carro.Acelerar(7);
            carro.Acelerar(7);
            carro.Acelerar(7);
            carro.Frear(7);
            carro.Desligar();
            troca = carro.PneuDianteiroDireito;
            carro.PneuDianteiroDireito = carro.PneuDeEstepe;
            carro.PneuDeEstepe = troca;
            carro.Ligar();
            carro.Acelerar(5);
            carro.Acelerar(10);
            carro.Acelerar(5);
            carro.Frear(4);
            carro.Desligar();

            troca = carro.PneuTraseiroDireito;
            carro.PneuTraseiroDireito = carro.PneuDeEstepe;
            carro.PneuDeEstepe = troca;

            carro.Ligar();
            carro.Acelerar(5);
            carro.Acelerar(10);
            carro.Acelerar(5);
            carro.Frear(5);
            carro.Acelerar(10);
            carro.Acelerar(5);
            carro.Acelerar(10);
            carro.Acelerar(5);
            carro.Frear(3);
            carro.Acelerar(5);
            carro.Acelerar(7);
            carro.Exibir();

        }
    }
}