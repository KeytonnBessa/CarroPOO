using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pneu
    {
        public int Aro { get; set; }
        public string Marca { get; set; }
        public int PSI { get; set; }
        public int PSIMaximo { get; set; }
        public int PSIMinino { get; set; }
        public int Largura { get; set; }
        public int PercentualBorracha { get; set; }
        public int VelocidadeMaxima { get; set; }
        public int VelocidadeAtual { get; set; }
        public int CargaAtual { get; set; }
        public int CargaMaxima { get; set; }
        public bool Estourado { get; set; }
        public bool Furado { get; set; }
        public bool Estepe { get; set; }

        public Pneu(int aro, string marca, int _PSI, int _PSIMaximo, int largura, int velocidadeMaxima, int cargaMaxima, bool estepe = false)
        {
            Aro = aro;
            Marca = marca;
            PSI = _PSI;
            PSIMaximo = _PSIMaximo;
            PSIMinino = 0;
            Largura = largura;
            PercentualBorracha = 100;
            VelocidadeMaxima = velocidadeMaxima;
            VelocidadeAtual = 0;
            CargaAtual = 0;
            CargaMaxima = cargaMaxima;
            Estourado = false;
            Furado = false;
            Estepe = estepe;
        }

        public void Exibir()
        {
            Console.WriteLine("Aro: " + Aro);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("PSI: " + PSI);
            Console.WriteLine("PSIMaximo: " + PSIMaximo);
            Console.WriteLine("PSIMinino: " + PSIMinino);
            Console.WriteLine("Largura: " + Largura);
            Console.WriteLine("PercentualBorracha: " + PercentualBorracha);
            Console.WriteLine("VelocidadeMaxima: " + VelocidadeMaxima);
            Console.WriteLine("VelocidadeAtual: " + VelocidadeAtual);
            Console.WriteLine("CargaAtual: " + CargaAtual);
            Console.WriteLine("CargaMaxima: " + CargaMaxima);
            Console.WriteLine("Estourado: " + Estourado);
            Console.WriteLine("Furado: " + Furado);
            Console.WriteLine("Estepe: " + Estepe);
        }
        private void EstourarPneu()
        {
            if (PercentualBorracha < 30 || VelocidadeAtual > VelocidadeMaxima || PSI > PSIMaximo || CargaAtual > CargaMaxima)
            {
                Estourado = true;
                VelocidadeAtual = 0;
            }
        }
        public void Acelerar(int impulso)
        {
            if (Furado || Estourado)
            {
                string estado = Furado ? "furado" : "estourado";

                Console.WriteLine($"O pneu está {estado}");
                return;
            }
            VelocidadeAtual = VelocidadeAtual + impulso;
            PercentualBorracha = PercentualBorracha - 2;

            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;

            if (PercentualBorracha < 0)
                PercentualBorracha = 0;

            EstourarPneu();
        }
        public void Frear(int impulso)
        {
            VelocidadeAtual = VelocidadeAtual - impulso;
            PercentualBorracha = PercentualBorracha - 5;

            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;

            if (PercentualBorracha < 0)
                PercentualBorracha = 0;

            EstourarPneu();
        }
        public void Furar()
        {
            Furado = true;
        }
        public void Remendar()
        {
            Furado = false;
        }

    }


}



