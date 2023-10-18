using ConsoleApp1;
using System.CodeDom;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace UIWinFormsApp
{
    public partial class FormPrincipal : Form
    {
        Carro carro;
        public FormPrincipal()
        {
            InitializeComponent();
            carro = new Carro("Chevrolet", "Sedan", "Vermelho", 1984, "KHF-3215", 50, 100, 240);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pneu pneu = null;
                switch (comboBoxPneu.SelectedIndex)
                {
                    case 0:
                        pneu = carro.PneuDianteiroEsquerdo;
                        carro.PneuDianteiroEsquerdo = carro.PneuDeEstepe;
                        break;
                    case 1:
                        pneu = carro.PneuDianteiroDireito;
                        carro.PneuDianteiroDireito = carro.PneuDeEstepe;
                        break;
                    case 2:
                        pneu = carro.PneuTraseiroEsquerdo;
                        carro.PneuTraseiroEsquerdo = carro.PneuDeEstepe;
                        break;
                    case 3:
                        pneu = carro.PneuTraseiroDireito;
                        carro.PneuTraseiroDireito = carro.PneuDeEstepe;
                        break;
                    default:
                        break;
                }
                if (pneu != null)
                    carro.PneuDeEstepe = pneu;
                Exibir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exibir();


        }

        private void Exibir()
        {
            textBoxExibir.Text = "\nMarca: " + carro.Marca;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nModelo: " + carro.Modelo;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nCor: " + carro.Cor;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nano: " + carro.ano;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPlaca: " + carro.Placa;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nCapacidadeDoTanque: " + carro.CapacidadeDoTanque;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPercentualDeCombustivel: " + carro.PercentualDeCombustivel;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nLigado: " + carro.Ligado;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nVelocidade Maxima: " + carro.VelocidadeMaxima;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nVelocidade Atual: " + carro.VelocidadeAtual;

            ExibirPneu(carro.PneuDianteiroEsquerdo, pneuDianteiroEsquerdoTxtBox);
            ExibirPneu(carro.PneuDianteiroDireito, pneuDianteiroDireitoTxtBox);
            ExibirPneu(carro.PneuTraseiroEsquerdo, pneuTraseiroEsquerdoTxtBox);
            ExibirPneu(carro.PneuTraseiroDireito, pneuTraseiroDireitoTxtBox);
            ExibirPneu(carro.PneuDeEstepe, pneuDeEstepeTxtBox);


            if (carro.Ligado)
                bttnLigar.Text = "Desligar";
            else
                bttnLigar.Text = "Ligar";
        }

        private void ExibirPneu(Pneu _pneu, TextBox _textBox)
        {
            _textBox.Text = "\nAro: " + _pneu.Aro;
            _textBox.Text = _textBox.Text + "\r\nMarca: " + _pneu.Marca;
            _textBox.Text = _textBox.Text + "\r\nPSI: " + _pneu.PSI;
            _textBox.Text = _textBox.Text + "\r\nPSIMaximo: " + _pneu.PSIMaximo;
            _textBox.Text = _textBox.Text + "\r\nPSIMinino: " + _pneu.PSIMinino;
            _textBox.Text = _textBox.Text + "\r\nLargura: " + _pneu.Largura;
            _textBox.Text = _textBox.Text + "\r\nPercentualBorracha: " + _pneu.PercentualBorracha;
            _textBox.Text = _textBox.Text + "\r\nVelocidadeMaxima: " + _pneu.VelocidadeMaxima;
            _textBox.Text = _textBox.Text + "\r\nVelocidadeAtual: " + _pneu.VelocidadeAtual;
            _textBox.Text = _textBox.Text + "\r\nCargaAtual: " + _pneu.CargaAtual;
            _textBox.Text = _textBox.Text + "\r\nCargaMaxima: " + _pneu.CargaMaxima;
            _textBox.Text = _textBox.Text + "\r\nEstourado: " + _pneu.Estourado;
            _textBox.Text = _textBox.Text + "\r\nFurado: " + _pneu.Furado;
            _textBox.Text = _textBox.Text + "\r\nEstepe: " + _pneu.Estepe;

            _textBox.BackColor = Color.White;
            if (_pneu.Estourado)
            {
                _textBox.BackColor = Color.Red;
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void bttnLigar_Click(object sender, EventArgs e)
        {
            if (carro.Ligado)
                carro.Desligar();
            else
                carro.Ligar();

            Exibir();

        }

        private void bttnAcelerar_Click(object sender, EventArgs e)
        {
            carro.Acelerar(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();

        }

        private void bttnFrear_Click(object sender, EventArgs e)
        {
            carro.Frear(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }
    }
}