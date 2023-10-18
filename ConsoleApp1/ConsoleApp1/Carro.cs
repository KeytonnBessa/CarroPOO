using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int ano { get; set; }
        public string Placa { get; set; }

        private Pneu pneuDianteiroEsquerdo;
        public Pneu PneuDianteiroEsquerdo {

            get
            {
                return pneuDianteiroEsquerdo;
            }
            set
            {
                if (VelocidadeAtual > 0)
                    throw new Exception("Vai trocar o pneu com o carro andando?");

                if (Ligado)
                    throw new Exception("Desligue o carro");


                
                pneuDianteiroEsquerdo = value;
            } 

        }
        public Pneu PneuDianteiroDireito { get; set; }
        public Pneu PneuTraseiroEsquerdo { get; set; }
        public Pneu PneuTraseiroDireito { get; set; }
        public Pneu PneuDeEstepe { get; set; }
        public int CapacidadeDoTanque { get; set; }
        public int PercentualDeCombustivel { get; set; }
        public bool Ligado { get; set; }
        public int VelocidadeMaxima { get; set; }
        public int VelocidadeAtual { get; set; }

        public Carro(string marca, string modelo, string cor, int _ano, string placa, int capacidadeDoTanque, int percentualDeCombustivel, int velocidadeMaxima)
        {
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            ano = _ano;
            Placa = placa;
            PneuDianteiroEsquerdo = new Pneu(15, "Michelin", 33, 38, 25, 240, 500);
            PneuDianteiroDireito = new Pneu(15, "Michelin", 33, 38, 25, 240, 500);
            PneuTraseiroEsquerdo = new Pneu(15, "Michelin", 33, 38, 25, 240, 500);
            PneuTraseiroDireito = new Pneu(15, "Michelin", 33, 38, 25, 240, 500);
            PneuDeEstepe = new Pneu(15, "Michelin", 33, 38, 20, 70, 300, true);
            CapacidadeDoTanque = capacidadeDoTanque;
            PercentualDeCombustivel = percentualDeCombustivel;
            VelocidadeAtual = 0;
            VelocidadeMaxima = velocidadeMaxima;
            Ligado = false;
        }
        public void Exibir()
        {
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Cor: " + Cor);
            Console.WriteLine("ano: " + ano);
            Console.WriteLine("Placa: " + Placa);
            Console.WriteLine("CapacidadeDoTanque: " + CapacidadeDoTanque);
            Console.WriteLine("PercentualDeCombustivel: " + PercentualDeCombustivel);
            Console.WriteLine("Ligado: " + Ligado);
            Console.WriteLine("Velocidade Maxima: "+VelocidadeMaxima);
            Console.WriteLine("Velocidade Atual: "+VelocidadeAtual);


            Console.WriteLine("\nPneuDianteiroEsquerdo");
            PneuDianteiroEsquerdo.Exibir();
            Console.WriteLine("\nPneuDianteiroDireito: ");
            PneuDianteiroDireito.Exibir();
            Console.WriteLine("\nPneuTraseiroEsquerdo: ");
            PneuTraseiroEsquerdo.Exibir();
            Console.WriteLine("\nPneuTraseiroDireito: ");
            PneuTraseiroDireito.Exibir();
            Console.WriteLine("\nPneuDeEstepe: ");
            PneuDeEstepe.Exibir();
        }

        public void Ligar()
        {
            if (PercentualDeCombustivel > 0)
            {
                Ligado = true;
                PercentualDeCombustivel = PercentualDeCombustivel - 1;
            }

        }
        public void Desligar()
        {
            Ligado = false;
           
            Parar();
        }
        private bool CarroEstaOperacional()
        {
            if (PercentualDeCombustivel <= 0)
            {
                PercentualDeCombustivel = 0;
                Console.WriteLine("O carro está sem combustivel!");
                Desligar();
                return false;
            }

            if(PneuDianteiroDireito.Estourado || PneuDianteiroDireito.Furado)
            {
                Console.WriteLine("Problema com o pneu dianteiro direito");
                Parar();
                return false;
            }
            if(PneuDianteiroEsquerdo.Estourado || PneuDianteiroEsquerdo.Furado)
            {
                Console.WriteLine("Problema com o pneu dianteiro esquerdo");
                Parar();
                return false;
            }
            if(PneuTraseiroDireito.Estourado || PneuTraseiroDireito.Furado)
            {
                Console.WriteLine("Problema com o pneu traseiro direito");
                Parar();
                return false;
            }
            if(PneuTraseiroEsquerdo.Estourado || PneuTraseiroEsquerdo.Furado)
            {
                Console.WriteLine("Problema com o pneu traseiro esquerdo");
                Parar();
                return false;
            }
            return true;
        }
        public void Acelerar(int impulso)
        {
            if (!Ligado)
            {
                Console.WriteLine("O carro está desligado!");
                return;
            }
            PercentualDeCombustivel -= 5;

            if (CarroEstaOperacional())
            {
                VelocidadeAtual += impulso;
                PneuDianteiroDireito.Acelerar(impulso);
                PneuDianteiroEsquerdo.Acelerar(impulso);
                PneuTraseiroDireito.Acelerar(impulso);
                PneuTraseiroEsquerdo.Acelerar(impulso);
                CarroEstaOperacional();
            }

        }

        public void Parar()
        {
            Frear(VelocidadeAtual);
        }
        public void Frear(int impulso)
        {
            VelocidadeAtual -= impulso;
            PneuDianteiroDireito.Frear(impulso);
            PneuDianteiroEsquerdo.Frear(impulso);
            PneuTraseiroDireito.Frear(impulso);
            PneuTraseiroEsquerdo.Frear(impulso);

            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;

        }


    }



}

